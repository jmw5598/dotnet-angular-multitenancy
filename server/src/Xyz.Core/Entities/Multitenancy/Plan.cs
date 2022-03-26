using System.ComponentModel.DataAnnotations.Schema;

using Xyz.Core.Models;

namespace Xyz.Core.Entities.Multitenancy
{
    public class Plan
    {
        public Guid Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }

        [Column(TypeName = "varchar(24)")]
        public SubscriptionRenewalRate RenewalRate { get; set; } = default!;
        public int MaxUserCount { get; set; }
    }
}
