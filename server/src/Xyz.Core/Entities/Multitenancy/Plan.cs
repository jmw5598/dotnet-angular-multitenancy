using System.ComponentModel.DataAnnotations.Schema;

using Xyz.Core.Models;
using Xyz.Core.Dtos;

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

        public PlanDto ToDto()
        {
            return new PlanDto
            {
                Id = this.Id,
                Name = this.Name,
                Price = this.Price,
                RenewalRate = this.RenewalRate,
                MaxUserCount = this.MaxUserCount
            };
        }
    }
}
