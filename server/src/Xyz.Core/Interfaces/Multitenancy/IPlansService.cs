using Xyz.Core.Entities.Multitenancy;

namespace Xyz.Core.Interfaces.Multitenancy
{
    public interface IPlansService
    {
        Task<IEnumerable<Plan>> FindAllAsync();
    }
}