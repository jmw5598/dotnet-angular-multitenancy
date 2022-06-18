namespace Xyz.Core.Dtos.Multitenancy
{
    public class CompanyDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = default!;
    }
}