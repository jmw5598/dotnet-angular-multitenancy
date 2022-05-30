using System.ComponentModel.DataAnnotations.Schema;

using Xyz.Core.Entities.Identity;

namespace Xyz.Core.Entities.Tenant
{
    public abstract class BaseEntity
    {
        [Column(Order=0)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column(Order=1)]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        [Column(Order=2)]
        public DateTime UpdatedOn { get; set; } = DateTime.UtcNow;

        [Column(Order=3)]
        public DateTime? DeleteOn { get; set; } = null;

        [Column(Order=4)]
        public Guid CreatedById { get; set; } = default!;
        public virtual ApplicationUser CreatedBy { get; set; } = default!;

        [Column(Order=5)]
        public Guid UpdatedById { get; set; } = default!;
        public virtual ApplicationUser UpdatedBy { get; set; } = default!;
    }
}