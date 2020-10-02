using JetBrains.Annotations;
using Lykke.MarginTrading.AssetService.Contracts.Common;
using MessagePack;

namespace Lykke.MarginTrading.AssetService.Contracts.ProductCategories
{
    [MessagePackObject]
    public class ProductCategoryChangedEvent : EntityChangedEvent<ProductCategoryContract>
    {
        /// <summary>
        /// Unformatted category name, only filled on create events
        /// </summary>
        [Key(7)]
        [CanBeNull]
        public string OriginalCategoryName { get; set; }
    }
}