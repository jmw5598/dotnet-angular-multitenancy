using System.ComponentModel.DataAnnotations;

namespace Xyz.Api.Models
{
    public class RegistrationProfileDto
    {
        [Required]
        public string FirstName { get; set; } = default!;

        [Required]
        public string LastName { get; set; } = default!;
    }
}
