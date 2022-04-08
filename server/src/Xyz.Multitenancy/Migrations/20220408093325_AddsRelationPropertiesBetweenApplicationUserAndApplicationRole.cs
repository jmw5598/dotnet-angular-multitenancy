using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Multitenancy.Migrations
{
    public partial class AddsRelationPropertiesBetweenApplicationUserAndApplicationRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("2fd64167-37e2-407f-a3e7-0115c22d0d58"), new Guid("56129b97-38e0-44e8-b723-490a4b1b94e5") });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("382c1b96-1305-499c-bd87-1b382bb20b28"), new Guid("56129b97-38e0-44e8-b723-490a4b1b94e5") });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("bf290349-d826-45ce-8325-f4e65f544254"), new Guid("56129b97-38e0-44e8-b723-490a4b1b94e5") });

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("12aed472-9d3f-474a-97cb-36e67b058001"));

            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "id",
                keyValue: new Guid("42abc90e-65b7-4aab-8795-c10c13a3bb23"));

            migrationBuilder.DeleteData(
                table: "user_tenants",
                keyColumns: new[] { "asp_net_user_id", "tenant_id" },
                keyValues: new object[] { new Guid("56129b97-38e0-44e8-b723-490a4b1b94e5"), new Guid("f16e781e-daca-4724-ab86-062210029054") });

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("2fd64167-37e2-407f-a3e7-0115c22d0d58"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("382c1b96-1305-499c-bd87-1b382bb20b28"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("bf290349-d826-45ce-8325-f4e65f544254"));

            migrationBuilder.DeleteData(
                table: "asp_net_users",
                keyColumn: "id",
                keyValue: new Guid("56129b97-38e0-44e8-b723-490a4b1b94e5"));

            migrationBuilder.DeleteData(
                table: "companies",
                keyColumn: "id",
                keyValue: new Guid("1df72ec4-97ba-4f2b-8409-950492f45740"));

            migrationBuilder.DeleteData(
                table: "tenant_plans",
                keyColumn: "id",
                keyValue: new Guid("5da5823e-01bd-4bc7-8b57-519b1f664f9f"));

            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "id",
                keyValue: new Guid("f16e781e-daca-4724-ab86-062210029054"));

            migrationBuilder.DeleteData(
                table: "companies",
                keyColumn: "id",
                keyValue: new Guid("3779b72a-f2e6-469a-8f1d-107844f089d5"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("d56f702e-4a82-4085-8992-bd5f1fa36f4b"));

            migrationBuilder.DeleteData(
                table: "profiles",
                keyColumn: "id",
                keyValue: new Guid("1d77ca4c-1d17-4776-97d4-96f132163fcf"));

            migrationBuilder.DeleteData(
                table: "tenant_plans",
                keyColumn: "id",
                keyValue: new Guid("aa8963b1-5813-4f30-a4f5-b671f86d3647"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("5b4a6a4b-8ecf-4d0e-80b9-fe8c73aaa4ba"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("2fd64167-37e2-407f-a3e7-0115c22d0d58"), "5d4bcce1-6f3d-4d3f-bb2b-a4cba22b4288", "ADMIN", "ADMIN" },
                    { new Guid("382c1b96-1305-499c-bd87-1b382bb20b28"), "a64dd50e-fa7e-4481-bde7-a4c523550d5c", "ROOT", "ROOT" },
                    { new Guid("bf290349-d826-45ce-8325-f4e65f544254"), "402a1721-8dae-4cfc-98a9-9d76ed27bdb0", "USER", "USER" }
                });

            migrationBuilder.InsertData(
                table: "companies",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("1df72ec4-97ba-4f2b-8409-950492f45740"), "Localhost" },
                    { new Guid("3779b72a-f2e6-469a-8f1d-107844f089d5"), "Dev Company" }
                });

            migrationBuilder.InsertData(
                table: "plans",
                columns: new[] { "id", "max_user_count", "name", "price", "renewal_rate" },
                values: new object[,]
                {
                    { new Guid("12aed472-9d3f-474a-97cb-36e67b058001"), 5, "Free", 0.00m, "MONTHLY" },
                    { new Guid("5b4a6a4b-8ecf-4d0e-80b9-fe8c73aaa4ba"), 5, "Dev", 0m, "MONTHLY" },
                    { new Guid("d56f702e-4a82-4085-8992-bd5f1fa36f4b"), 5, "Localhost Dev Plan", 0m, "MONTHLY" }
                });

            migrationBuilder.InsertData(
                table: "profiles",
                columns: new[] { "id", "first_name", "last_name" },
                values: new object[] { new Guid("1d77ca4c-1d17-4776-97d4-96f132163fcf"), "Jason", "White" });

            migrationBuilder.InsertData(
                table: "asp_net_users",
                columns: new[] { "id", "access_failed_count", "concurrency_stamp", "email", "email_confirmed", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "profile_id", "security_stamp", "two_factor_enabled", "user_name" },
                values: new object[] { new Guid("56129b97-38e0-44e8-b723-490a4b1b94e5"), 0, "60caf6a5-0cda-4d29-b8cf-ae1996470dea", "jmw5598@gmail.com", true, false, null, "JMW5598@gmail.com", "JMW5598@GMAIL.COM", "AQAAAAEAACcQAAAAEM0H+KRbrcYgevwnMDbO1R7qvfnb63zzWtya75gM4DwN5ALRrWYNyXvLuQxjhY6naw==", null, false, new Guid("1d77ca4c-1d17-4776-97d4-96f132163fcf"), null, false, "jmw5598@gmail.com" });

            migrationBuilder.InsertData(
                table: "tenant_plans",
                columns: new[] { "id", "max_user_count", "plan_id", "price", "renewal_rate" },
                values: new object[,]
                {
                    { new Guid("5da5823e-01bd-4bc7-8b57-519b1f664f9f"), 5, new Guid("d56f702e-4a82-4085-8992-bd5f1fa36f4b"), 0m, "MONTHLY" },
                    { new Guid("aa8963b1-5813-4f30-a4f5-b671f86d3647"), 5, new Guid("5b4a6a4b-8ecf-4d0e-80b9-fe8c73aaa4ba"), 0m, "MONTHLY" }
                });

            migrationBuilder.InsertData(
                table: "asp_net_user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("2fd64167-37e2-407f-a3e7-0115c22d0d58"), new Guid("56129b97-38e0-44e8-b723-490a4b1b94e5") },
                    { new Guid("382c1b96-1305-499c-bd87-1b382bb20b28"), new Guid("56129b97-38e0-44e8-b723-490a4b1b94e5") },
                    { new Guid("bf290349-d826-45ce-8325-f4e65f544254"), new Guid("56129b97-38e0-44e8-b723-490a4b1b94e5") }
                });

            migrationBuilder.InsertData(
                table: "tenants",
                columns: new[] { "id", "company_id", "connection_string", "display_name", "domain_names", "guid", "ip_addresses", "is_active", "is_configured", "name", "tenant_plan_id" },
                values: new object[,]
                {
                    { new Guid("42abc90e-65b7-4aab-8795-c10c13a3bb23"), new Guid("1df72ec4-97ba-4f2b-8409-950492f45740"), "Server=localhost;Port=5432;Database=xyz_localhost_company;User Id=xyz;Password=password;", "Localhost", "", "b4c4c3f7-b39d-4f84-865f-27266bd7c973", "", false, false, "localhost", new Guid("5da5823e-01bd-4bc7-8b57-519b1f664f9f") },
                    { new Guid("f16e781e-daca-4724-ab86-062210029054"), new Guid("3779b72a-f2e6-469a-8f1d-107844f089d5"), "Server=localhost;Port=5432;Database=xyz_dev_company;User Id=xyz;Password=password;", "Dev Company", "", "2c5522a8-cbde-4fa9-9be1-87eb40f0b250", "", true, true, "devcompany", new Guid("aa8963b1-5813-4f30-a4f5-b671f86d3647") }
                });

            migrationBuilder.InsertData(
                table: "user_tenants",
                columns: new[] { "asp_net_user_id", "tenant_id" },
                values: new object[] { new Guid("56129b97-38e0-44e8-b723-490a4b1b94e5"), new Guid("f16e781e-daca-4724-ab86-062210029054") });
        }
    }
}
