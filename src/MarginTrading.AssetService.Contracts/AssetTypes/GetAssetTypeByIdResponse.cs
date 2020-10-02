using Lykke.MarginTrading.AssetService.Contracts.Common;
using Lykke.MarginTrading.AssetService.Contracts.ErrorCodes;

namespace Lykke.MarginTrading.AssetService.Contracts.AssetTypes
{
    /// <summary>
    /// Response model to get AssetType by ID
    /// </summary>
    public class GetAssetTypeByIdResponse : ErrorCodeResponse<ClientProfilesErrorCodesContract>
    {
        /// <summary>
        /// Asset type model
        /// </summary>
        public AssetTypeContract AssetType { get; set; }
    }
}