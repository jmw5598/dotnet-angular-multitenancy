using System.ComponentModel.DataAnnotations;

namespace Xyz.Api.Models
{
    public class RegistrationUserAccountDto
    {
        [Required]
        public string UserName { get; set; } = default!;

        [Required]
        public string Password { get; set; } = default!;

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = default!;

        [Required]
        public RegistrationProfileDto Profile { get; set; } = default!;
    }
}
