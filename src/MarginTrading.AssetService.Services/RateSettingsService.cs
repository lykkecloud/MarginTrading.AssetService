﻿// Copyright (c) 2019 Lykke Corp.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Log;
using MarginTrading.AssetService.Core.Domain.Rates;
using MarginTrading.AssetService.Core.Services;
using MarginTrading.AssetService.Core.Settings.Rates;


namespace MarginTrading.AssetService.Services
{
    public class RateSettingsService : IRateSettingsService
    {
        private readonly IRatesStorage _ratesStorage;

        private readonly ILog _log;
        private readonly DefaultRateSettings _defaultRateSettings;

        public RateSettingsService(
            IRatesStorage ratesStorage,
            ILog log,
            DefaultRateSettings defaultRateSettings)
        {
            _ratesStorage = ratesStorage;
            _log = log;
            _defaultRateSettings = defaultRateSettings;
        }

        #region Order Execution

        public async Task<IReadOnlyList<OrderExecutionRate>> GetOrderExecutionRates(IList<string> assetPairIds = null)
        {
            var repoData = await _ratesStorage.GetOrderExecutionRatesAsync();

            if (assetPairIds == null || !assetPairIds.Any())
                return repoData.ToList();

            return assetPairIds
                .Select(assetPairId => GetOrderExecutionRateSingleOrDefault(assetPairId, repoData))
                .ToList();
        }

        private OrderExecutionRate GetOrderExecutionRateSingleOrDefault(string assetPairId,
            IReadOnlyCollection<OrderExecutionRate> repoData)
        {
            var rate = repoData?.FirstOrDefault(x => x.AssetPairId == assetPairId);
            if (rate == null)
            {
                _log.WriteWarning(nameof(RateSettingsService), nameof(GetOrderExecutionRateSingleOrDefault),
                    $"No order execution rate for {assetPairId}. Using the default one.");

                var rateFromDefault =
                    OrderExecutionRate.FromDefault(_defaultRateSettings.DefaultOrderExecutionSettings, assetPairId);

                return rateFromDefault;
            }

            return rate;
        }

        public async Task ReplaceOrderExecutionRates(List<OrderExecutionRate> rates)
        {
            rates = rates.Select(x =>
            {
                if (string.IsNullOrWhiteSpace(x.LegalEntity))
                {
                    x.LegalEntity = _defaultRateSettings.DefaultOrderExecutionSettings.LegalEntity;
                }

                return x;
            }).ToList();

            await _ratesStorage.MergeOrderExecutionRatesAsync(rates);
        }

        #endregion Order Execution

        #region Overnight Swaps

        public async Task<IReadOnlyList<OvernightSwapRate>> GetOvernightSwapRates(IList<string> assetPairIds = null)
        {
            var repoData = await _ratesStorage.GetOvernightSwapRatesAsync();

            if (assetPairIds == null || !assetPairIds.Any())
                return repoData.ToList();

            return assetPairIds
                .Select(assetPairId => GetOvernightSwapRateSingleOrDefault(assetPairId, repoData))
                .ToList();
        }

        private OvernightSwapRate GetOvernightSwapRateSingleOrDefault(string assetPairId,
            IReadOnlyCollection<OvernightSwapRate> repoData)
        {
            var rate = repoData?.FirstOrDefault(x => x.AssetPairId == assetPairId);
            if (rate == null)
            {
                _log.WriteWarning(nameof(RateSettingsService), nameof(GetOvernightSwapRateSingleOrDefault),
                    $"No overnight swap rate for {assetPairId}. Using the default one.");

                var rateFromDefault =
                    OvernightSwapRate.FromDefault(_defaultRateSettings.DefaultOvernightSwapSettings, assetPairId);

                return rateFromDefault;
            }

            return rate;
        }

        public async Task ReplaceOvernightSwapRates(List<OvernightSwapRate> rates)
        {
            await _ratesStorage.MergeOvernightSwapRatesAsync(rates);
        }

        #endregion Overnight Swaps

        #region On Behalf

        public async Task<OnBehalfRate> GetOnBehalfRate()
        {
            var rate = await _ratesStorage.GetOnBehalfRateAsync();
            if (rate == null)
            {
                await _log.WriteWarningAsync(nameof(RateSettingsService), nameof(GetOnBehalfRate),
                    $"No OnBehalf rate saved, using the default one.");

                rate = OnBehalfRate.FromDefault(_defaultRateSettings.DefaultOnBehalfSettings);
            }

            return rate;
        }

        public async Task ReplaceOnBehalfRate(OnBehalfRate rate)
        {
            if (string.IsNullOrWhiteSpace(rate.LegalEntity))
            {
                rate.LegalEntity = _defaultRateSettings.DefaultOrderExecutionSettings.LegalEntity;
            }

            await _ratesStorage.ReplaceOnBehalfRateAsync(rate);
        }

        #endregion On Behalf
    }
}