using System.Collections.Generic;

namespace Lykke.MarginTrading.AssetService.Contracts.Products
{
    public class GetProductsResponse
    {
        public IReadOnlyList<ProductContract> Products { get; set; }
    }
}