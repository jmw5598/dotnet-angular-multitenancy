using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

using Xyz.Core.Models.Multitenancy;
using Xyz.Core.Dtos.Multitenancy;

namespace Xyz.Core.Entities.Multitenancy
{
    [Index(nameof(ExternalPlanId), IsUnique = true)]
    public class Plan
    {
        public Guid Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public Boolean PaymentRequired { get; set; } = true;

        [Column(TypeName = "varchar(24)")]
        public SubscriptionRenewalRate RenewalRate { get; set; } = default!;
        public int MaxUserCount { get; set; }

        [Column(TypeName = "varchar(256)")]
        public string? ExternalPlanId { get; set; } = default!;

        public PlanDto ToDto()
        {
            return new PlanDto
            {
                Id = this.Id,
                Name = this.Name,
                Price = this.Price,
                PaymentRequired = this.PaymentRequired,
                RenewalRate = this.RenewalRate,
                MaxUserCount = this.MaxUserCount,
                ExternalPlanId = this.ExternalPlanId
            };
        }
    }
}
