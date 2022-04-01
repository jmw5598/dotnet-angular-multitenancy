using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Multitenancy.Migrations
{
    public partial class AddsDevCompanyConnectionStringForSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("908a3478-1628-49bd-826d-29b13a66b801"), new Guid("4f0d401d-ddad-4465-a4f0-e772ea0b2cd8") });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("b63afa45-638b-42b9-a14d-8d25684652f8"), new Guid("4f0d401d-ddad-4465-a4f0-e772ea0b2cd8") });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("e03e8b02-318f-4e53-9e59-5ad6dee64806"), new Guid("4f0d401d-ddad-4465-a4f0-e772ea0b2cd8") });

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("e6fb1aeb-0917-4d2f-bc91-404d3b7a810e"));

            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "id",
                keyValue: new Guid("fc10976b-b95d-47f6-9889-fcb8d2087447"));

            migrationBuilder.DeleteData(
                table: "user_tenants",
                keyColumns: new[] { "asp_net_user_id", "tenant_id" },
                keyValues: new object[] { new Guid("4f0d401d-ddad-4465-a4f0-e772ea0b2cd8"), new Guid("89d8ac05-0b83-4cbb-8f49-7bc9a0671970") });

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("908a3478-1628-49bd-826d-29b13a66b801"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("b63afa45-638b-42b9-a14d-8d25684652f8"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("e03e8b02-318f-4e53-9e59-5ad6dee64806"));

            migrationBuilder.DeleteData(
                table: "asp_net_users",
                keyColumn: "id",
                keyValue: new Guid("4f0d401d-ddad-4465-a4f0-e772ea0b2cd8"));

            migrationBuilder.DeleteData(
                table: "companies",
                keyColumn: "id",
                keyValue: new Guid("8b4dda8c-1a02-46a8-b5b0-75236ec7460d"));

            migrationBuilder.DeleteData(
                table: "tenant_plans",
                keyColumn: "id",
                keyValue: new Guid("f66b20ad-8eae-41ec-a86b-cfcefed5bb1d"));

            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "id",
                keyValue: new Guid("89d8ac05-0b83-4cbb-8f49-7bc9a0671970"));

            migrationBuilder.DeleteData(
                table: "companies",
                keyColumn: "id",
                keyValue: new Guid("225840d8-c229-4956-824b-71996cfbc197"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("17b37b4e-256d-40bf-8cf5-ba7ad4e012d5"));

            migrationBuilder.DeleteData(
                table: "profiles",
                keyColumn: "id",
                keyValue: new Guid("7136f0cc-fbe3-489f-a361-2911a79ed556"));

            migrationBuilder.DeleteData(
                table: "tenant_plans",
                keyColumn: "id",
                keyValue: new Guid("7eaf086a-a662-41a5-9ac8-81b4cacdd7bd"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("83ad5ab7-a676-4b78-be85-4e025b9ca7c5"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "asp_net_roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { new Guid("908a3478-1628-49bd-826d-29b13a66b801"), "6ac7d1be-3e5f-4ea8-b2a1-2d5de34dba98", "ADMIN", "ADMIN" },
                    { new Guid("b63afa45-638b-42b9-a14d-8d25684652f8"), "0413cb6b-3f6a-4e57-a84f-e0f77fd131e5", "USER", "USER" },
                    { new Guid("e03e8b02-318f-4e53-9e59-5ad6dee64806"), "917fe6d8-aa8d-494b-ab97-9df71524ee78", "ROOT", "ROOT" }
                });

            migrationBuilder.InsertData(
                table: "companies",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("225840d8-c229-4956-824b-71996cfbc197"), "Dev Company" },
                    { new Guid("8b4dda8c-1a02-46a8-b5b0-75236ec7460d"), "Localhost" }
                });

            migrationBuilder.InsertData(
                table: "plans",
                columns: new[] { "id", "max_user_count", "name", "price", "renewal_rate" },
                values: new object[,]
                {
                    { new Guid("17b37b4e-256d-40bf-8cf5-ba7ad4e012d5"), 5, "Localhost Dev Plan", 0m, "MONTHLY" },
                    { new Guid("83ad5ab7-a676-4b78-be85-4e025b9ca7c5"), 5, "Dev", 0m, "MONTHLY" },
                    { new Guid("e6fb1aeb-0917-4d2f-bc91-404d3b7a810e"), 5, "Free", 0.00m, "MONTHLY" }
                });

            migrationBuilder.InsertData(
                table: "profiles",
                columns: new[] { "id", "first_name", "last_name" },
                values: new object[] { new Guid("7136f0cc-fbe3-489f-a361-2911a79ed556"), "Jason", "White" });

            migrationBuilder.InsertData(
                table: "asp_net_users",
                columns: new[] { "id", "access_failed_count", "concurrency_stamp", "email", "email_confirmed", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "profile_id", "security_stamp", "two_factor_enabled", "user_name" },
                values: new object[] { new Guid("4f0d401d-ddad-4465-a4f0-e772ea0b2cd8"), 0, "030e4383-ad66-4bbe-8cb7-7c20be787f68", "jmw5598@gmail.com", true, false, null, "JMW5598@gmail.com", "JMW5598@GMAIL.COM", "AQAAAAEAACcQAAAAEAc0fJsLS9J2OvT4b8gA2H89wpfKyTdFjtPF0GmpO+GQf6CNbL7/QVrWHJw8lwFAZA==", null, false, new Guid("7136f0cc-fbe3-489f-a361-2911a79ed556"), null, false, "jmw5598@gmail.com" });

            migrationBuilder.InsertData(
                table: "tenant_plans",
                columns: new[] { "id", "max_user_count", "plan_id", "price", "renewal_rate" },
                values: new object[,]
                {
                    { new Guid("7eaf086a-a662-41a5-9ac8-81b4cacdd7bd"), 5, new Guid("83ad5ab7-a676-4b78-be85-4e025b9ca7c5"), 0m, "MONTHLY" },
                    { new Guid("f66b20ad-8eae-41ec-a86b-cfcefed5bb1d"), 5, new Guid("17b37b4e-256d-40bf-8cf5-ba7ad4e012d5"), 0m, "MONTHLY" }
                });

            migrationBuilder.InsertData(
                table: "asp_net_user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("908a3478-1628-49bd-826d-29b13a66b801"), new Guid("4f0d401d-ddad-4465-a4f0-e772ea0b2cd8") },
                    { new Guid("b63afa45-638b-42b9-a14d-8d25684652f8"), new Guid("4f0d401d-ddad-4465-a4f0-e772ea0b2cd8") },
                    { new Guid("e03e8b02-318f-4e53-9e59-5ad6dee64806"), new Guid("4f0d401d-ddad-4465-a4f0-e772ea0b2cd8") }
                });

            migrationBuilder.InsertData(
                table: "tenants",
                columns: new[] { "id", "company_id", "connection_string", "display_name", "domain_names", "guid", "ip_addresses", "is_active", "is_configured", "name", "tenant_plan_id" },
                values: new object[,]
                {
                    { new Guid("89d8ac05-0b83-4cbb-8f49-7bc9a0671970"), new Guid("225840d8-c229-4956-824b-71996cfbc197"), "TODO", "Dev Company", "", "67d52d6e-449d-465d-8e9a-d93f3d978522", "", true, true, "devcompany", new Guid("7eaf086a-a662-41a5-9ac8-81b4cacdd7bd") },
                    { new Guid("fc10976b-b95d-47f6-9889-fcb8d2087447"), new Guid("8b4dda8c-1a02-46a8-b5b0-75236ec7460d"), "", "Localhost", "", "0b8d2beb-cafc-4c26-905b-f4543743300d", "", false, false, "localhost", new Guid("f66b20ad-8eae-41ec-a86b-cfcefed5bb1d") }
                });

            migrationBuilder.InsertData(
                table: "user_tenants",
                columns: new[] { "asp_net_user_id", "tenant_id" },
                values: new object[] { new Guid("4f0d401d-ddad-4465-a4f0-e772ea0b2cd8"), new Guid("89d8ac05-0b83-4cbb-8f49-7bc9a0671970") });
        }
    }
}
