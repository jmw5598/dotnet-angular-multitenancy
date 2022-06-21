using System.ComponentModel.DataAnnotations;

namespace Xyz.Api.Models
{
    public class RegistrationCardDetailsDto
    {
        [Required]
        public bool IsValid { get; set; } = false!;

        [Required]
        public string Brand { get; set; } = default!;

        [Required]
        public string Token { get; set; } = default!;
    }
}
