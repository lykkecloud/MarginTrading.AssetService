﻿// Copyright (c) 2019 Lykke Corp.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Threading.Tasks;
using MarginTrading.AssetService.Core.Services;
using MarginTrading.AssetService.Middleware;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using MarginTrading.AssetService.Contracts;
using MarginTrading.AssetService.Contracts.Rates;
using MarginTrading.AssetService.Core.Domain.Rates;
using Microsoft.AspNetCore.Authorization;

namespace MarginTrading.AssetService.Controllers
{
    [Authorize]
    [Route("api/rates")]
    [MiddlewareFilter(typeof(RequestLoggingPipeline))]
    public class RateSettingsController : Controller, IRateSettingsApi
    {
        private readonly IRateSettingsService _rateSettingsService;
        private readonly IConvertService _convertService;

        public RateSettingsController(
            IRateSettingsService rateSettingsService,
            IConvertService convertService)
        {
            _rateSettingsService = rateSettingsService;
            _convertService = convertService;
        }


        [ProducesResponseType(typeof(IReadOnlyList<OvernightSwapRateContract>), 200)]
        [ProducesResponseType(400)]
        [HttpGet("get-overnight-swap")]
        public async Task<IReadOnlyList<OvernightSwapRateContract>> GetOvernightSwapRatesAsync()
        {
            return (await _rateSettingsService.GetOvernightSwapRatesAsync())
                   ?.Select(x => _convertService.Convert<OvernightSwapRate, OvernightSwapRateContract>(x)).ToList()
                   ?? new List<OvernightSwapRateContract>();
        }

        [ProducesResponseType(typeof(OvernightSwapRateContract), 200)]
        [ProducesResponseType(400)]
        [HttpGet("get-overnight-swap/{assetPairId}")]
        public async Task<OvernightSwapRateContract> GetOvernightSwapRatesAsync(string assetPairId)
        {
            var swapRate = (await _rateSettingsService.GetOvernightSwapRatesAsync(new[] {assetPairId})).SingleOrDefault();

            if (swapRate == null)
                return null;

            return _convertService.Convert<OvernightSwapRate, OvernightSwapRateContract>(swapRate);
        }

        [ProducesResponseType(typeof(IReadOnlyList<OvernightSwapRateContract>), 200)]
        [ProducesResponseType(400)]
        [HttpPost("get-overnight-swap/list")]
        public async Task<IReadOnlyList<OvernightSwapRateContract>> GetOvernightSwapRatesAsync(string[] assetPairIds)
        {
            var swapRates = await _rateSettingsService.GetOvernightSwapRatesAsync(assetPairIds);

            return swapRates
                .Select(_convertService.Convert<OvernightSwapRate, OvernightSwapRateContract>)
                .ToList();
        }
    }
}