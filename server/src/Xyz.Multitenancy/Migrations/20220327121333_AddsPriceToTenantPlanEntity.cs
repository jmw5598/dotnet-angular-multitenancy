using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Multitenancy.Migrations
{
    public partial class AddsPriceToTenantPlanEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "tenant_plans",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "price",
                table: "tenant_plans");

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
        }
    }
}
