using Xyz.Core.Entities.Multitenancy;

namespace Xyz.Core.Interfaces
{
    public interface IPlansService
    {
        Task<IEnumerable<Plan>> FindAll();
    }
}