using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Multitenancy.Migrations
{
    public partial class AddsExternalPlanIdPropertyToPlanEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "id",
                keyValue: new Guid("34f7467e-88cf-4442-b5fa-e3ae91bc4f67"));

            migrationBuilder.DeleteData(
                table: "companies",
                keyColumn: "id",
                keyValue: new Guid("1a822cf8-3d21-40cc-b53c-3f38bc3b3dcb"));

            migrationBuilder.DeleteData(
                table: "tenant_plans",
                keyColumn: "id",
                keyValue: new Guid("5c39622f-6844-438e-80a8-63dcae27b4ab"));

            migrationBuilder.AddColumn<string>(
                name: "external_plan_id",
                table: "plans",
                type: "varchar(256)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "companies",
                columns: new[] { "id", "name" },
                values: new object[] { new Guid("b03339c7-4f2a-471a-97e9-aedac9ce2b74"), "Localhost" });

            migrationBuilder.InsertData(
                table: "tenant_plans",
                columns: new[] { "id", "max_user_count", "plan_id", "price", "renewal_rate" },
                values: new object[] { new Guid("e0690465-7749-4c4e-a40f-ac6970270045"), 2, new Guid("81048da5-948f-4304-a5b2-908ac1ee44b7"), 0.00m, "MONTHLY" });

            migrationBuilder.InsertData(
                table: "tenants",
                columns: new[] { "id", "company_id", "connection_string", "display_name", "domain_names", "guid", "ip_addresses", "is_active", "is_configured", "name", "tenant_plan_id" },
                values: new object[] { new Guid("e9effde3-7bcb-432f-82b6-230430f5ce4c"), new Guid("b03339c7-4f2a-471a-97e9-aedac9ce2b74"), "Server=localhost;Port=5432;Database=xyz_localhost_company;User Id=xyz;Password=password;", "Localhost", "", "52dbdfe0-84a5-44a6-b139-44b4b3cce8e5", "", false, false, "localhost", new Guid("e0690465-7749-4c4e-a40f-ac6970270045") });

            migrationBuilder.CreateIndex(
                name: "ix_plans_external_plan_id",
                table: "plans",
                column: "external_plan_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_plans_external_plan_id",
                table: "plans");

            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "id",
                keyValue: new Guid("e9effde3-7bcb-432f-82b6-230430f5ce4c"));

            migrationBuilder.DeleteData(
                table: "companies",
                keyColumn: "id",
                keyValue: new Guid("b03339c7-4f2a-471a-97e9-aedac9ce2b74"));

            migrationBuilder.DeleteData(
                table: "tenant_plans",
                keyColumn: "id",
                keyValue: new Guid("e0690465-7749-4c4e-a40f-ac6970270045"));

            migrationBuilder.DropColumn(
                name: "external_plan_id",
                table: "plans");

            migrationBuilder.InsertData(
                table: "companies",
                columns: new[] { "id", "name" },
                values: new object[] { new Guid("1a822cf8-3d21-40cc-b53c-3f38bc3b3dcb"), "Localhost" });

            migrationBuilder.InsertData(
                table: "tenant_plans",
                columns: new[] { "id", "max_user_count", "plan_id", "price", "renewal_rate" },
                values: new object[] { new Guid("5c39622f-6844-438e-80a8-63dcae27b4ab"), 2, new Guid("81048da5-948f-4304-a5b2-908ac1ee44b7"), 0.00m, "MONTHLY" });

            migrationBuilder.InsertData(
                table: "tenants",
                columns: new[] { "id", "company_id", "connection_string", "display_name", "domain_names", "guid", "ip_addresses", "is_active", "is_configured", "name", "tenant_plan_id" },
                values: new object[] { new Guid("34f7467e-88cf-4442-b5fa-e3ae91bc4f67"), new Guid("1a822cf8-3d21-40cc-b53c-3f38bc3b3dcb"), "Server=localhost;Port=5432;Database=xyz_localhost_company;User Id=xyz;Password=password;", "Localhost", "", "a49a0d0e-1483-4109-b245-886657fce67a", "", false, false, "localhost", new Guid("5c39622f-6844-438e-80a8-63dcae27b4ab") });
        }
    }
}
