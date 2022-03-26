using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Multitenancy.Migrations
{
    public partial class AddsPropertiesToProfileEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("38d8a1ff-b45e-4113-ac9d-f209a749e441"), new Guid("03e9ba3a-aab8-42bc-8423-610fb09b1a28") });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("836bca09-b91d-423d-939c-3fd888e189c7"), new Guid("03e9ba3a-aab8-42bc-8423-610fb09b1a28") });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("8a3bde90-8e2d-45ac-b1de-5917a49e8c12"), new Guid("03e9ba3a-aab8-42bc-8423-610fb09b1a28") });

            migrationBuilder.DeleteData(
                table: "plan",
                keyColumn: "id",
                keyValue: new Guid("d1f3c2ce-f5e2-4f2d-a04f-5be1ce68fab3"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("38d8a1ff-b45e-4113-ac9d-f209a749e441"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("836bca09-b91d-423d-939c-3fd888e189c7"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("8a3bde90-8e2d-45ac-b1de-5917a49e8c12"));

            migrationBuilder.DeleteData(
                table: "asp_net_users",
                keyColumn: "id",
                keyValue: new Guid("03e9ba3a-aab8-42bc-8423-610fb09b1a28"));

            migrationBuilder.InsertData(
                table: "asp_net_roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { new Guid("3bd6921a-a793-467c-9058-cbd895b76008"), "1c92375a-3ba0-4bd2-b24c-218a3a6263dd", "ADMIN", "ADMIN" },
                    { new Guid("4a653a65-d1e5-44b2-8cca-8b204905cfa6"), "72ef4205-22ac-44b3-a6a2-a0483b6d2a67", "USER", "USER" },
                    { new Guid("c42bb479-82a1-4724-8178-305d32cf64ab"), "f562379f-4324-450d-be22-3730716df92d", "ROOT", "ROOT" }
                });

            migrationBuilder.InsertData(
                table: "asp_net_users",
                columns: new[] { "id", "access_failed_count", "concurrency_stamp", "email", "email_confirmed", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "security_stamp", "two_factor_enabled", "user_name" },
                values: new object[] { new Guid("62308887-6c0b-4401-b13e-373979018e74"), 0, "348caab0-7a64-45c7-bb78-0caf20a89d10", "jmw5598@gmail.com", true, false, null, "JMW5598@gmail.com", "JMW5598@GMAIL.COM", "AQAAAAEAACcQAAAAEHewMAknHX56M9TEOEHTJhY1pJ8CA9yZ3EitGmMzB0suZybMiuh5VIQWbdL8ZjoRdA==", null, false, null, false, "jmw5598@gmail.com" });

            migrationBuilder.InsertData(
                table: "plan",
                columns: new[] { "id", "max_user_count", "name", "price", "renewal_rate" },
                values: new object[] { new Guid("4dd2a52c-5d0a-488a-87b4-4ee4df4c17fe"), 5, "Free", 0.00m, "MONTHLY" });

            migrationBuilder.InsertData(
                table: "asp_net_user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("3bd6921a-a793-467c-9058-cbd895b76008"), new Guid("62308887-6c0b-4401-b13e-373979018e74") },
                    { new Guid("4a653a65-d1e5-44b2-8cca-8b204905cfa6"), new Guid("62308887-6c0b-4401-b13e-373979018e74") },
                    { new Guid("c42bb479-82a1-4724-8178-305d32cf64ab"), new Guid("62308887-6c0b-4401-b13e-373979018e74") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("3bd6921a-a793-467c-9058-cbd895b76008"), new Guid("62308887-6c0b-4401-b13e-373979018e74") });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("4a653a65-d1e5-44b2-8cca-8b204905cfa6"), new Guid("62308887-6c0b-4401-b13e-373979018e74") });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("c42bb479-82a1-4724-8178-305d32cf64ab"), new Guid("62308887-6c0b-4401-b13e-373979018e74") });

            migrationBuilder.DeleteData(
                table: "plan",
                keyColumn: "id",
                keyValue: new Guid("4dd2a52c-5d0a-488a-87b4-4ee4df4c17fe"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("3bd6921a-a793-467c-9058-cbd895b76008"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("4a653a65-d1e5-44b2-8cca-8b204905cfa6"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("c42bb479-82a1-4724-8178-305d32cf64ab"));

            migrationBuilder.DeleteData(
                table: "asp_net_users",
                keyColumn: "id",
                keyValue: new Guid("62308887-6c0b-4401-b13e-373979018e74"));

            migrationBuilder.InsertData(
                table: "asp_net_roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { new Guid("38d8a1ff-b45e-4113-ac9d-f209a749e441"), "c9c1a6b3-cb61-436f-bb88-42b0fa94dec4", "USER", "USER" },
                    { new Guid("836bca09-b91d-423d-939c-3fd888e189c7"), "6acf65ad-3e0d-419e-bd87-0cda3071ebb3", "ADMIN", "ADMIN" },
                    { new Guid("8a3bde90-8e2d-45ac-b1de-5917a49e8c12"), "673427a9-ad47-481a-b54a-7cea80629625", "ROOT", "ROOT" }
                });

            migrationBuilder.InsertData(
                table: "asp_net_users",
                columns: new[] { "id", "access_failed_count", "concurrency_stamp", "email", "email_confirmed", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "security_stamp", "two_factor_enabled", "user_name" },
                values: new object[] { new Guid("03e9ba3a-aab8-42bc-8423-610fb09b1a28"), 0, "82d11f08-48f4-413b-8f6f-9843c1667d3b", "jmw5598@gmail.com", true, false, null, "JMW5598@gmail.com", "JMW5598@GMAIL.COM", "AQAAAAEAACcQAAAAEIScI7/QeISXlVC1KUyq+uWKi6qKa/VKA7iuyWBoSARnbpZOUcuXN/DdYJwE+YvOwQ==", null, false, null, false, "jmw5598@gmail.com" });

            migrationBuilder.InsertData(
                table: "plan",
                columns: new[] { "id", "max_user_count", "name", "price", "renewal_rate" },
                values: new object[] { new Guid("d1f3c2ce-f5e2-4f2d-a04f-5be1ce68fab3"), 5, "Free", 0.00m, "MONTHLY" });

            migrationBuilder.InsertData(
                table: "asp_net_user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("38d8a1ff-b45e-4113-ac9d-f209a749e441"), new Guid("03e9ba3a-aab8-42bc-8423-610fb09b1a28") },
                    { new Guid("836bca09-b91d-423d-939c-3fd888e189c7"), new Guid("03e9ba3a-aab8-42bc-8423-610fb09b1a28") },
                    { new Guid("8a3bde90-8e2d-45ac-b1de-5917a49e8c12"), new Guid("03e9ba3a-aab8-42bc-8423-610fb09b1a28") }
                });
        }
    }
}
