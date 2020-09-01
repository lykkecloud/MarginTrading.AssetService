﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Lykke.Snow.Common.Model;
using MarginTrading.AssetService.Contracts.Enums;
using MarginTrading.AssetService.Contracts.MarketSettings;
using MarginTrading.AssetService.Core.Constants;
using MarginTrading.AssetService.Core.Domain;
using MarginTrading.AssetService.Core.Services;
using MarginTrading.AssetService.StorageInterfaces.Repositories;
using TimeZoneConverter;

namespace MarginTrading.AssetService.Services
{
    public class MarketSettingsService : IMarketSettingsService
    {
        private readonly IMarketSettingsRepository _marketSettingsRepository;
        private readonly IAuditService _auditService;
        private readonly ICqrsMessageSender _cqrsMessageSender;
        private readonly IConvertService _convertService;

        public MarketSettingsService(
            IMarketSettingsRepository marketSettingsRepository,
            IAuditService auditService,
            ICqrsMessageSender cqrsMessageSender,
            IConvertService convertService)
        {
            _marketSettingsRepository = marketSettingsRepository;
            _auditService = auditService;
            _cqrsMessageSender = cqrsMessageSender;
            _convertService = convertService;
        }

        public Task<MarketSettings> GetByIdAsync(string id)
            => _marketSettingsRepository.GetByIdAsync(id);

        public Task<IReadOnlyList<MarketSettings>> GetAllMarketSettingsAsync()
            => _marketSettingsRepository.GetAllMarketSettingsAsync();

        public async Task<Result<MarketSettingsErrorCodes>> AddAsync(MarketSettingsCreateOrUpdateDto model, string username, string correlationId)
        {
            var marketSettings = GetMarketSettingsWithDefaults(model);

            var validationResult = ValidateSettings(marketSettings);

            if (validationResult.IsFailed)
                return validationResult;

            var addResult = await _marketSettingsRepository.AddAsync(marketSettings);

            if (addResult.IsFailed)
                return addResult;

            await _auditService.TryAudit(correlationId, username, model.Id, AuditDataType.MarketSettings,
                marketSettings.ToJson());

            await PublishMarketSettingsChangedEvent(null, marketSettings, username, correlationId, ChangeType.Creation);

            return new Result<MarketSettingsErrorCodes>();
        }

        public async Task<Result<MarketSettingsErrorCodes>> UpdateAsync(MarketSettingsCreateOrUpdateDto model, string username, string correlationId)
        {
            var marketSettings = GetMarketSettingsWithDefaults(model);

            var currentSettings = await _marketSettingsRepository.GetByIdAsync(marketSettings.Id);

            if (currentSettings == null)
                return new Result<MarketSettingsErrorCodes>(MarketSettingsErrorCodes.MarketSettingsDoNotExist);

            ValidateSettings(marketSettings);

            //This is the current day taking into account the timezone
            var currentDay = DateTime.UtcNow.Add(TZConvert.GetTimeZoneInfo(currentSettings.Timezone).BaseUtcOffset);

            //Validate if we try to add holiday for already started trading day
            if (marketSettings.Holidays.Select(x => x.Date.Date).Contains(currentDay.Date) &&
                currentSettings.Open <= currentDay.TimeOfDay &&
                //Close will be Zero when it is set to 00h next day
                (currentSettings.Close >= currentDay.TimeOfDay || model.Close == TimeSpan.Zero))
            {
                return new Result<MarketSettingsErrorCodes>(MarketSettingsErrorCodes.TradingDayAlreadyStarted);
            }

            await _marketSettingsRepository.UpdateAsync(marketSettings);

            await _auditService.TryAudit(correlationId, username, marketSettings.Id, AuditDataType.MarketSettings,
                marketSettings.ToJson(), currentSettings.ToJson());

            await PublishMarketSettingsChangedEvent(currentSettings, marketSettings, username, correlationId, ChangeType.Edition);

            return new Result<MarketSettingsErrorCodes>();
        }

        public async Task<Result<MarketSettingsErrorCodes>> DeleteAsync(string id, string username, string correlationId)
        {
            var existing = await _marketSettingsRepository.GetByIdAsync(id);

            if (existing == null)
                return new Result<MarketSettingsErrorCodes>(MarketSettingsErrorCodes.MarketSettingsDoNotExist);

            await _marketSettingsRepository.DeleteAsync(id);

            await _auditService.TryAudit(correlationId, username, id, AuditDataType.MarketSettings,
                oldStateJson: existing.ToJson());

            await PublishMarketSettingsChangedEvent(existing, null, username, correlationId, ChangeType.Deletion);

            return new Result<MarketSettingsErrorCodes>();
        }

        private Result<MarketSettingsErrorCodes> ValidateSettings(MarketSettings model)
        {
            var valid = TZConvert.TryGetTimeZoneInfo(model.Timezone, out _);
            if (!valid)
                return new Result<MarketSettingsErrorCodes>(MarketSettingsErrorCodes.InvalidTimezone);

            if (model.Open.TotalHours > 24 || model.Close.TotalHours > 24 || (model.Open > model.Close && model.Close != TimeSpan.Zero))
                return new Result<MarketSettingsErrorCodes>(MarketSettingsErrorCodes.InvalidOpenAndCloseHours);

            if (model.DividendsLong < 0 || model.DividendsLong > 1)
                return new Result<MarketSettingsErrorCodes>(MarketSettingsErrorCodes.InvalidDividendsLongValue);

            if (model.DividendsShort < 0 || model.DividendsShort > 1)
                return new Result<MarketSettingsErrorCodes>(MarketSettingsErrorCodes.InvalidDividendsShortValue);

            if (model.Dividends871M < 0 || model.Dividends871M > 1)
                return new Result<MarketSettingsErrorCodes>(MarketSettingsErrorCodes.InvalidDividends871MValue);

            return new Result<MarketSettingsErrorCodes>();
        }

        private static MarketSettings GetMarketSettingsWithDefaults(MarketSettingsCreateOrUpdateDto model)
        {
            return new MarketSettings
            {
                Id = model.Id,
                Name = model.Name,
                Dividends871M = model.Dividends871M,
                DividendsLong = model.DividendsLong,
                DividendsShort = model.DividendsShort,
                MICCode = model.MICCode,
                Holidays = model.Holidays,
                Open = model.Open ?? MarketSettingsConstants.DefaultOpen,
                Close = model.Close ?? MarketSettingsConstants.DefaultClose,
                Timezone = string.IsNullOrEmpty(model.Timezone)
                    ? MarketSettingsConstants.DefaultTimeZone
                    : model.Timezone,
            };
        }

        private async Task PublishMarketSettingsChangedEvent
            (MarketSettings oldSettings, MarketSettings newSettings, string username, string correlationId, ChangeType changeType)
        {
            await _cqrsMessageSender.SendEvent(new MarketSettingsChangedEvent
            {
                Username = username,
                ChangeType = changeType,
                CorrelationId = correlationId,
                EventId = Guid.NewGuid().ToString(),
                Timestamp = DateTime.UtcNow,
                OldMarketSettings = _convertService.Convert<MarketSettings, MarketSettingsContract>(oldSettings),
                NewMarketSettings = _convertService.Convert<MarketSettings, MarketSettingsContract>(newSettings),
            });
        }
    }
}