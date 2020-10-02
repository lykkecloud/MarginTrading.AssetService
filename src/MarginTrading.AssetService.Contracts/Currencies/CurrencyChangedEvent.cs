using Lykke.MarginTrading.AssetService.Contracts.Common;
using MessagePack;

namespace Lykke.MarginTrading.AssetService.Contracts.Currencies
{
    [MessagePackObject]
    public class CurrencyChangedEvent : EntityChangedEvent<CurrencyContract>
    {
    }
}