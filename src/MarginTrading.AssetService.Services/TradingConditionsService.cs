﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarginTrading.AssetService.Core.Domain;
using MarginTrading.AssetService.Core.Interfaces;
using MarginTrading.AssetService.Core.Services;
using MarginTrading.AssetService.Core.Settings;
using MarginTrading.AssetService.StorageInterfaces.Repositories;

namespace MarginTrading.AssetService.Services
{
    public class TradingConditionsService : ITradingConditionsService
    {
        private readonly IClientProfilesRepository _clientProfilesRepository;
        private readonly ISettlementCurrencyService _settlementCurrencyService;
        private readonly DefaultTradingConditionsSettings _defaultTradingConditionsSettings;
        private readonly DefaultLegalEntitySettings _defaultLegalEntitySettings;

        public TradingConditionsService(
            IClientProfilesRepository clientProfilesRepository,
            ISettlementCurrencyService settlementCurrencyService,
            DefaultTradingConditionsSettings defaultTradingConditionsSettings,
            DefaultLegalEntitySettings defaultLegalEntitySettings)
        {
            _clientProfilesRepository = clientProfilesRepository;
            _settlementCurrencyService = settlementCurrencyService;
            _defaultTradingConditionsSettings = defaultTradingConditionsSettings;
            _defaultLegalEntitySettings = defaultLegalEntitySettings;
        }

        public async Task<IReadOnlyList<ITradingCondition>> GetAsync()
        {
            var profiles = await _clientProfilesRepository.GetAllAsync();
            var settlementCurrency = await _settlementCurrencyService.GetSettlementCurrencyAsync();

            return profiles.Select(x => MapTradingCondition(x, settlementCurrency)).ToList();
        }

        public async Task<ITradingCondition> GetAsync(string clientProfileId)
        {
            var clientProfile = await _clientProfilesRepository.GetByIdAsync(clientProfileId);

            if (clientProfile == null)
                return null;

            var settlementCurrency = await _settlementCurrencyService.GetSettlementCurrencyAsync();

            return MapTradingCondition(clientProfile, settlementCurrency);
        }

        public async Task<IReadOnlyList<ITradingCondition>> GetByDefaultFilterAsync(bool isDefault)
        {
            var profiles = await _clientProfilesRepository.GetByDefaultFilterAsync(isDefault);
            var settlementCurrency = await _settlementCurrencyService.GetSettlementCurrencyAsync();

            return profiles.Select(x => MapTradingCondition(x, settlementCurrency)).ToList();
        }
        private ITradingCondition MapTradingCondition(ClientProfile clientProfile, string settlementCurrency)
        {
            return TradingCondition.CreateFromClientProfile(clientProfile,
                _defaultLegalEntitySettings.DefaultLegalEntity,
                _defaultTradingConditionsSettings.MarginCall1,
                _defaultTradingConditionsSettings.MarginCall2,
                _defaultTradingConditionsSettings.StopOut,
                settlementCurrency);
        }
    }
}