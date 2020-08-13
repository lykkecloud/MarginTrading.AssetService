﻿using System;

namespace MarginTrading.AssetService.SqlRepositories.Entities
{
    public class BrokerRegulatorySettingsEntity
    {
        public Guid BrokerProfileId { get; set; }
        public BrokerRegulatoryProfileEntity BrokerProfile { get; set; }
        public Guid BrokerTypeId { get; set; }
        public BrokerRegulatoryTypeEntity BrokerType { get; set; }
        public decimal MarginMin { get; set; }
        public decimal ExecutionFeesFloor { get; set; }
        public decimal ExecutionFeesCap { get; set; }
        public decimal ExecutionFeesRate { get; set; }
        public decimal FinancingFeesRate { get; set; }
        public decimal PhoneFees { get; set; }
        public bool IsAvailable { get; set; }
    }
}