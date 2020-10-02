using Lykke.MarginTrading.AssetService.Contracts.Common;
using Lykke.MarginTrading.AssetService.Contracts.ErrorCodes;

namespace Lykke.MarginTrading.AssetService.Contracts.ProductCategories
{
    public class GetProductCategoryByIdResponse : ErrorCodeResponse<ProductCategoriesErrorCodesContract>
    {
        public ProductCategoryContract ProductCategory { get; set; }
    }
}