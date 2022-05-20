using System.ComponentModel.DataAnnotations;

namespace Xyz.Api.Models
{
    public class UpdateUserDto
    {
        [Required]
        public Guid Id { get; set; } = default!;

        [Required]
        public RegistrationProfileDto Profile { get; set; } = default!;    
    }
}

