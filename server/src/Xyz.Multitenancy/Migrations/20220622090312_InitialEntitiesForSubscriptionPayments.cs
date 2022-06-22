using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Multitenancy.Migrations
{
    public partial class InitialEntitiesForSubscriptionPayments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<Guid>(
                name: "payment_details_id",
                table: "tenants",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "card_details",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    delete_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_valid = table.Column<bool>(type: "boolean", nullable: false),
                    brand = table.Column<string>(type: "text", nullable: false),
                    token = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_card_details", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "payment_details",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    delete_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    state = table.Column<string>(type: "text", nullable: false),
                    zip = table.Column<string>(type: "text", nullable: false),
                    payment_processor = table.Column<string>(type: "varchar(24)", nullable: false),
                    card_details_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_payment_details", x => x.id);
                    table.ForeignKey(
                        name: "fk_payment_details_card_details_card_details_id",
                        column: x => x.card_details_id,
                        principalTable: "card_details",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "ix_tenants_payment_details_id",
                table: "tenants",
                column: "payment_details_id");

            migrationBuilder.CreateIndex(
                name: "ix_payment_details_card_details_id",
                table: "payment_details",
                column: "card_details_id");

            migrationBuilder.AddForeignKey(
                name: "fk_tenants_payment_details_payment_details_id",
                table: "tenants",
                column: "payment_details_id",
                principalTable: "payment_details",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_tenants_payment_details_payment_details_id",
                table: "tenants");

            migrationBuilder.DropTable(
                name: "payment_details");

            migrationBuilder.DropTable(
                name: "card_details");

            migrationBuilder.DropIndex(
                name: "ix_tenants_payment_details_id",
                table: "tenants");

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

            migrationBuilder.DropColumn(
                name: "payment_details_id",
                table: "tenants");

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
        }
    }
}
