using System.ComponentModel.DataAnnotations;

namespace Xyz.Api.Models
{
    public class RegistrationPlanDto
    {
        [Required]
        public string Id { get; set; } = default!;
    }
}
