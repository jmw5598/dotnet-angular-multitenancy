using Microsoft.AspNetCore.Identity;

namespace Xyz.Core.Entities.Multitenancy
{
    public class ApplicationRole : IdentityRole<Guid>
    {
       public ICollection<ApplicationUser> Users { get; set; } = default!; 
    }
}