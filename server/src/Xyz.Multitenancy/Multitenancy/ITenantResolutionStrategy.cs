namespace Xyz.Multitenancy.Multitenancy
{
    public interface ITenantResolutionStrategy
    {
        Task<(string domainName, string ipAddresss, string name)> GetTenantIdentifierAsync();
    }
}
