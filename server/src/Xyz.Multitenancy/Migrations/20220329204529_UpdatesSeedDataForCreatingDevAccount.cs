using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Multitenancy.Migrations
{
    public partial class UpdatesSeedDataForCreatingDevAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("46b8ce19-f8ba-4e7b-a65d-8f631f24c273"), new Guid("a690c956-dd2f-4333-af23-2ad09c448cb6") });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("9d06b4bf-de6f-4670-8461-4fba1e1adbf2"), new Guid("a690c956-dd2f-4333-af23-2ad09c448cb6") });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("eda9d67a-97ca-48fa-b7d8-8df49f3b2ae0"), new Guid("a690c956-dd2f-4333-af23-2ad09c448cb6") });

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("440d9e74-23c7-4832-b022-02dc09a4f401"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("46b8ce19-f8ba-4e7b-a65d-8f631f24c273"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("9d06b4bf-de6f-4670-8461-4fba1e1adbf2"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("eda9d67a-97ca-48fa-b7d8-8df49f3b2ae0"));

            migrationBuilder.DeleteData(
                table: "asp_net_users",
                keyColumn: "id",
                keyValue: new Guid("a690c956-dd2f-4333-af23-2ad09c448cb6"));

            migrationBuilder.DeleteData(
                table: "profiles",
                keyColumn: "id",
                keyValue: new Guid("eceec20e-b26a-47b4-a437-08e910b2d36e"));

            migrationBuilder.AlterColumn<string>(
                name: "renewal_rate",
                table: "tenant_plans",
                type: "varchar(24)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "renewal_rate",
                table: "tenant_plans",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(24)");

            migrationBuilder.InsertData(
                table: "asp_net_roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { new Guid("46b8ce19-f8ba-4e7b-a65d-8f631f24c273"), "1dccf6eb-097e-4a08-bd25-0961bba7177d", "ADMIN", "ADMIN" },
                    { new Guid("9d06b4bf-de6f-4670-8461-4fba1e1adbf2"), "f7f5db0f-ffb7-4e14-8c8f-f607aa29272c", "ROOT", "ROOT" },
                    { new Guid("eda9d67a-97ca-48fa-b7d8-8df49f3b2ae0"), "63905248-adeb-41b4-9812-8d34777f762c", "USER", "USER" }
                });

            migrationBuilder.InsertData(
                table: "plans",
                columns: new[] { "id", "max_user_count", "name", "price", "renewal_rate" },
                values: new object[] { new Guid("440d9e74-23c7-4832-b022-02dc09a4f401"), 5, "Free", 0.00m, "MONTHLY" });

            migrationBuilder.InsertData(
                table: "profiles",
                columns: new[] { "id", "first_name", "last_name" },
                values: new object[] { new Guid("eceec20e-b26a-47b4-a437-08e910b2d36e"), "Jason", "White" });

            migrationBuilder.InsertData(
                table: "asp_net_users",
                columns: new[] { "id", "access_failed_count", "concurrency_stamp", "email", "email_confirmed", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "profile_id", "security_stamp", "two_factor_enabled", "user_name" },
                values: new object[] { new Guid("a690c956-dd2f-4333-af23-2ad09c448cb6"), 0, "e3b70ee8-3fe5-4b88-be4d-343da67944f1", "jmw5598@gmail.com", true, false, null, "JMW5598@gmail.com", "JMW5598@GMAIL.COM", "AQAAAAEAACcQAAAAEPIUW2amRIsVRmYVQzbag+47GvVB4Q9D7ENWlcGDl1ZfujNCUJTgF0lo+6cLw/Khvw==", null, false, new Guid("eceec20e-b26a-47b4-a437-08e910b2d36e"), null, false, "jmw5598@gmail.com" });

            migrationBuilder.InsertData(
                table: "asp_net_user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("46b8ce19-f8ba-4e7b-a65d-8f631f24c273"), new Guid("a690c956-dd2f-4333-af23-2ad09c448cb6") },
                    { new Guid("9d06b4bf-de6f-4670-8461-4fba1e1adbf2"), new Guid("a690c956-dd2f-4333-af23-2ad09c448cb6") },
                    { new Guid("eda9d67a-97ca-48fa-b7d8-8df49f3b2ae0"), new Guid("a690c956-dd2f-4333-af23-2ad09c448cb6") }
                });
        }
    }
}
