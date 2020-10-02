using System.Threading.Tasks;
using Lykke.MarginTrading.AssetService.Contracts.Common;
using Lykke.MarginTrading.AssetService.Contracts.Currencies;
using Lykke.MarginTrading.AssetService.Contracts.ErrorCodes;
using Refit;

namespace Lykke.MarginTrading.AssetService.Contracts
{
    public interface ICurrenciesApi
    {
        [Post("/api/currencies")]
        Task<ErrorCodeResponse<CurrenciesErrorCodesContract>> AddAsync([Body] AddCurrencyRequest request);

        [Put("/api/currencies/{id}")]
        Task<ErrorCodeResponse<CurrenciesErrorCodesContract>> UpdateAsync(string id, [Body] UpdateCurrencyRequest request);

        [Delete("/api/currencies/{id}")]
        Task<ErrorCodeResponse<CurrenciesErrorCodesContract>> DeleteAsync(string id, [Body] DeleteCurrencyRequest request);

        [Get("/api/currencies/{id}")]
        Task<GetCurrencyByIdResponse> GetByIdAsync(string id);
        
        [Get("/api/currencies")]
        Task<GetCurrenciesResponse> GetAllAsync([Query] int skip = 0, [Query] int take = 0);
    }
}