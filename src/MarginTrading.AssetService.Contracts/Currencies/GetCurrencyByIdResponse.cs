using Lykke.MarginTrading.AssetService.Contracts.Common;
using Lykke.MarginTrading.AssetService.Contracts.ErrorCodes;

namespace Lykke.MarginTrading.AssetService.Contracts.Currencies
{
    public class GetCurrencyByIdResponse : ErrorCodeResponse<CurrenciesErrorCodesContract>
    {
        public CurrencyContract Currency { get; set; }
    }
}