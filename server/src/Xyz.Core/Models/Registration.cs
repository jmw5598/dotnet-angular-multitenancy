using Xyz.Core.Entities.Multitenancy;
using Xyz.Core.Entities.Identity;

namespace Xyz.Core.Models
{
    public class Registration 
    {
        public ApplicationUser User { get; set; } = default!;
        public Profile Profile { get; set; } = default!;
        public Company Company { get; set; } = default!;
        public Plan Plan { get; set; } = default!;
        public PaymentDetails? PaymentDetails { get; set; } = default!;
        public string Subdomain { get; set; } = default!;
        public string RawPassword { get; set; } = default!;
    }
}
