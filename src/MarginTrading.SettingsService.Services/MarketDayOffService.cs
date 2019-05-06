using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarginTrading.SettingsService.Core;
using MarginTrading.SettingsService.Core.Domain;
using MarginTrading.SettingsService.Core.Services;
using MarginTrading.SettingsService.Core.Settings;
using MarginTrading.SettingsService.StorageInterfaces.Repositories;
using Microsoft.Extensions.Internal;

namespace MarginTrading.SettingsService.Services
{
    public class MarketDayOffService : IMarketDayOffService
    {
        private readonly IScheduleSettingsRepository _scheduleSettingsRepository;
        private readonly ISystemClock _systemClock;
        private readonly PlatformSettings _platformSettings;
        
        public MarketDayOffService(
            IScheduleSettingsRepository scheduleSettingsRepository,
            ISystemClock systemClock,
            PlatformSettings platformSettings)
        {
            _scheduleSettingsRepository = scheduleSettingsRepository;
            _systemClock = systemClock;
            _platformSettings = platformSettings;
        }

        public async Task<Dictionary<string, bool>> MarketsStatus(string[] marketIds)
        {
            var scheduleSettings = (await _scheduleSettingsRepository.GetFilteredAsync())
                .Where(x => !string.IsNullOrWhiteSpace(x.MarketId))
                .Cast<ScheduleSettings>()
                .GroupBy(x => x.MarketId)
                .ToDictionary(x => x.Key, x => x.ToList());
            var currentDateTime = _systemClock.UtcNow.UtcDateTime;

            var rawPlatformSchedule = scheduleSettings.TryGetValue(_platformSettings.PlatformMarketId, out var platformSettings)
                ? platformSettings
                : new List<ScheduleSettings>();
            var platformCompiledSchedule = CompileSchedule(rawPlatformSchedule, currentDateTime);

            var result = marketIds.Except(scheduleSettings.Keys).ToDictionary(
                marketWithoutSchedule => marketWithoutSchedule,
                _ => IsOn(platformCompiledSchedule, currentDateTime));

            foreach (var marketToCompile in marketIds.Except(result.Keys))
            {
                var compiledSchedule = CompileSchedule(
                    scheduleSettings[marketToCompile].Concat(
                        rawPlatformSchedule.WithRank(int.MaxValue)).ToList(), 
                    currentDateTime);
                result.Add(marketToCompile, IsOn(compiledSchedule, currentDateTime));
            }

            return result;
        }

        public async Task<(DateTime, bool)> GetPlatformInfo()
        {
            var rawPlatformSchedule = (await _scheduleSettingsRepository.GetFilteredAsync())
                .Where(x => x.MarketId == _platformSettings.PlatformMarketId)
                .Cast<ScheduleSettings>()
                .ToList();
            var currentDateTime = _systemClock.UtcNow.UtcDateTime;

            var currentInterval = CompileSchedule(rawPlatformSchedule, currentDateTime)
                .Where(x => IsBetween(currentDateTime, x.Start, x.End))
                .OrderByDescending(x => x.Schedule.Rank)
                .FirstOrDefault();

            var isEnabled = currentInterval?.Schedule.IsTradeEnabled ?? true;
            return (isEnabled
                    ? _systemClock.UtcNow.UtcDateTime.Date
                    : currentInterval.Start.Date,
                isEnabled);
        }

        private static bool IsOn(IEnumerable<CompiledScheduleTimeInterval> compiledSchedule, DateTime currentDateTime)
        {
            var intersecting = compiledSchedule.Where(x => IsBetween(currentDateTime, x.Start, x.End));

            return intersecting.OrderByDescending(x => x.Schedule.Rank)
                       .Select(x => x.Schedule).FirstOrDefault()?.IsTradeEnabled ?? true;
        }

        private static bool IsBetween(DateTime currentDateTime, DateTime start, DateTime end)
        {
            return start <= currentDateTime && currentDateTime < end;
        }
        
        private static List<CompiledScheduleTimeInterval> CompileSchedule(
            IEnumerable<ScheduleSettings> scheduleSettings, DateTime currentDateTime)
        {
            var scheduleSettingsByType = scheduleSettings
                .GroupBy(x => x.Start.GetConstraintType())
                .ToDictionary(x => x.Key, value => value);

            //handle weekly
            var weekly = scheduleSettingsByType.TryGetValue(ScheduleConstraintType.Weekly, out var weeklySchedule)
                ? weeklySchedule.SelectMany(sch =>
                {
                    var currentStart = CurrentWeekday(currentDateTime, sch.Start.DayOfWeek.Value);
                    var currentEnd = CurrentWeekday(currentDateTime, sch.End.DayOfWeek.Value);
                    if (currentEnd < currentStart)
                    {
                        currentEnd = currentEnd.AddDays(7);
                    }

                    return new[]
                    {
                        new CompiledScheduleTimeInterval(sch, currentStart, currentEnd),
                        new CompiledScheduleTimeInterval(sch, currentStart.AddDays(-7), currentEnd.AddDays(-7))
                    };
                })
                : new List<CompiledScheduleTimeInterval>();
            
            //handle single
            var single = scheduleSettingsByType.TryGetValue(ScheduleConstraintType.Single, out var singleSchedule)
                ? singleSchedule.Select(sch => new CompiledScheduleTimeInterval(sch,
                    sch.Start.Date.Value,
                    sch.End.Date.Value))
                : new List<CompiledScheduleTimeInterval>();
            
            //handle daily
            var daily = scheduleSettingsByType.TryGetValue(ScheduleConstraintType.Daily, out var dailySchedule)
                ? dailySchedule.SelectMany(sch =>
                {
                    var start = currentDateTime.Date.Add(sch.Start.Time);
                    var end = currentDateTime.Date.Add(sch.End.Time);
                    if (end < start)
                    {
                        end = end.AddDays(1);
                    }

                    return new[]
                    {
                        new CompiledScheduleTimeInterval(sch, start, end),
                        new CompiledScheduleTimeInterval(sch, start.AddDays(-1), end.AddDays(-1))
                    };
                })
                : new List<CompiledScheduleTimeInterval>();

            return weekly.Concat(single).Concat(daily).ToList();
        }

        private static DateTime CurrentWeekday(DateTime start, DayOfWeek day)
        {
            return start.Date.AddDays((int) day - (int) start.DayOfWeek);
        }
    }
}