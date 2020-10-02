// Copyright (c) 2019 Lykke Corp.
// See the LICENSE file in the project root for more information.

using MessagePack;

namespace Lykke.MarginTrading.AssetService.Contracts.AssetPair
{
    [MessagePackObject]
    public class SuspendAssetPairCommand
    {
        [Key(0)]
        public string OperationId { get; set; }
        
        [Key(1)]
        public string AssetPairId { get; set; }
    }
}