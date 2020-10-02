using System.ComponentModel.DataAnnotations;
using Lykke.MarginTrading.AssetService.Contracts.Core;

namespace Lykke.MarginTrading.AssetService.Contracts.ProductCategories
{
    public class AddProductCategoryRequest : UserRequest
    {
        [Required]
        [MaxLength(100)]
        public string Category { get; set; }
    }
}