using Lykke.MarginTrading.AssetService.Contracts.Common;
using Lykke.MarginTrading.AssetService.Contracts.ErrorCodes;

namespace Lykke.MarginTrading.AssetService.Contracts.Products
{
    public class GetProductByIdResponse : ErrorCodeResponse<ProductsErrorCodesContract>
    {
        public ProductContract Product { get; set; }
    }
}