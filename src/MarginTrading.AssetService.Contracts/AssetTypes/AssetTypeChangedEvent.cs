using Lykke.MarginTrading.AssetService.Contracts.Common;
using MessagePack;

namespace Lykke.MarginTrading.AssetService.Contracts.AssetTypes
{
    [MessagePackObject]
    public class AssetTypeChangedEvent : EntityChangedEvent<AssetTypeContract>
    {
    }
}