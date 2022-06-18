using System.ComponentModel.DataAnnotations.Schema;
using Xyz.Core.Models.Multitenancy;

using Xyz.Core.Dtos.Multitenancy;

namespace Xyz.Core.Entities.Multitenancy
{
    public class TenantPlan
    {
        public Guid Id { get; set; } = default!;

        [Column(TypeName = "varchar(24)")]
        public SubscriptionRenewalRate RenewalRate { get; set; } = default!;
        public int MaxUserCount { get; set; }

        public decimal Price { get; set; }

        public Tenant Tenant { get; set; } = default!;

        public Guid PlanId { get; set; } = default!;
        public virtual Plan? Plan { get; set; } = default!;

        public TenantPlanDto ToDto()
        {
            return new TenantPlanDto
            {
                Id = this.Id,
                RenewalRate = this.RenewalRate,
                MaxUserCount = this.MaxUserCount,
                Price = this.Price,
                Plan = this.Plan?.ToDto() ?? null
            };
        }
    }
}