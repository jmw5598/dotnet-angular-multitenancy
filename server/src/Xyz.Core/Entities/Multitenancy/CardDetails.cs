using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Xyz.Core.Entities.Multitenancy
{
    [Index(nameof(ExternalDefaultPaymentSourceId), IsUnique = true)]
    public class CardDetails : BaseEntity
    {
        public bool IsValid { get; set; } = false!;
        public string Brand { get; set; } = default!;
        public string Token { get; set; } = default!;

        [Column(TypeName = "varchar(256)")]
        public string? ExternalDefaultPaymentSourceId { get; set; } = default!;
    }
}
