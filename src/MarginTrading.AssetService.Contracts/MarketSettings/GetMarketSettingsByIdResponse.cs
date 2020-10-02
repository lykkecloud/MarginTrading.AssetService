// Copyright (c) 2020 Lykke Corp.
// See the LICENSE file in the project root for more information.

using Lykke.MarginTrading.AssetService.Contracts.Common;
using Lykke.MarginTrading.AssetService.Contracts.ErrorCodes;

namespace Lykke.MarginTrading.AssetService.Contracts.MarketSettings
{
    /// <summary>
    /// Response model to get market settings by ids
    /// </summary>
    public class GetMarketSettingsByIdResponse : ErrorCodeResponse<MarketSettingsErrorCodesContract>
    {
        /// <summary>
        /// MarketSettings
        /// </summary>
        public MarketSettingsContract MarketSettings { get; set; }
    }
}