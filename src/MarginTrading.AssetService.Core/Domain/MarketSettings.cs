using System;
using System.Collections.Generic;
using MarginTrading.AssetService.Core.Constants;
using MarginTrading.AssetService.Core.Holidays;

namespace MarginTrading.AssetService.Core.Domain
{
    public class MarketSettings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal DividendsLong { get; set; }

        public decimal DividendsShort { get; set; }

        public decimal Dividends871M { get; set; }

        public TimeSpan[] Open { get; set; }

        public TimeSpan[] Close { get; set; }

        public string Timezone { get; set; }

        public HolidaySchedule HolidaySchedule { get; set; }

        public static MarketSettings GetMarketSettingsWithDefaults(MarketSettingsCreateOrUpdateDto model)
        {
            return new MarketSettings
            {
                Id = model.Id,
                Name = model.Name,
                Dividends871M = model.Dividends871M,
                DividendsLong = model.DividendsLong,
                DividendsShort = model.DividendsShort,
                HolidaySchedule = new HolidaySchedule(model.Holidays),
                Open = model.Open,
                Close = model.Close,
                Timezone = string.IsNullOrEmpty(model.Timezone)
                    ? MarketSettingsConstants.DefaultTimeZone
                    : model.Timezone,
            };
        }
    }
}