using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Multitenancy.Migrations
{
    public partial class SeedAddedToAddAUserWithRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("8ada2318-eaed-4ec8-b02b-320970ae1989"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("daed4d3e-a8b2-4fec-b35b-9266b029f591"));

            migrationBuilder.DeleteData(
                table: "plan",
                keyColumn: "id",
                keyValue: new Guid("e770d388-0818-44a1-8e7e-9dbfa928806c"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("8ada2318-eaed-4ec8-b02b-320970ae1989"), "c96d43db-f8f4-43e4-9811-8ef34e9add3c", "USER", "USER" },
                    { new Guid("daed4d3e-a8b2-4fec-b35b-9266b029f591"), "c72c2b1f-c599-4c2f-8008-6f7cb34cc076", "ADMIN", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "plan",
                columns: new[] { "id", "max_user_count", "name", "price", "renewal_rate" },
                values: new object[] { new Guid("e770d388-0818-44a1-8e7e-9dbfa928806c"), 5, "Free", 0.00m, "MONTHLY" });
        }
    }
}
