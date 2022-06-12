namespace Xyz.Core.Dtos
{
    public class TenantDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = default!;
        public string DisplayName { get; set; } = default!;
        public bool IsActive { get; set; } = default!;
        public CompanyDto Company { get; set; } = default!;
        public TenantPlanDto? TenantPlan { get; set; } = default!;
    }
}