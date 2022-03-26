using System.ComponentModel.DataAnnotations;

namespace Xyz.Api.Models
{
    public class LoginRequestDto
    {
        [Required]
        [EmailAddress]
        public string UserName { get; set; } = default!;
        [Required]
        public string Password { get; set; } = default!;
    }
}
