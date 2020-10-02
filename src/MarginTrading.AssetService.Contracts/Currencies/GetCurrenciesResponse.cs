using System.Collections.Generic;

namespace Lykke.MarginTrading.AssetService.Contracts.Currencies
{
    public class GetCurrenciesResponse
    {
        public IReadOnlyList<CurrencyContract> Currencies { get; set; }
    }
}