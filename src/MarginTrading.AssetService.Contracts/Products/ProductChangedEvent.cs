using Lykke.MarginTrading.AssetService.Contracts.Common;
using MessagePack;

namespace Lykke.MarginTrading.AssetService.Contracts.Products
{
    [MessagePackObject]
    public class ProductChangedEvent : EntityChangedEvent<ProductContract>
    {
    }
}