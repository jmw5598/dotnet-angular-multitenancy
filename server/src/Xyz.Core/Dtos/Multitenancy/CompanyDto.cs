namespace Xyz.Core.Dtos
{
    public class CompanyDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = default!;
    }
}