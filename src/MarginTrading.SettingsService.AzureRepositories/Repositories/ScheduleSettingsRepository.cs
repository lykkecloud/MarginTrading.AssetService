﻿using Common.Log;
using Lykke.SettingsReader;
using MarginTrading.SettingsService.AzureRepositories.Entities;
using MarginTrading.SettingsService.Core.Domain;
using MarginTrading.SettingsService.Core.Services;
using MarginTrading.SettingsService.StorageInterfaces.Repositories;

namespace MarginTrading.SettingsService.AzureRepositories.Repositories
{
    public class ScheduleSettingsRepository : GenericAzureCrudRepository<ScheduleSettings, ScheduleSettingsEntity>, 
        IScheduleSettingsRepository
    {
        public ScheduleSettingsRepository(ILog log,
            IConvertService convertService,
            IReloadingManager<string> connectionStringManager)
            : base(log, convertService, connectionStringManager, "ScheduleSettings")
        {

        }
    }
}