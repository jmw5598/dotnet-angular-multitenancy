using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Multitenancy.Migrations
{
    public partial class AddsPaymentRequiredPropertyToPlansEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("eaeb5455-d1c0-49cf-99ee-a24364babe23"));

            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "id",
                keyValue: new Guid("d3251f41-a601-41fc-b77b-29806107352f"));

            migrationBuilder.DeleteData(
                table: "companies",
                keyColumn: "id",
                keyValue: new Guid("f9d180c4-cf23-41be-a467-25b88b67cbd0"));

            migrationBuilder.DeleteData(
                table: "tenant_plans",
                keyColumn: "id",
                keyValue: new Guid("642682f4-23c5-48db-8d74-81a473507284"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("4d46efc2-2687-4b68-ac82-65bd5803eeac"));

            migrationBuilder.AddColumn<bool>(
                name: "payment_required",
                table: "plans",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "companies",
                columns: new[] { "id", "name" },
                values: new object[] { new Guid("1a822cf8-3d21-40cc-b53c-3f38bc3b3dcb"), "Localhost" });

            migrationBuilder.InsertData(
                table: "plans",
                columns: new[] { "id", "max_user_count", "name", "payment_required", "price", "renewal_rate" },
                values: new object[,]
                {
                    { new Guid("81048da5-948f-4304-a5b2-908ac1ee44b7"), 2, "Free", false, 0.00m, "MONTHLY" },
                    { new Guid("81048da5-948f-4304-a5b2-908ac1ee44b8"), 5, "Basic", true, 10.00m, "MONTHLY" },
                    { new Guid("81048da5-948f-4304-a5b2-908ac1ee44b9"), 100, "Pro", true, 100.00m, "MONTHLY" }
                });

            migrationBuilder.InsertData(
                table: "tenant_plans",
                columns: new[] { "id", "max_user_count", "plan_id", "price", "renewal_rate" },
                values: new object[] { new Guid("5c39622f-6844-438e-80a8-63dcae27b4ab"), 2, new Guid("81048da5-948f-4304-a5b2-908ac1ee44b7"), 0.00m, "MONTHLY" });

            migrationBuilder.InsertData(
                table: "tenants",
                columns: new[] { "id", "company_id", "connection_string", "display_name", "domain_names", "guid", "ip_addresses", "is_active", "is_configured", "name", "tenant_plan_id" },
                values: new object[] { new Guid("34f7467e-88cf-4442-b5fa-e3ae91bc4f67"), new Guid("1a822cf8-3d21-40cc-b53c-3f38bc3b3dcb"), "Server=localhost;Port=5432;Database=xyz_localhost_company;User Id=xyz;Password=password;", "Localhost", "", "a49a0d0e-1483-4109-b245-886657fce67a", "", false, false, "localhost", new Guid("5c39622f-6844-438e-80a8-63dcae27b4ab") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("81048da5-948f-4304-a5b2-908ac1ee44b8"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("81048da5-948f-4304-a5b2-908ac1ee44b9"));

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

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("81048da5-948f-4304-a5b2-908ac1ee44b7"));

            migrationBuilder.DropColumn(
                name: "payment_required",
                table: "plans");

            migrationBuilder.InsertData(
                table: "companies",
                columns: new[] { "id", "name" },
                values: new object[] { new Guid("f9d180c4-cf23-41be-a467-25b88b67cbd0"), "Localhost" });

            migrationBuilder.InsertData(
                table: "plans",
                columns: new[] { "id", "max_user_count", "name", "price", "renewal_rate" },
                values: new object[,]
                {
                    { new Guid("4d46efc2-2687-4b68-ac82-65bd5803eeac"), 10, "Basic", 0m, "MONTHLY" },
                    { new Guid("eaeb5455-d1c0-49cf-99ee-a24364babe23"), 5, "Free", 0.00m, "MONTHLY" }
                });

            migrationBuilder.InsertData(
                table: "tenant_plans",
                columns: new[] { "id", "max_user_count", "plan_id", "price", "renewal_rate" },
                values: new object[] { new Guid("642682f4-23c5-48db-8d74-81a473507284"), 10, new Guid("4d46efc2-2687-4b68-ac82-65bd5803eeac"), 0m, "MONTHLY" });

            migrationBuilder.InsertData(
                table: "tenants",
                columns: new[] { "id", "company_id", "connection_string", "display_name", "domain_names", "guid", "ip_addresses", "is_active", "is_configured", "name", "tenant_plan_id" },
                values: new object[] { new Guid("d3251f41-a601-41fc-b77b-29806107352f"), new Guid("f9d180c4-cf23-41be-a467-25b88b67cbd0"), "Server=localhost;Port=5432;Database=xyz_localhost_company;User Id=xyz;Password=password;", "Localhost", "", "3cc2caa4-7a1a-471b-8f50-b317ce8456fb", "", false, false, "localhost", new Guid("642682f4-23c5-48db-8d74-81a473507284") });
        }
    }
}
