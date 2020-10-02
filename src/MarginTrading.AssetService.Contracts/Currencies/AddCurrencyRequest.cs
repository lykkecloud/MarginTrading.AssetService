using System.ComponentModel.DataAnnotations;
using Lykke.MarginTrading.AssetService.Contracts.Common;

namespace Lykke.MarginTrading.AssetService.Contracts.Currencies
{
    public class AddCurrencyRequest : UserRequest
    {
        [Required]
        [MaxLength(100)]
        public string Id { get; set; }
        [Required]
        public string InterestRateMdsCode  { get; set; }
    }
}