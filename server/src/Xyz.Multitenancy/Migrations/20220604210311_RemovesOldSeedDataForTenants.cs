using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Multitenancy.Migrations
{
    public partial class RemovesOldSeedDataForTenants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("2c5cc718-f1b5-4aca-8981-7edcd3fd20db"));

            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "id",
                keyValue: new Guid("6516c72c-f91c-4e87-ae92-98c027382324"));

            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "id",
                keyValue: new Guid("d9d0883f-4811-4d28-a51d-758a68884be3"));

            migrationBuilder.DeleteData(
                table: "companies",
                keyColumn: "id",
                keyValue: new Guid("06bfbbb9-c844-4b50-bbf6-205f12964e3f"));

            migrationBuilder.DeleteData(
                table: "companies",
                keyColumn: "id",
                keyValue: new Guid("0a91c6b3-3e16-4727-b022-9a0d5e55e67b"));

            migrationBuilder.DeleteData(
                table: "tenant_plans",
                keyColumn: "id",
                keyValue: new Guid("488e506a-9a2c-4fb5-a619-87fb0b799d23"));

            migrationBuilder.DeleteData(
                table: "tenant_plans",
                keyColumn: "id",
                keyValue: new Guid("5337e10a-4aaf-477e-92c8-a36b13352134"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("3f803de8-5d65-42c1-ba0d-92f0619fa83b"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("af461e08-d478-4737-8eb5-aac64d2f252c"));

            migrationBuilder.InsertData(
                table: "plans",
                columns: new[] { "id", "max_user_count", "name", "price", "renewal_rate" },
                values: new object[] { new Guid("25f8070c-d033-45a7-8dfd-aea879d89b3a"), 5, "Free", 0.00m, "MONTHLY" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("25f8070c-d033-45a7-8dfd-aea879d89b3a"));

            migrationBuilder.InsertData(
                table: "companies",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("06bfbbb9-c844-4b50-bbf6-205f12964e3f"), "Localhost" },
                    { new Guid("0a91c6b3-3e16-4727-b022-9a0d5e55e67b"), "Dev Company" }
                });

            migrationBuilder.InsertData(
                table: "plans",
                columns: new[] { "id", "max_user_count", "name", "price", "renewal_rate" },
                values: new object[,]
                {
                    { new Guid("2c5cc718-f1b5-4aca-8981-7edcd3fd20db"), 5, "Free", 0.00m, "MONTHLY" },
                    { new Guid("3f803de8-5d65-42c1-ba0d-92f0619fa83b"), 5, "Localhost Dev Plan", 0m, "MONTHLY" },
                    { new Guid("af461e08-d478-4737-8eb5-aac64d2f252c"), 5, "Dev", 0m, "MONTHLY" }
                });

            migrationBuilder.InsertData(
                table: "tenant_plans",
                columns: new[] { "id", "max_user_count", "plan_id", "price", "renewal_rate" },
                values: new object[,]
                {
                    { new Guid("488e506a-9a2c-4fb5-a619-87fb0b799d23"), 5, new Guid("3f803de8-5d65-42c1-ba0d-92f0619fa83b"), 0m, "MONTHLY" },
                    { new Guid("5337e10a-4aaf-477e-92c8-a36b13352134"), 5, new Guid("af461e08-d478-4737-8eb5-aac64d2f252c"), 0m, "MONTHLY" }
                });

            migrationBuilder.InsertData(
                table: "tenants",
                columns: new[] { "id", "company_id", "connection_string", "display_name", "domain_names", "guid", "ip_addresses", "is_active", "is_configured", "name", "tenant_plan_id" },
                values: new object[,]
                {
                    { new Guid("6516c72c-f91c-4e87-ae92-98c027382324"), new Guid("06bfbbb9-c844-4b50-bbf6-205f12964e3f"), "Server=localhost;Port=5432;Database=xyz_localhost_company;User Id=xyz;Password=password;", "Localhost", "", "cf4a21ee-9e49-4e39-8f02-9e28d32e1fde", "", false, false, "localhost", new Guid("488e506a-9a2c-4fb5-a619-87fb0b799d23") },
                    { new Guid("d9d0883f-4811-4d28-a51d-758a68884be3"), new Guid("0a91c6b3-3e16-4727-b022-9a0d5e55e67b"), "Server=localhost;Port=5432;Database=xyz_dev_company;User Id=xyz;Password=password;", "Dev Company", "", "92558851-fb0e-4616-898d-85857fc4016c", "", true, true, "devcompany", new Guid("5337e10a-4aaf-477e-92c8-a36b13352134") }
                });
        }
    }
}
