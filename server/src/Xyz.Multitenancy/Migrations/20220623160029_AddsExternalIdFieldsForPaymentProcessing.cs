using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Multitenancy.Migrations
{
    public partial class AddsExternalIdFieldsForPaymentProcessing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "id",
                keyValue: new Guid("4b3c1264-c6ce-4732-8d81-3a52245fa7e2"));

            migrationBuilder.DeleteData(
                table: "companies",
                keyColumn: "id",
                keyValue: new Guid("62630716-da8a-46c0-81f1-696bcb6b31f0"));

            migrationBuilder.DeleteData(
                table: "tenant_plans",
                keyColumn: "id",
                keyValue: new Guid("a3e6c03a-cbaa-4956-9be0-1ccb573980da"));

            migrationBuilder.AddColumn<string>(
                name: "external_subscription_id",
                table: "payment_details",
                type: "varchar(256)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "external_customer_id",
                table: "companies",
                type: "varchar(256)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "external_default_payment_source_id",
                table: "card_details",
                type: "varchar(256)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "external_transaction_id",
                table: "billing_invoices",
                type: "varchar(256)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "ix_payment_details_external_subscription_id",
                table: "payment_details",
                column: "external_subscription_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_companies_external_customer_id",
                table: "companies",
                column: "external_customer_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_card_details_external_default_payment_source_id",
                table: "card_details",
                column: "external_default_payment_source_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_billing_invoices_external_transaction_id",
                table: "billing_invoices",
                column: "external_transaction_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_payment_details_external_subscription_id",
                table: "payment_details");

            migrationBuilder.DropIndex(
                name: "ix_companies_external_customer_id",
                table: "companies");

            migrationBuilder.DropIndex(
                name: "ix_card_details_external_default_payment_source_id",
                table: "card_details");

            migrationBuilder.DropIndex(
                name: "ix_billing_invoices_external_transaction_id",
                table: "billing_invoices");

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

            migrationBuilder.DropColumn(
                name: "external_subscription_id",
                table: "payment_details");

            migrationBuilder.DropColumn(
                name: "external_customer_id",
                table: "companies");

            migrationBuilder.DropColumn(
                name: "external_default_payment_source_id",
                table: "card_details");

            migrationBuilder.DropColumn(
                name: "external_transaction_id",
                table: "billing_invoices");

            migrationBuilder.InsertData(
                table: "companies",
                columns: new[] { "id", "name" },
                values: new object[] { new Guid("62630716-da8a-46c0-81f1-696bcb6b31f0"), "Localhost" });

            migrationBuilder.InsertData(
                table: "tenant_plans",
                columns: new[] { "id", "max_user_count", "plan_id", "price", "renewal_rate" },
                values: new object[] { new Guid("a3e6c03a-cbaa-4956-9be0-1ccb573980da"), 2, new Guid("81048da5-948f-4304-a5b2-908ac1ee44b7"), 0.00m, "MONTHLY" });

            migrationBuilder.InsertData(
                table: "tenants",
                columns: new[] { "id", "company_id", "connection_string", "display_name", "domain_names", "guid", "ip_addresses", "is_active", "is_configured", "name", "payment_details_id", "tenant_plan_id" },
                values: new object[] { new Guid("4b3c1264-c6ce-4732-8d81-3a52245fa7e2"), new Guid("62630716-da8a-46c0-81f1-696bcb6b31f0"), "Server=localhost;Port=5432;Database=xyz_localhost_company;User Id=xyz;Password=password;", "Localhost", "", "98b4af39-e034-4d87-a2b4-532a1f3081e9", "", false, false, "localhost", null, new Guid("a3e6c03a-cbaa-4956-9be0-1ccb573980da") });
        }
    }
}
