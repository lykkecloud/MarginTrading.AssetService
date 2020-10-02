using Lykke.MarginTrading.AssetService.Contracts.Common;
using MessagePack;

namespace Lykke.MarginTrading.AssetService.Contracts.TickFormula
{
    [MessagePackObject]
    public class TickFormulaChangedEvent : EntityChangedEvent<TickFormulaContract>
    {
    }
}