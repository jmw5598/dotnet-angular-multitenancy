using System.ComponentModel.DataAnnotations.Schema;

using Xyz.Core.Models;

namespace Xyz.Core.Entities.Tenant
{
    public class Permission
    {
        public Guid Id { get; set; }
        
        [Column(TypeName = "varchar(24)")]
        public ModulePermissionType Type { get; set; }
        public string Name { get; set; } = default!;
    }
}
