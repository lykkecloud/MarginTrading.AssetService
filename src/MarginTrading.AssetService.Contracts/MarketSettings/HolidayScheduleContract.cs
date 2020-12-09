using System.Collections.Generic;
using Lykke.Snow.Common.Holidays;

namespace MarginTrading.AssetService.Contracts.MarketSettings
{
    public class HolidayScheduleContract
    {
        public List<Holiday> Holidays { get; set; }
    }
}