using System.ComponentModel.DataAnnotations;

namespace Lykke.MarginTrading.AssetService.Contracts.Core
{
    public class UserRequest
    {
        /// <summary>
        /// Name of the user who sent the request
        /// </summary>
        [Required]
        public string UserName { get; set; }
    }
}