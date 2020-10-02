using Lykke.MarginTrading.AssetService.Contracts.Common;
using Lykke.MarginTrading.AssetService.Contracts.ErrorCodes;

namespace Lykke.MarginTrading.AssetService.Contracts.ClientProfileSettings
{
    /// <summary>
    /// Response model to get client profile settings by ids
    /// </summary>
    public class GetClientProfileSettingsByIdsResponse : ErrorCodeResponse<ClientProfilesErrorCodesContract>
    {
        /// <summary>
        /// Client profile settings
        /// </summary>
        public ClientProfileSettingsContract ClientProfileSettings { get; set; }
    }
}