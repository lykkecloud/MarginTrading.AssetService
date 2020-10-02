using System.ComponentModel.DataAnnotations;
using Lykke.MarginTrading.AssetService.Contracts.Common;

namespace Lykke.MarginTrading.AssetService.Contracts.Currencies
{
    public class UpdateCurrencyRequest : UserRequest
    {
        [Required]
        public string InterestRateMdsCode  { get; set; }
    }
}