using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Multitenancy.Migrations
{
    public partial class AddsLocalhostTenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("1ba7247d-db53-4cf6-be56-5191aa103550"), new Guid("7db7a0c5-e56a-4caf-ac45-e92e35eab6a3") });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("2ecc2c82-d42d-4ca6-819b-40c189373eec"), new Guid("7db7a0c5-e56a-4caf-ac45-e92e35eab6a3") });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("c5f3fe7d-f33d-4f8c-8a3b-8cbffac665a4"), new Guid("7db7a0c5-e56a-4caf-ac45-e92e35eab6a3") });

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("9cbea5e7-3d49-4e01-920b-784fa273c858"));

            migrationBuilder.DeleteData(
                table: "user_tenants",
                keyColumns: new[] { "asp_net_user_id", "tenant_id" },
                keyValues: new object[] { new Guid("7db7a0c5-e56a-4caf-ac45-e92e35eab6a3"), new Guid("6de225d2-2c75-4c83-ad95-bd0da6234ae3") });

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("1ba7247d-db53-4cf6-be56-5191aa103550"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("2ecc2c82-d42d-4ca6-819b-40c189373eec"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("c5f3fe7d-f33d-4f8c-8a3b-8cbffac665a4"));

            migrationBuilder.DeleteData(
                table: "asp_net_users",
                keyColumn: "id",
                keyValue: new Guid("7db7a0c5-e56a-4caf-ac45-e92e35eab6a3"));

            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "id",
                keyValue: new Guid("6de225d2-2c75-4c83-ad95-bd0da6234ae3"));

            migrationBuilder.DeleteData(
                table: "companies",
                keyColumn: "id",
                keyValue: new Guid("780d69ff-ae6f-4207-b561-3f8a99178fc4"));

            migrationBuilder.DeleteData(
                table: "profiles",
                keyColumn: "id",
                keyValue: new Guid("20c88c47-ed95-41d6-9987-dd154269dbf2"));

            migrationBuilder.DeleteData(
                table: "tenant_plans",
                keyColumn: "id",
                keyValue: new Guid("3474fa8a-417d-44ac-b62c-729d4a8bef82"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("45bf9a53-b104-44a6-9fd2-08fae1af3858"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("1ba7247d-db53-4cf6-be56-5191aa103550"), "aa50c38d-6e0b-40c1-b7be-0c67283c7303", "ADMIN", "ADMIN" },
                    { new Guid("2ecc2c82-d42d-4ca6-819b-40c189373eec"), "899da343-f2aa-46d7-b513-b230db30103c", "USER", "USER" },
                    { new Guid("c5f3fe7d-f33d-4f8c-8a3b-8cbffac665a4"), "43ccd549-c919-4c5b-8c95-b55ee36b72cd", "ROOT", "ROOT" }
                });

            migrationBuilder.InsertData(
                table: "companies",
                columns: new[] { "id", "name" },
                values: new object[] { new Guid("780d69ff-ae6f-4207-b561-3f8a99178fc4"), "Dev Company" });

            migrationBuilder.InsertData(
                table: "plans",
                columns: new[] { "id", "max_user_count", "name", "price", "renewal_rate" },
                values: new object[,]
                {
                    { new Guid("45bf9a53-b104-44a6-9fd2-08fae1af3858"), 5, "Dev", 0m, "MONTHLY" },
                    { new Guid("9cbea5e7-3d49-4e01-920b-784fa273c858"), 5, "Free", 0.00m, "MONTHLY" }
                });

            migrationBuilder.InsertData(
                table: "profiles",
                columns: new[] { "id", "first_name", "last_name" },
                values: new object[] { new Guid("20c88c47-ed95-41d6-9987-dd154269dbf2"), "Jason", "White" });

            migrationBuilder.InsertData(
                table: "asp_net_users",
                columns: new[] { "id", "access_failed_count", "concurrency_stamp", "email", "email_confirmed", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "profile_id", "security_stamp", "two_factor_enabled", "user_name" },
                values: new object[] { new Guid("7db7a0c5-e56a-4caf-ac45-e92e35eab6a3"), 0, "0e618df8-0a2f-4a74-ba3d-bfe220aa32ec", "jmw5598@gmail.com", true, false, null, "JMW5598@gmail.com", "JMW5598@GMAIL.COM", "AQAAAAEAACcQAAAAEMkKsCfTKNFstpA+1xSw3eXmhEInA9ZjYRhefvo4yrFRBpboZGIoQM7gzF0zwRJB1Q==", null, false, new Guid("20c88c47-ed95-41d6-9987-dd154269dbf2"), null, false, "jmw5598@gmail.com" });

            migrationBuilder.InsertData(
                table: "tenant_plans",
                columns: new[] { "id", "max_user_count", "plan_id", "price", "renewal_rate" },
                values: new object[] { new Guid("3474fa8a-417d-44ac-b62c-729d4a8bef82"), 5, new Guid("45bf9a53-b104-44a6-9fd2-08fae1af3858"), 0m, "MONTHLY" });

            migrationBuilder.InsertData(
                table: "asp_net_user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("1ba7247d-db53-4cf6-be56-5191aa103550"), new Guid("7db7a0c5-e56a-4caf-ac45-e92e35eab6a3") },
                    { new Guid("2ecc2c82-d42d-4ca6-819b-40c189373eec"), new Guid("7db7a0c5-e56a-4caf-ac45-e92e35eab6a3") },
                    { new Guid("c5f3fe7d-f33d-4f8c-8a3b-8cbffac665a4"), new Guid("7db7a0c5-e56a-4caf-ac45-e92e35eab6a3") }
                });

            migrationBuilder.InsertData(
                table: "tenants",
                columns: new[] { "id", "company_id", "connection_string", "display_name", "domain_names", "guid", "ip_addresses", "is_active", "is_configured", "name", "tenant_plan_id" },
                values: new object[] { new Guid("6de225d2-2c75-4c83-ad95-bd0da6234ae3"), new Guid("780d69ff-ae6f-4207-b561-3f8a99178fc4"), "TODO", "Dev Company", "", "aae131c0-5420-4279-a37e-7d852e3a2cb8", "", true, true, "devcompany", new Guid("3474fa8a-417d-44ac-b62c-729d4a8bef82") });

            migrationBuilder.InsertData(
                table: "user_tenants",
                columns: new[] { "asp_net_user_id", "tenant_id" },
                values: new object[] { new Guid("7db7a0c5-e56a-4caf-ac45-e92e35eab6a3"), new Guid("6de225d2-2c75-4c83-ad95-bd0da6234ae3") });
        }
    }
}
