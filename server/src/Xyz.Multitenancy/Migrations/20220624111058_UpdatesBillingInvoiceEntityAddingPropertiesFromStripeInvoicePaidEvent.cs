using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Multitenancy.Migrations
{
    public partial class UpdatesBillingInvoiceEntityAddingPropertiesFromStripeInvoicePaidEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "id",
                keyValue: new Guid("6eaad41b-f1fe-4a9b-921f-7d413bc8155b"));

            migrationBuilder.DeleteData(
                table: "companies",
                keyColumn: "id",
                keyValue: new Guid("e256b5db-244f-4220-bfaa-4ec2df8245ae"));

            migrationBuilder.DeleteData(
                table: "tenant_plans",
                keyColumn: "id",
                keyValue: new Guid("f6dff289-8af1-402f-a0c1-d12425aa9d84"));

            migrationBuilder.RenameColumn(
                name: "external_transaction_id",
                table: "billing_invoices",
                newName: "external_invoice_id");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "billing_invoices",
                newName: "amount_paid");

            migrationBuilder.RenameIndex(
                name: "ix_billing_invoices_external_transaction_id",
                table: "billing_invoices",
                newName: "ix_billing_invoices_external_invoice_id");

            migrationBuilder.AddColumn<decimal>(
                name: "amount_due",
                table: "billing_invoices",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "billing_reason",
                table: "billing_invoices",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "invoice_pdf_url",
                table: "billing_invoices",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "invoice_url",
                table: "billing_invoices",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "paid_date",
                table: "billing_invoices",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "period_end_date",
                table: "billing_invoices",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "period_start_date",
                table: "billing_invoices",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "amount_due",
                table: "billing_invoices");

            migrationBuilder.DropColumn(
                name: "billing_reason",
                table: "billing_invoices");

            migrationBuilder.DropColumn(
                name: "invoice_pdf_url",
                table: "billing_invoices");

            migrationBuilder.DropColumn(
                name: "invoice_url",
                table: "billing_invoices");

            migrationBuilder.DropColumn(
                name: "paid_date",
                table: "billing_invoices");

            migrationBuilder.DropColumn(
                name: "period_end_date",
                table: "billing_invoices");

            migrationBuilder.DropColumn(
                name: "period_start_date",
                table: "billing_invoices");

            migrationBuilder.RenameColumn(
                name: "external_invoice_id",
                table: "billing_invoices",
                newName: "external_transaction_id");

            migrationBuilder.RenameColumn(
                name: "amount_paid",
                table: "billing_invoices",
                newName: "amount");

            migrationBuilder.RenameIndex(
                name: "ix_billing_invoices_external_invoice_id",
                table: "billing_invoices",
                newName: "ix_billing_invoices_external_transaction_id");

            migrationBuilder.InsertData(
                table: "companies",
                columns: new[] { "id", "external_customer_id", "name" },
                values: new object[] { new Guid("e256b5db-244f-4220-bfaa-4ec2df8245ae"), null, "Localhost" });

            migrationBuilder.InsertData(
                table: "tenant_plans",
                columns: new[] { "id", "max_user_count", "plan_id", "price", "renewal_rate" },
                values: new object[] { new Guid("f6dff289-8af1-402f-a0c1-d12425aa9d84"), 2, new Guid("81048da5-948f-4304-a5b2-908ac1ee44b7"), 0.00m, "MONTHLY" });

            migrationBuilder.InsertData(
                table: "tenants",
                columns: new[] { "id", "company_id", "connection_string", "display_name", "domain_names", "guid", "ip_addresses", "is_active", "is_configured", "name", "payment_details_id", "tenant_plan_id" },
                values: new object[] { new Guid("6eaad41b-f1fe-4a9b-921f-7d413bc8155b"), new Guid("e256b5db-244f-4220-bfaa-4ec2df8245ae"), "Server=localhost;Port=5432;Database=xyz_localhost_company;User Id=xyz;Password=password;", "Localhost", "", "53e72ab1-3d7d-4560-a575-2af570c12d9b", "", false, false, "localhost", null, new Guid("f6dff289-8af1-402f-a0c1-d12425aa9d84") });
        }
    }
}
