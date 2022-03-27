using System.ComponentModel.DataAnnotations;

namespace Xyz.Api.Models
{
    public class RegistrationDto
    {
        [Required]
        public RegistrationUserDto User { get; set; } = null!;

        [Required]
        public RegistrationProfileDto Profile { get; set; } = null!;

        [Required]
        public RegistrationCompanyDto Company { get; set; } = null!;

        [Required]
        public RegistrationPlanDto Plan { get; set; } = null!;
    }
}
