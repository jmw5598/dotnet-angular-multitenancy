using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Multitenancy.Migrations
{
    public partial class InitialBillingInvoicesEntitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "billing_invoices",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    delete_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    transaction_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    status = table.Column<string>(type: "varchar(24)", nullable: false),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_billing_invoices", x => x.id);
                    table.ForeignKey(
                        name: "fk_billing_invoices_tenants_tenant_id",
                        column: x => x.tenant_id,
                        principalTable: "tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "ix_billing_invoices_tenant_id",
                table: "billing_invoices",
                column: "tenant_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "billing_invoices");

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
    }
}
