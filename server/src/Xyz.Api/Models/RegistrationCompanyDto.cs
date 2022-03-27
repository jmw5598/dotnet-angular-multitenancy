using System.ComponentModel.DataAnnotations;

namespace Xyz.Api.Models
{
    public class RegistrationCompanyDto
    {
        [Required]
        public string Name { get; set; } = default!;
    }
}
