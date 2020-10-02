using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Lykke.MarginTrading.AssetService.Contracts.ClientProfileSettings;
using Lykke.MarginTrading.AssetService.Contracts.Common;
using Lykke.MarginTrading.AssetService.Contracts.ErrorCodes;
using Refit;

namespace Lykke.MarginTrading.AssetService.Contracts
{
    public interface IClientProfileSettingsApi
    {
        /// <summary>
        /// Get client profile settings by ids
        /// </summary>
        /// <returns></returns>
        [Get("/api/client-profile-settings/profile/{profileId}/type/{typeId}")]
        Task<GetClientProfileSettingsByIdsResponse> GetClientProfileSettingsByIdsAsync(string profileId, string typeId);

        /// <summary>
        /// Get all client profile settings
        /// </summary>
        /// <returns></returns>
        [Get("/api/client-profile-settings")]
        Task<GetAllClientProfileSettingsResponse> GetClientProfileSettingsByRegulationAsync();

        /// <summary>
        /// Updates existing client settings
        /// </summary>
        /// <param name="request"></param>
        /// <param name="profileId"></param>
        /// <param name="typeId"></param>
        /// <returns></returns>
        [Put("/api/client-profile-settings/profile/{profileId}/type/{typeId}")]
        Task<ErrorCodeResponse<ClientProfilesErrorCodesContract>> UpdateClientProfileSettingsAsync(
            [Body] UpdateClientProfileSettingsRequest request, string profileId, string typeId);

        /// <summary>
        /// Check if changes in regulatory settings will violate constraints for any entity
        /// </summary>
        /// <returns></returns>
        [Get("/api/client-profile-settings/will-violate-regulation-constraint")]
        Task<bool> WillViolateRegulationConstraintAsync([Query] CheckRegulationConstraintViolationRequest request);
    }
}