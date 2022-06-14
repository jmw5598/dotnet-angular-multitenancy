using System.ComponentModel.DataAnnotations.Schema;

namespace Xyz.Core.Entities.Multitenancy
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
    }
}