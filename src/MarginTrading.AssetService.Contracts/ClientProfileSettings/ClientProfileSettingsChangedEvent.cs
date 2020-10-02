using Lykke.MarginTrading.AssetService.Contracts.Common;
using MessagePack;

namespace Lykke.MarginTrading.AssetService.Contracts.ClientProfileSettings
{
    [MessagePackObject]
    public class ClientProfileSettingsChangedEvent : EntityChangedEvent<ClientProfileSettingsContract>
    {
    }
}