﻿using System.Collections.Generic;
using MarginTrading.SettingsService.Core.Interfaces;
using Newtonsoft.Json;

namespace MarginTrading.SettingsService.SqlRepositories.Entities
{
    public class TradingConditionEntity : ITradingCondition
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LegalEntity { get; set; }
        public decimal MarginCall1 { get; set; }
        public decimal MarginCall2 { get; set; }
        public decimal StopOut { get; set; }
        public decimal DepositLimit { get; set; }
        public decimal WithdrawalLimit { get; set; }
        public string LimitCurrency { get; set; }
        List<string> ITradingCondition.BaseAssets => JsonConvert.DeserializeObject<List<string>>(BaseAssets); 
        public string BaseAssets { get; set; }
        public bool IsDefault { get; set; }
    }
}