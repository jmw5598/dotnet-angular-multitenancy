using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Multitenancy.Migrations
{
    public partial class AddsProperRelationshipMappingsForCustomerApplicationUserAndRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "application_role_application_user");

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("05be0cbf-d84d-4250-a0cb-8d017a9243b5"), new Guid("c23385ff-a02f-4bfc-aa84-df2bc3740c27") });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("63cf9bd0-e57e-42e3-8f4e-c0db0bfcfcc3"), new Guid("c23385ff-a02f-4bfc-aa84-df2bc3740c27") });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("78464a8f-315a-44c7-96b2-09857d9403db"), new Guid("c23385ff-a02f-4bfc-aa84-df2bc3740c27") });

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("2f1f267e-2334-44b2-923f-d184acb6e9f4"));

            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "id",
                keyValue: new Guid("767ccfec-6e23-4a5a-b9ec-ac163d025eb9"));

            migrationBuilder.DeleteData(
                table: "user_tenants",
                keyColumns: new[] { "asp_net_user_id", "tenant_id" },
                keyValues: new object[] { new Guid("c23385ff-a02f-4bfc-aa84-df2bc3740c27"), new Guid("057a6a02-a460-4ba8-9fb1-bf3bd8e27fe8") });

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("05be0cbf-d84d-4250-a0cb-8d017a9243b5"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("63cf9bd0-e57e-42e3-8f4e-c0db0bfcfcc3"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("78464a8f-315a-44c7-96b2-09857d9403db"));

            migrationBuilder.DeleteData(
                table: "asp_net_users",
                keyColumn: "id",
                keyValue: new Guid("c23385ff-a02f-4bfc-aa84-df2bc3740c27"));

            migrationBuilder.DeleteData(
                table: "companies",
                keyColumn: "id",
                keyValue: new Guid("44042aa3-a23b-4ad9-be8d-6d66ea23156d"));

            migrationBuilder.DeleteData(
                table: "tenant_plans",
                keyColumn: "id",
                keyValue: new Guid("5643a3f6-adae-4a65-89b0-52f68feb416d"));

            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "id",
                keyValue: new Guid("057a6a02-a460-4ba8-9fb1-bf3bd8e27fe8"));

            migrationBuilder.DeleteData(
                table: "companies",
                keyColumn: "id",
                keyValue: new Guid("0d216c40-37bc-46d1-8c2e-7afb0e622023"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("08e7c3a4-e5a5-4523-bd03-3539149e9f93"));

            migrationBuilder.DeleteData(
                table: "profiles",
                keyColumn: "id",
                keyValue: new Guid("3acc15b4-dd8e-4dfe-96b9-1d12d1a860de"));

            migrationBuilder.DeleteData(
                table: "tenant_plans",
                keyColumn: "id",
                keyValue: new Guid("8dd6aeda-f626-480e-9fa4-cb7c64492c3b"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("1efcd623-69f9-4296-8a79-fa7536734964"));

            migrationBuilder.InsertData(
                table: "asp_net_roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { new Guid("0db7deec-9ab0-4a6a-b44a-5cff0f028db5"), "029632df-06a8-4e0b-aa36-d6a50480d859", "ADMIN", "ADMIN" },
                    { new Guid("9f22eab1-9b43-4b91-9ab1-e94a0129e6ad"), "60f2d4fd-8177-4bde-a289-16e5c860e114", "ROOT", "ROOT" },
                    { new Guid("f0dafa3d-22e0-4d5a-b17a-675832754a37"), "a34c2b4a-8114-4d3e-be07-8307dd536f3c", "USER", "USER" }
                });

            migrationBuilder.InsertData(
                table: "companies",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("e77083cd-0b25-49ad-9d46-3d52e154f7af"), "Dev Company" },
                    { new Guid("f028abad-6240-4614-90dd-3987343c8b55"), "Localhost" }
                });

            migrationBuilder.InsertData(
                table: "plans",
                columns: new[] { "id", "max_user_count", "name", "price", "renewal_rate" },
                values: new object[,]
                {
                    { new Guid("0c6aa9b2-4bb8-40b0-8040-1b382c08679e"), 5, "Dev", 0m, "MONTHLY" },
                    { new Guid("82b9acec-ce7c-4982-b4b8-6c97a4d2e691"), 5, "Localhost Dev Plan", 0m, "MONTHLY" },
                    { new Guid("980e101e-517a-47e3-9776-b957c0d4cdc8"), 5, "Free", 0.00m, "MONTHLY" }
                });

            migrationBuilder.InsertData(
                table: "profiles",
                columns: new[] { "id", "first_name", "last_name" },
                values: new object[] { new Guid("0c72fc2e-f24b-4382-b720-eadc337fcee7"), "Jason", "White" });

            migrationBuilder.InsertData(
                table: "asp_net_users",
                columns: new[] { "id", "access_failed_count", "concurrency_stamp", "email", "email_confirmed", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "profile_id", "security_stamp", "two_factor_enabled", "user_name" },
                values: new object[] { new Guid("ab0e1522-27ab-4a18-921e-e763a93d7212"), 0, "b0d5ad44-1c0c-4d3d-b0e7-0d5bb656a71b", "jmw5598@gmail.com", true, false, null, "JMW5598@gmail.com", "JMW5598@GMAIL.COM", "AQAAAAEAACcQAAAAEOF2VDmkhJX59h99+xjitHSyRPk5Yjhv4EJ9VEyyB2zLh9Ob36dzUDGXa9c6oIQBXA==", null, false, new Guid("0c72fc2e-f24b-4382-b720-eadc337fcee7"), null, false, "jmw5598@gmail.com" });

            migrationBuilder.InsertData(
                table: "tenant_plans",
                columns: new[] { "id", "max_user_count", "plan_id", "price", "renewal_rate" },
                values: new object[,]
                {
                    { new Guid("93c762ed-8bc3-4cc2-aef6-e4b82647cde8"), 5, new Guid("82b9acec-ce7c-4982-b4b8-6c97a4d2e691"), 0m, "MONTHLY" },
                    { new Guid("e066c269-5895-4d89-ba89-266f12e011f5"), 5, new Guid("0c6aa9b2-4bb8-40b0-8040-1b382c08679e"), 0m, "MONTHLY" }
                });

            migrationBuilder.InsertData(
                table: "asp_net_user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("0db7deec-9ab0-4a6a-b44a-5cff0f028db5"), new Guid("ab0e1522-27ab-4a18-921e-e763a93d7212") },
                    { new Guid("9f22eab1-9b43-4b91-9ab1-e94a0129e6ad"), new Guid("ab0e1522-27ab-4a18-921e-e763a93d7212") },
                    { new Guid("f0dafa3d-22e0-4d5a-b17a-675832754a37"), new Guid("ab0e1522-27ab-4a18-921e-e763a93d7212") }
                });

            migrationBuilder.InsertData(
                table: "tenants",
                columns: new[] { "id", "company_id", "connection_string", "display_name", "domain_names", "guid", "ip_addresses", "is_active", "is_configured", "name", "tenant_plan_id" },
                values: new object[,]
                {
                    { new Guid("7dca1b51-adab-4337-8199-b6b04f040f48"), new Guid("f028abad-6240-4614-90dd-3987343c8b55"), "Server=localhost;Port=5432;Database=xyz_localhost_company;User Id=xyz;Password=password;", "Localhost", "", "093eea5a-c4a9-4e72-8de0-b0eba3d916ce", "", false, false, "localhost", new Guid("93c762ed-8bc3-4cc2-aef6-e4b82647cde8") },
                    { new Guid("c37dab57-8165-4961-be18-8b01ba5353be"), new Guid("e77083cd-0b25-49ad-9d46-3d52e154f7af"), "Server=localhost;Port=5432;Database=xyz_dev_company;User Id=xyz;Password=password;", "Dev Company", "", "ab914af2-6458-4e87-9219-4cd01d5d223f", "", true, true, "devcompany", new Guid("e066c269-5895-4d89-ba89-266f12e011f5") }
                });

            migrationBuilder.InsertData(
                table: "user_tenants",
                columns: new[] { "asp_net_user_id", "tenant_id" },
                values: new object[] { new Guid("ab0e1522-27ab-4a18-921e-e763a93d7212"), new Guid("c37dab57-8165-4961-be18-8b01ba5353be") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("0db7deec-9ab0-4a6a-b44a-5cff0f028db5"), new Guid("ab0e1522-27ab-4a18-921e-e763a93d7212") });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("9f22eab1-9b43-4b91-9ab1-e94a0129e6ad"), new Guid("ab0e1522-27ab-4a18-921e-e763a93d7212") });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("f0dafa3d-22e0-4d5a-b17a-675832754a37"), new Guid("ab0e1522-27ab-4a18-921e-e763a93d7212") });

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("980e101e-517a-47e3-9776-b957c0d4cdc8"));

            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "id",
                keyValue: new Guid("7dca1b51-adab-4337-8199-b6b04f040f48"));

            migrationBuilder.DeleteData(
                table: "user_tenants",
                keyColumns: new[] { "asp_net_user_id", "tenant_id" },
                keyValues: new object[] { new Guid("ab0e1522-27ab-4a18-921e-e763a93d7212"), new Guid("c37dab57-8165-4961-be18-8b01ba5353be") });

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("0db7deec-9ab0-4a6a-b44a-5cff0f028db5"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("9f22eab1-9b43-4b91-9ab1-e94a0129e6ad"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("f0dafa3d-22e0-4d5a-b17a-675832754a37"));

            migrationBuilder.DeleteData(
                table: "asp_net_users",
                keyColumn: "id",
                keyValue: new Guid("ab0e1522-27ab-4a18-921e-e763a93d7212"));

            migrationBuilder.DeleteData(
                table: "companies",
                keyColumn: "id",
                keyValue: new Guid("f028abad-6240-4614-90dd-3987343c8b55"));

            migrationBuilder.DeleteData(
                table: "tenant_plans",
                keyColumn: "id",
                keyValue: new Guid("93c762ed-8bc3-4cc2-aef6-e4b82647cde8"));

            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "id",
                keyValue: new Guid("c37dab57-8165-4961-be18-8b01ba5353be"));

            migrationBuilder.DeleteData(
                table: "companies",
                keyColumn: "id",
                keyValue: new Guid("e77083cd-0b25-49ad-9d46-3d52e154f7af"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("82b9acec-ce7c-4982-b4b8-6c97a4d2e691"));

            migrationBuilder.DeleteData(
                table: "profiles",
                keyColumn: "id",
                keyValue: new Guid("0c72fc2e-f24b-4382-b720-eadc337fcee7"));

            migrationBuilder.DeleteData(
                table: "tenant_plans",
                keyColumn: "id",
                keyValue: new Guid("e066c269-5895-4d89-ba89-266f12e011f5"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("0c6aa9b2-4bb8-40b0-8040-1b382c08679e"));

            migrationBuilder.CreateTable(
                name: "application_role_application_user",
                columns: table => new
                {
                    roles_id = table.Column<Guid>(type: "uuid", nullable: false),
                    users_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_application_role_application_user", x => new { x.roles_id, x.users_id });
                    table.ForeignKey(
                        name: "fk_application_role_application_user_roles_roles_id",
                        column: x => x.roles_id,
                        principalTable: "asp_net_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_application_role_application_user_users_users_id",
                        column: x => x.users_id,
                        principalTable: "asp_net_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "asp_net_roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { new Guid("05be0cbf-d84d-4250-a0cb-8d017a9243b5"), "c61c5e2d-65d6-4ce6-b00a-67519345e39e", "USER", "USER" },
                    { new Guid("63cf9bd0-e57e-42e3-8f4e-c0db0bfcfcc3"), "605e8865-1ef3-4ae6-8a61-bc079fa24df4", "ROOT", "ROOT" },
                    { new Guid("78464a8f-315a-44c7-96b2-09857d9403db"), "f685c989-882c-412b-8937-5f6918f453f8", "ADMIN", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "companies",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("0d216c40-37bc-46d1-8c2e-7afb0e622023"), "Dev Company" },
                    { new Guid("44042aa3-a23b-4ad9-be8d-6d66ea23156d"), "Localhost" }
                });

            migrationBuilder.InsertData(
                table: "plans",
                columns: new[] { "id", "max_user_count", "name", "price", "renewal_rate" },
                values: new object[,]
                {
                    { new Guid("08e7c3a4-e5a5-4523-bd03-3539149e9f93"), 5, "Localhost Dev Plan", 0m, "MONTHLY" },
                    { new Guid("1efcd623-69f9-4296-8a79-fa7536734964"), 5, "Dev", 0m, "MONTHLY" },
                    { new Guid("2f1f267e-2334-44b2-923f-d184acb6e9f4"), 5, "Free", 0.00m, "MONTHLY" }
                });

            migrationBuilder.InsertData(
                table: "profiles",
                columns: new[] { "id", "first_name", "last_name" },
                values: new object[] { new Guid("3acc15b4-dd8e-4dfe-96b9-1d12d1a860de"), "Jason", "White" });

            migrationBuilder.InsertData(
                table: "asp_net_users",
                columns: new[] { "id", "access_failed_count", "concurrency_stamp", "email", "email_confirmed", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "profile_id", "security_stamp", "two_factor_enabled", "user_name" },
                values: new object[] { new Guid("c23385ff-a02f-4bfc-aa84-df2bc3740c27"), 0, "24ab860a-2d42-4118-8488-2959e52d226c", "jmw5598@gmail.com", true, false, null, "JMW5598@gmail.com", "JMW5598@GMAIL.COM", "AQAAAAEAACcQAAAAEIv7M8AvO2cdGekH8wsVmOd9l2flhu57hYyrbImDKOlZZtl/urL2XiktlUj37IxhpQ==", null, false, new Guid("3acc15b4-dd8e-4dfe-96b9-1d12d1a860de"), null, false, "jmw5598@gmail.com" });

            migrationBuilder.InsertData(
                table: "tenant_plans",
                columns: new[] { "id", "max_user_count", "plan_id", "price", "renewal_rate" },
                values: new object[,]
                {
                    { new Guid("5643a3f6-adae-4a65-89b0-52f68feb416d"), 5, new Guid("08e7c3a4-e5a5-4523-bd03-3539149e9f93"), 0m, "MONTHLY" },
                    { new Guid("8dd6aeda-f626-480e-9fa4-cb7c64492c3b"), 5, new Guid("1efcd623-69f9-4296-8a79-fa7536734964"), 0m, "MONTHLY" }
                });

            migrationBuilder.InsertData(
                table: "asp_net_user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("05be0cbf-d84d-4250-a0cb-8d017a9243b5"), new Guid("c23385ff-a02f-4bfc-aa84-df2bc3740c27") },
                    { new Guid("63cf9bd0-e57e-42e3-8f4e-c0db0bfcfcc3"), new Guid("c23385ff-a02f-4bfc-aa84-df2bc3740c27") },
                    { new Guid("78464a8f-315a-44c7-96b2-09857d9403db"), new Guid("c23385ff-a02f-4bfc-aa84-df2bc3740c27") }
                });

            migrationBuilder.InsertData(
                table: "tenants",
                columns: new[] { "id", "company_id", "connection_string", "display_name", "domain_names", "guid", "ip_addresses", "is_active", "is_configured", "name", "tenant_plan_id" },
                values: new object[,]
                {
                    { new Guid("057a6a02-a460-4ba8-9fb1-bf3bd8e27fe8"), new Guid("0d216c40-37bc-46d1-8c2e-7afb0e622023"), "Server=localhost;Port=5432;Database=xyz_dev_company;User Id=xyz;Password=password;", "Dev Company", "", "68d8721d-0be0-4a7b-bf2f-0e25cc42f946", "", true, true, "devcompany", new Guid("8dd6aeda-f626-480e-9fa4-cb7c64492c3b") },
                    { new Guid("767ccfec-6e23-4a5a-b9ec-ac163d025eb9"), new Guid("44042aa3-a23b-4ad9-be8d-6d66ea23156d"), "Server=localhost;Port=5432;Database=xyz_localhost_company;User Id=xyz;Password=password;", "Localhost", "", "72049296-7de4-4176-a8e3-221e50bb8235", "", false, false, "localhost", new Guid("5643a3f6-adae-4a65-89b0-52f68feb416d") }
                });

            migrationBuilder.InsertData(
                table: "user_tenants",
                columns: new[] { "asp_net_user_id", "tenant_id" },
                values: new object[] { new Guid("c23385ff-a02f-4bfc-aa84-df2bc3740c27"), new Guid("057a6a02-a460-4ba8-9fb1-bf3bd8e27fe8") });

            migrationBuilder.CreateIndex(
                name: "ix_application_role_application_user_users_id",
                table: "application_role_application_user",
                column: "users_id");
        }
    }
}
