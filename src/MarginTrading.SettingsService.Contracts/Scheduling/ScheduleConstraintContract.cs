﻿using System;

namespace MarginTrading.SettingsService.Contracts.Scheduling
{
    /// <summary>
    /// Either Date or DayOfWeek must be set
    /// </summary>
    public class ScheduleConstraintContract
    {
        public string Date { get; set; }
        public DayOfWeek? DayOfWeek { get; set; }
        public TimeSpan Time { get; set; }
    }
}
