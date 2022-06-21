using System.ComponentModel.DataAnnotations;

namespace Xyz.Api.Models
{
    public class RegistrationPaymentDetailsDto
    {
        [Required]
        public string FirstName { get; set; } = default!;

        [Required]
        public string LastName { get; set; } = default!;

        [Required]
        public string Address { get; set; } = default!;

        [Required]
        public string City { get; set; } = default!;

        [Required]
        public string State { get; set; } = default!;

        [Required]
        public string Zip { get; set; } = default!;

        [Required]
        public RegistrationCardDetailsDto CardDetails { get; set; } = default!;
    }
}
