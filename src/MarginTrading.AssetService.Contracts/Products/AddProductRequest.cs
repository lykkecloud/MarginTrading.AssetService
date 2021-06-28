using System;
using System.ComponentModel.DataAnnotations;
using MarginTrading.AssetService.Contracts.Core;

namespace MarginTrading.AssetService.Contracts.Products
{
    public class AddProductRequest : UserRequest
    {
        // primary id
        [Required]
        [MaxLength(100)]
        [RegularExpression("^[A-Za-z][A-Za-z0-9_]*$", ErrorMessage = "ProductId must contain only alphanumeric values and underscores and must start with a letter.")]
        public string ProductId { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string AssetType { get; set; }

        [Required]
        [MaxLength(100)]
        public string Category { get; set; }
        
        [MaxLength(100)]
        public string Comments { get; set; }
        
        public int ContractSize { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 12)]
        public string IsinLong { get; set; }
        
        [Required]
        [StringLength(12, MinimumLength = 12)]
        public string IsinShort { get; set; }
        
        [MaxLength(100)]
        public string Issuer { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Market { get; set; }
        
        [MaxLength(100)]
        public string MarketMakerAssetAccountId { get; set; }
        
        [Required]
        [Range(1, int.MaxValue)]
        public int MaxOrderSize { get; set; }
        
        [Required]
        [Range(1, int.MaxValue)]
        public int MinOrderSize { get; set; }
        
        [Required]
        [Range(1, int.MaxValue)]
        public int MaxPositionSize { get; set; }

        [Required]
        [Range(0, 100)]
        public decimal MinOrderDistancePercent { get; set; }
        
        [Required]
        public decimal MinOrderEntryInterval { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [MaxLength(100)]
        public string NewsId { get; set; }
        
        [MaxLength(100)]
        public string Keywords { get; set; }

        [Required]
        [MaxLength(100)]
        public string PublicationRic { get; set; }

        [MaxLength(100)]
        public string SettlementCurrency { get; set; }

        [Required]
        public bool ShortPosition { get; set; }

        [MaxLength(100)]
        public string Tags { get; set; }

        [Required]
        [MaxLength(100)]
        public string TickFormula { get; set; }

        // underlying primary id
        [Required]
        [MaxLength(100)]
        public string UnderlyingMdsCode { get; set; }

        [Required]
        [MaxLength(100)]
        public string ForceId { get; set; }

        [Required]
        public int Parity { get; set; }

        [Required]
        [Range(double.Epsilon, double.PositiveInfinity)]
        public decimal OvernightMarginMultiplier { get; set; }
        
        public DateTime? StartDate { get; set; }

        public decimal? DividendsLong { get; set; }

        public decimal? DividendsShort { get; set; }

        public decimal? Dividends871M { get; set; }

        [Required]
        public decimal HedgeCost { get; set; }

        public bool EnforceMargin { get; set; }

        [Range(0.01, 100)]
        public decimal? Margin { get; set; }
    }
}