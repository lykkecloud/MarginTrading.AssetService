using Lykke.MarginTrading.AssetService.Contracts.Common;
using MessagePack;

namespace Lykke.MarginTrading.AssetService.Contracts.ClientProfiles
{
    [MessagePackObject]
    public class ClientProfileChangedEvent : EntityChangedEvent<ClientProfileContract>
    {
    }
}