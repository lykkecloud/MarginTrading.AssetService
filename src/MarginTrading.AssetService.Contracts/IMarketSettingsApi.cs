// Copyright (c) 2020 Lykke Corp.
// See the LICENSE file in the project root for more information.

using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Lykke.MarginTrading.AssetService.Contracts.Common;
using Lykke.MarginTrading.AssetService.Contracts.ErrorCodes;
using Lykke.MarginTrading.AssetService.Contracts.MarketSettings;
using Refit;

namespace Lykke.MarginTrading.AssetService.Contracts
{
    /// <summary>
    /// Api for market settings
    /// </summary>
    public interface IMarketSettingsApi
    {
        /// <summary>
        /// Get market settings by id
        /// </summary>
        /// <returns></returns>
        [Get("/api/market-settings/{id}")]
        Task<GetMarketSettingsByIdResponse> GetByIdAsync(string id);

        /// <summary>
        /// Get all market settings
        /// </summary>
        /// <returns></returns>
        [Get("/api/market-settings")]
        Task<GetAllMarketSettingsResponse> GetAllMarketSettingsAsync();

        /// <summary>
        /// Add market settings
        /// </summary>
        /// <returns></returns>
        [Post("/api/market-settings")]
        Task<ErrorCodeResponse<MarketSettingsErrorCodesContract>> AddMarketSettingsAsync(
            [Body] AddMarketSettingsRequest request);

        /// <summary>
        /// Update market settings
        /// </summary>
        /// <returns></returns>
        [Put("/api/market-settings/{id}")]
        Task<ErrorCodeResponse<MarketSettingsErrorCodesContract>> UpdateMarketSettingsAsync(
            [Body] UpdateMarketSettingsRequest request, [Required] string id);

        /// <summary>
        /// Delete market settings
        /// </summary>
        /// <returns></returns>
        [Delete("/api/market-settings/{id}")]
        Task<ErrorCodeResponse<MarketSettingsErrorCodesContract>> DeleteMarketSettingsAsync(
            [Required] string id, [Query] [Required] string username);
    }
}