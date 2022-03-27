using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Multitenancy.Migrations
{
    public partial class AddsRelationshipsBetweenMultitenancyEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("1d865752-1435-4676-b533-307095b165fe"), new Guid("462a12cd-42c8-4fa1-9ce3-327466e1d084") });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("503ae32a-3bb9-45f3-8f01-45195b6aa121"), new Guid("462a12cd-42c8-4fa1-9ce3-327466e1d084") });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("da821245-d08c-4e6a-90dd-07896de4459d"), new Guid("462a12cd-42c8-4fa1-9ce3-327466e1d084") });

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("b0452734-e4f4-4e1d-bc3a-2ed0063c538a"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("1d865752-1435-4676-b533-307095b165fe"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("503ae32a-3bb9-45f3-8f01-45195b6aa121"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("da821245-d08c-4e6a-90dd-07896de4459d"));

            migrationBuilder.DeleteData(
                table: "asp_net_users",
                keyColumn: "id",
                keyValue: new Guid("462a12cd-42c8-4fa1-9ce3-327466e1d084"));

            migrationBuilder.AddColumn<Guid>(
                name: "company_id",
                table: "tenants",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "is_configured",
                table: "tenants",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "tenant_plan_id",
                table: "tenants",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "profile_id",
                table: "asp_net_users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "tenant_plans",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    renewal_rate = table.Column<int>(type: "integer", nullable: false),
                    max_user_count = table.Column<int>(type: "integer", nullable: false),
                    plan_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tenant_plans", x => x.id);
                    table.ForeignKey(
                        name: "fk_tenant_plans_plans_plan_id",
                        column: x => x.plan_id,
                        principalTable: "plans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "asp_net_roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { new Guid("20c936a7-0ab6-430b-bcbc-15362ba45808"), "dbbf4423-a93e-455b-9f19-55eb13908096", "USER", "USER" },
                    { new Guid("75fed01f-5c19-4096-8456-42f719d90d88"), "f97943aa-7e4d-467e-afd0-9bf7799ca229", "ADMIN", "ADMIN" },
                    { new Guid("e867a550-0005-4c1e-9dee-0218d5d54797"), "a60bd53b-c6de-4641-9e94-f3dac561cba4", "ROOT", "ROOT" }
                });

            migrationBuilder.InsertData(
                table: "plans",
                columns: new[] { "id", "max_user_count", "name", "price", "renewal_rate" },
                values: new object[] { new Guid("d8be4922-8d65-4b56-9025-e24bf3078f55"), 5, "Free", 0.00m, "MONTHLY" });

            migrationBuilder.InsertData(
                table: "profiles",
                columns: new[] { "id", "first_name", "last_name" },
                values: new object[] { new Guid("b381a0f0-2e01-4f20-8061-faae22ebfe9d"), "Jason", "White" });

            migrationBuilder.InsertData(
                table: "asp_net_users",
                columns: new[] { "id", "access_failed_count", "concurrency_stamp", "email", "email_confirmed", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "profile_id", "security_stamp", "two_factor_enabled", "user_name" },
                values: new object[] { new Guid("80291800-b6d8-4a45-b232-19328efb0ca5"), 0, "93e55adb-53ec-4337-aaf2-6f154af16dd1", "jmw5598@gmail.com", true, false, null, "JMW5598@gmail.com", "JMW5598@GMAIL.COM", "AQAAAAEAACcQAAAAEBVC/Lmw0gXhsLSdegSSdV9dDu1Ce6lh7L4h4BNADzI0odlnh3uU/Bt6X9gUhcxUCw==", null, false, new Guid("b381a0f0-2e01-4f20-8061-faae22ebfe9d"), null, false, "jmw5598@gmail.com" });

            migrationBuilder.InsertData(
                table: "asp_net_user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("20c936a7-0ab6-430b-bcbc-15362ba45808"), new Guid("80291800-b6d8-4a45-b232-19328efb0ca5") },
                    { new Guid("75fed01f-5c19-4096-8456-42f719d90d88"), new Guid("80291800-b6d8-4a45-b232-19328efb0ca5") },
                    { new Guid("e867a550-0005-4c1e-9dee-0218d5d54797"), new Guid("80291800-b6d8-4a45-b232-19328efb0ca5") }
                });

            migrationBuilder.CreateIndex(
                name: "ix_tenants_company_id",
                table: "tenants",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_tenants_tenant_plan_id",
                table: "tenants",
                column: "tenant_plan_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_users_profile_id",
                table: "asp_net_users",
                column: "profile_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_tenant_plans_plan_id",
                table: "tenant_plans",
                column: "plan_id");

            migrationBuilder.AddForeignKey(
                name: "fk_asp_net_users_profiles_profile_id",
                table: "asp_net_users",
                column: "profile_id",
                principalTable: "profiles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_tenants_companies_company_id",
                table: "tenants",
                column: "company_id",
                principalTable: "companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_tenants_tenant_plans_tenant_plan_id",
                table: "tenants",
                column: "tenant_plan_id",
                principalTable: "tenant_plans",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_asp_net_users_profiles_profile_id",
                table: "asp_net_users");

            migrationBuilder.DropForeignKey(
                name: "fk_tenants_companies_company_id",
                table: "tenants");

            migrationBuilder.DropForeignKey(
                name: "fk_tenants_tenant_plans_tenant_plan_id",
                table: "tenants");

            migrationBuilder.DropTable(
                name: "tenant_plans");

            migrationBuilder.DropIndex(
                name: "ix_tenants_company_id",
                table: "tenants");

            migrationBuilder.DropIndex(
                name: "ix_tenants_tenant_plan_id",
                table: "tenants");

            migrationBuilder.DropIndex(
                name: "ix_asp_net_users_profile_id",
                table: "asp_net_users");

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("20c936a7-0ab6-430b-bcbc-15362ba45808"), new Guid("80291800-b6d8-4a45-b232-19328efb0ca5") });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("75fed01f-5c19-4096-8456-42f719d90d88"), new Guid("80291800-b6d8-4a45-b232-19328efb0ca5") });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("e867a550-0005-4c1e-9dee-0218d5d54797"), new Guid("80291800-b6d8-4a45-b232-19328efb0ca5") });

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("d8be4922-8d65-4b56-9025-e24bf3078f55"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("20c936a7-0ab6-430b-bcbc-15362ba45808"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("75fed01f-5c19-4096-8456-42f719d90d88"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("e867a550-0005-4c1e-9dee-0218d5d54797"));

            migrationBuilder.DeleteData(
                table: "asp_net_users",
                keyColumn: "id",
                keyValue: new Guid("80291800-b6d8-4a45-b232-19328efb0ca5"));

            migrationBuilder.DeleteData(
                table: "profiles",
                keyColumn: "id",
                keyValue: new Guid("b381a0f0-2e01-4f20-8061-faae22ebfe9d"));

            migrationBuilder.DropColumn(
                name: "company_id",
                table: "tenants");

            migrationBuilder.DropColumn(
                name: "is_configured",
                table: "tenants");

            migrationBuilder.DropColumn(
                name: "tenant_plan_id",
                table: "tenants");

            migrationBuilder.DropColumn(
                name: "profile_id",
                table: "asp_net_users");

            migrationBuilder.InsertData(
                table: "asp_net_roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { new Guid("1d865752-1435-4676-b533-307095b165fe"), "36e57d73-258f-4329-8d35-89edd9acf08b", "ROOT", "ROOT" },
                    { new Guid("503ae32a-3bb9-45f3-8f01-45195b6aa121"), "8adfae93-f815-4b27-aa6d-76deb86ab7eb", "USER", "USER" },
                    { new Guid("da821245-d08c-4e6a-90dd-07896de4459d"), "3337431a-f85c-4b60-a356-a6380c914444", "ADMIN", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "asp_net_users",
                columns: new[] { "id", "access_failed_count", "concurrency_stamp", "email", "email_confirmed", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "security_stamp", "two_factor_enabled", "user_name" },
                values: new object[] { new Guid("462a12cd-42c8-4fa1-9ce3-327466e1d084"), 0, "5d3f8342-6291-40b6-825f-3ee59f5417c1", "jmw5598@gmail.com", true, false, null, "JMW5598@gmail.com", "JMW5598@GMAIL.COM", "AQAAAAEAACcQAAAAEJm4TBn1NdhqWZw28vg47ZaGaJ2Bd8nKPmOhxgK6qnQO0iBxbSbCfS9tSN76pABQqA==", null, false, null, false, "jmw5598@gmail.com" });

            migrationBuilder.InsertData(
                table: "plans",
                columns: new[] { "id", "max_user_count", "name", "price", "renewal_rate" },
                values: new object[] { new Guid("b0452734-e4f4-4e1d-bc3a-2ed0063c538a"), 5, "Free", 0.00m, "MONTHLY" });

            migrationBuilder.InsertData(
                table: "asp_net_user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("1d865752-1435-4676-b533-307095b165fe"), new Guid("462a12cd-42c8-4fa1-9ce3-327466e1d084") },
                    { new Guid("503ae32a-3bb9-45f3-8f01-45195b6aa121"), new Guid("462a12cd-42c8-4fa1-9ce3-327466e1d084") },
                    { new Guid("da821245-d08c-4e6a-90dd-07896de4459d"), new Guid("462a12cd-42c8-4fa1-9ce3-327466e1d084") }
                });
        }
    }
}
