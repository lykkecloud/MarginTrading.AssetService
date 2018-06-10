﻿using System;
using System.Data;
using MarginTrading.SettingsService.Core.Domain;
using MarginTrading.SettingsService.Core.Interfaces;

namespace MarginTrading.SettingsService.AzureRepositories.Entities
{
    public class AssetPairEntity : SimpleAzureEntity, IAssetPair
    {
        public static readonly string Pk = "AssetPairs"; 
        internal override string SimplePartitionKey => Pk;
        
        // Id comes from parent type
        public string Name { get; set; }
        public string BaseAssetId { get; set; }
        public string QuoteAssetId { get; set; }
        public int Accuracy { get; set; }
        public string MarketId { get; set; }
        public string LegalEntity { get; set; }
        public string BasePairId { get; set; }
        MatchingEngineMode IAssetPair.MatchingEngineMode => Enum.Parse<MatchingEngineMode>(MatchingEngineMode);
        public string MatchingEngineMode { get; set; }
        public decimal StpMultiplierMarkupBid { get; set; }
        public decimal StpMultiplierMarkupAsk { get; set; }
    }
}