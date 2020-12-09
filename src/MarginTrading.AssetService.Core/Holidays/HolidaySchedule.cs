using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Lykke.Snow.Common.Holidays;

namespace MarginTrading.AssetService.Core.Holidays
{
    public class HolidaySchedule
    {
        private readonly List<Holiday> _holidays = new List<Holiday>();

        public ReadOnlyCollection<Holiday> Holidays => _holidays.AsReadOnly();

        public HolidaySchedule(IEnumerable<string> holidays)
        {
            
        }
        
        public bool ContainsDay(DateTime day) => _holidays.Any(h => h.SameDay(day));
    }
}