using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Multitenancy.Migrations
{
    public partial class UpdatesPaidDateOnBillingInvoiceToBeNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "id",
                keyValue: new Guid("16762b1b-ac07-405b-ab25-bd8c24802a20"));

            migrationBuilder.DeleteData(
                table: "companies",
                keyColumn: "id",
                keyValue: new Guid("a947ca34-848b-4464-9a1b-8db4ffd1643d"));

            migrationBuilder.DeleteData(
                table: "tenant_plans",
                keyColumn: "id",
                keyValue: new Guid("e201b019-adbe-4bd7-bb91-d2fe6cb213c1"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "paid_date",
                table: "billing_invoices",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.InsertData(
                table: "companies",
                columns: new[] { "id", "external_customer_id", "name" },
                values: new object[] { new Guid("1853ecf6-5273-4190-852f-7deb338edcd7"), null, "Localhost" });

            migrationBuilder.InsertData(
                table: "tenant_plans",
                columns: new[] { "id", "max_user_count", "plan_id", "price", "renewal_rate" },
                values: new object[] { new Guid("d687edcb-68de-49f2-ae55-081e962d2a6e"), 2, new Guid("81048da5-948f-4304-a5b2-908ac1ee44b7"), 0.00m, "MONTHLY" });

            migrationBuilder.InsertData(
                table: "tenants",
                columns: new[] { "id", "company_id", "connection_string", "display_name", "domain_names", "guid", "ip_addresses", "is_active", "is_configured", "name", "payment_details_id", "tenant_plan_id" },
                values: new object[] { new Guid("1d9466ad-61e8-4890-8edc-9d89218135c0"), new Guid("1853ecf6-5273-4190-852f-7deb338edcd7"), "Server=localhost;Port=5432;Database=xyz_localhost_company;User Id=xyz;Password=password;", "Localhost", "", "fb86c89b-f310-4180-8fd2-d85e22f64b8f", "", false, false, "localhost", null, new Guid("d687edcb-68de-49f2-ae55-081e962d2a6e") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "id",
                keyValue: new Guid("1d9466ad-61e8-4890-8edc-9d89218135c0"));

            migrationBuilder.DeleteData(
                table: "companies",
                keyColumn: "id",
                keyValue: new Guid("1853ecf6-5273-4190-852f-7deb338edcd7"));

            migrationBuilder.DeleteData(
                table: "tenant_plans",
                keyColumn: "id",
                keyValue: new Guid("d687edcb-68de-49f2-ae55-081e962d2a6e"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "paid_date",
                table: "billing_invoices",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "companies",
                columns: new[] { "id", "external_customer_id", "name" },
                values: new object[] { new Guid("a947ca34-848b-4464-9a1b-8db4ffd1643d"), null, "Localhost" });

            migrationBuilder.InsertData(
                table: "tenant_plans",
                columns: new[] { "id", "max_user_count", "plan_id", "price", "renewal_rate" },
                values: new object[] { new Guid("e201b019-adbe-4bd7-bb91-d2fe6cb213c1"), 2, new Guid("81048da5-948f-4304-a5b2-908ac1ee44b7"), 0.00m, "MONTHLY" });

            migrationBuilder.InsertData(
                table: "tenants",
                columns: new[] { "id", "company_id", "connection_string", "display_name", "domain_names", "guid", "ip_addresses", "is_active", "is_configured", "name", "payment_details_id", "tenant_plan_id" },
                values: new object[] { new Guid("16762b1b-ac07-405b-ab25-bd8c24802a20"), new Guid("a947ca34-848b-4464-9a1b-8db4ffd1643d"), "Server=localhost;Port=5432;Database=xyz_localhost_company;User Id=xyz;Password=password;", "Localhost", "", "afa60b82-55f1-48e4-a88c-9081dfe42558", "", false, false, "localhost", null, new Guid("e201b019-adbe-4bd7-bb91-d2fe6cb213c1") });
        }
    }
}
