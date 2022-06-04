using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Multitenancy.Migrations
{
    public partial class CreatesDevLoclhostTenantForLocalhostOnly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("25f8070c-d033-45a7-8dfd-aea879d89b3a"));

            migrationBuilder.InsertData(
                table: "companies",
                columns: new[] { "id", "name" },
                values: new object[] { new Guid("3b8ebd84-ad4c-4116-af4e-7e0f9a11e28c"), "Localhost" });

            migrationBuilder.InsertData(
                table: "plans",
                columns: new[] { "id", "max_user_count", "name", "price", "renewal_rate" },
                values: new object[,]
                {
                    { new Guid("a1d69718-49ec-40fd-8e56-dfde58939106"), 5, "Free", 0.00m, "MONTHLY" },
                    { new Guid("dae43468-feef-461c-92c8-700c544f7768"), 10, "Basic", 0m, "MONTHLY" }
                });

            migrationBuilder.InsertData(
                table: "tenant_plans",
                columns: new[] { "id", "max_user_count", "plan_id", "price", "renewal_rate" },
                values: new object[] { new Guid("bf8b3c2d-81f5-4337-a3de-1a785fa5998a"), 10, new Guid("dae43468-feef-461c-92c8-700c544f7768"), 0m, "MONTHLY" });

            migrationBuilder.InsertData(
                table: "tenants",
                columns: new[] { "id", "company_id", "connection_string", "display_name", "domain_names", "guid", "ip_addresses", "is_active", "is_configured", "name", "tenant_plan_id" },
                values: new object[] { new Guid("7ddd6135-04dd-4a3c-a212-f007d7403fb0"), new Guid("3b8ebd84-ad4c-4116-af4e-7e0f9a11e28c"), "Server=localhost;Port=5432;Database=xyz_localhost_company;User Id=xyz;Password=password;", "Localhost", "", "e379b848-2783-4251-9975-39bee96f5e1c", "", false, false, "localhost", new Guid("bf8b3c2d-81f5-4337-a3de-1a785fa5998a") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("a1d69718-49ec-40fd-8e56-dfde58939106"));

            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "id",
                keyValue: new Guid("7ddd6135-04dd-4a3c-a212-f007d7403fb0"));

            migrationBuilder.DeleteData(
                table: "companies",
                keyColumn: "id",
                keyValue: new Guid("3b8ebd84-ad4c-4116-af4e-7e0f9a11e28c"));

            migrationBuilder.DeleteData(
                table: "tenant_plans",
                keyColumn: "id",
                keyValue: new Guid("bf8b3c2d-81f5-4337-a3de-1a785fa5998a"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("dae43468-feef-461c-92c8-700c544f7768"));

            migrationBuilder.InsertData(
                table: "plans",
                columns: new[] { "id", "max_user_count", "name", "price", "renewal_rate" },
                values: new object[] { new Guid("25f8070c-d033-45a7-8dfd-aea879d89b3a"), 5, "Free", 0.00m, "MONTHLY" });
        }
    }
}
