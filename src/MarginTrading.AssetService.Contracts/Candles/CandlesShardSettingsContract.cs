// Copyright (c) 2019 Lykke Corp.
// See the LICENSE file in the project root for more information.

using JetBrains.Annotations;

namespace MarginTrading.AssetService.Contracts.Candles
{
    /// <summary>
    /// The candles publication shard settings
    /// </summary>
    [PublicAPI]
    public class CandlesShardSettingsContract
    {
        /// <summary>
        /// The name of the shard
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// The shard regular expression pattern
        /// </summary>
        public string Pattern { get; set; }
    }
}