using System.Collections.Generic;

namespace Lykke.MarginTrading.AssetService.Contracts.ProductCategories
{
    public class GetProductCategoriesResponse
    {
        public IReadOnlyList<ProductCategoryContract> ProductCategories { get; set; }
    }
}