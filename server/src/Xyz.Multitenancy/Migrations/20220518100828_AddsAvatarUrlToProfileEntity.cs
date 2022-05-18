using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Multitenancy.Migrations
{
    public partial class AddsAvatarUrlToProfileEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "avatar_url",
                table: "profiles",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "asp_net_roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { new Guid("06af0ee3-d9f3-41ce-a85a-d2adf29325ef"), "01948a9a-fdcb-4886-987a-75d46ab3f44e", "ROOT", "ROOT" },
                    { new Guid("5d9f48f6-aea8-4b71-80db-c6bb65f78c73"), "14ef6600-c5a5-4c2d-81d4-c9274adccab2", "ADMIN", "ADMIN" },
                    { new Guid("b3ae0463-3f2b-4177-a4d2-07d0aeabba93"), "6b74f653-8970-4d2b-a4b5-483b3f8f0f17", "USER", "USER" }
                });

            migrationBuilder.InsertData(
                table: "companies",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("1e8b124d-3a5b-4c31-a0c7-4455aea85ad7"), "Localhost" },
                    { new Guid("9052dfb7-a67b-4ed7-afb7-658c7d1641a8"), "Dev Company" }
                });

            migrationBuilder.InsertData(
                table: "plans",
                columns: new[] { "id", "max_user_count", "name", "price", "renewal_rate" },
                values: new object[,]
                {
                    { new Guid("13cbf351-5269-4f76-b179-17414669c3d3"), 5, "Free", 0.00m, "MONTHLY" },
                    { new Guid("a58ece84-9834-4726-b0c0-10f43a82b990"), 5, "Localhost Dev Plan", 0m, "MONTHLY" },
                    { new Guid("bbcb9edd-0b46-43eb-9419-1563a277ad58"), 5, "Dev", 0m, "MONTHLY" }
                });

            migrationBuilder.InsertData(
                table: "profiles",
                columns: new[] { "id", "avatar_url", "first_name", "last_name" },
                values: new object[] { new Guid("7d355714-763d-48ac-8886-50dab3f01e11"), null, "Jason", "White" });

            migrationBuilder.InsertData(
                table: "asp_net_users",
                columns: new[] { "id", "access_failed_count", "concurrency_stamp", "email", "email_confirmed", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "profile_id", "security_stamp", "two_factor_enabled", "user_name" },
                values: new object[] { new Guid("6fcb8e98-1a13-41a9-ab3c-2169f4d716c0"), 0, "f0c46d90-8bef-4461-8f3f-8271cbe13c7c", "jmw5598@gmail.com", true, false, null, "JMW5598@gmail.com", "JMW5598@GMAIL.COM", "AQAAAAEAACcQAAAAENccJfHvrrswM3ayb7zpqGoATipLplJ4q+ZQCZ87p08cSf4SmRyDnOPnyde5KzdWvg==", null, false, new Guid("7d355714-763d-48ac-8886-50dab3f01e11"), null, false, "jmw5598@gmail.com" });

            migrationBuilder.InsertData(
                table: "tenant_plans",
                columns: new[] { "id", "max_user_count", "plan_id", "price", "renewal_rate" },
                values: new object[,]
                {
                    { new Guid("99d4f0c5-8d13-4bf4-9595-6438f89977f8"), 5, new Guid("bbcb9edd-0b46-43eb-9419-1563a277ad58"), 0m, "MONTHLY" },
                    { new Guid("d4c48f09-f7a4-4b3b-9fcb-a719dcda1903"), 5, new Guid("a58ece84-9834-4726-b0c0-10f43a82b990"), 0m, "MONTHLY" }
                });

            migrationBuilder.InsertData(
                table: "asp_net_user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("06af0ee3-d9f3-41ce-a85a-d2adf29325ef"), new Guid("6fcb8e98-1a13-41a9-ab3c-2169f4d716c0") },
                    { new Guid("5d9f48f6-aea8-4b71-80db-c6bb65f78c73"), new Guid("6fcb8e98-1a13-41a9-ab3c-2169f4d716c0") },
                    { new Guid("b3ae0463-3f2b-4177-a4d2-07d0aeabba93"), new Guid("6fcb8e98-1a13-41a9-ab3c-2169f4d716c0") }
                });

            migrationBuilder.InsertData(
                table: "tenants",
                columns: new[] { "id", "company_id", "connection_string", "display_name", "domain_names", "guid", "ip_addresses", "is_active", "is_configured", "name", "tenant_plan_id" },
                values: new object[,]
                {
                    { new Guid("a25535e2-56d0-453d-8989-09ddbc3da597"), new Guid("1e8b124d-3a5b-4c31-a0c7-4455aea85ad7"), "Server=localhost;Port=5432;Database=xyz_localhost_company;User Id=xyz;Password=password;", "Localhost", "", "f2d74c37-935c-4510-b52f-fa291cb12c3a", "", false, false, "localhost", new Guid("d4c48f09-f7a4-4b3b-9fcb-a719dcda1903") },
                    { new Guid("e848c2b5-09e1-49e5-9657-529622d027b0"), new Guid("9052dfb7-a67b-4ed7-afb7-658c7d1641a8"), "Server=localhost;Port=5432;Database=xyz_dev_company;User Id=xyz;Password=password;", "Dev Company", "", "61bd11a3-9f3e-46a7-bc2b-17b1a8981d1a", "", true, true, "devcompany", new Guid("99d4f0c5-8d13-4bf4-9595-6438f89977f8") }
                });

            migrationBuilder.InsertData(
                table: "user_tenants",
                columns: new[] { "asp_net_user_id", "tenant_id" },
                values: new object[] { new Guid("6fcb8e98-1a13-41a9-ab3c-2169f4d716c0"), new Guid("e848c2b5-09e1-49e5-9657-529622d027b0") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("06af0ee3-d9f3-41ce-a85a-d2adf29325ef"), new Guid("6fcb8e98-1a13-41a9-ab3c-2169f4d716c0") });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("5d9f48f6-aea8-4b71-80db-c6bb65f78c73"), new Guid("6fcb8e98-1a13-41a9-ab3c-2169f4d716c0") });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("b3ae0463-3f2b-4177-a4d2-07d0aeabba93"), new Guid("6fcb8e98-1a13-41a9-ab3c-2169f4d716c0") });

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("13cbf351-5269-4f76-b179-17414669c3d3"));

            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "id",
                keyValue: new Guid("a25535e2-56d0-453d-8989-09ddbc3da597"));

            migrationBuilder.DeleteData(
                table: "user_tenants",
                keyColumns: new[] { "asp_net_user_id", "tenant_id" },
                keyValues: new object[] { new Guid("6fcb8e98-1a13-41a9-ab3c-2169f4d716c0"), new Guid("e848c2b5-09e1-49e5-9657-529622d027b0") });

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("06af0ee3-d9f3-41ce-a85a-d2adf29325ef"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("5d9f48f6-aea8-4b71-80db-c6bb65f78c73"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("b3ae0463-3f2b-4177-a4d2-07d0aeabba93"));

            migrationBuilder.DeleteData(
                table: "asp_net_users",
                keyColumn: "id",
                keyValue: new Guid("6fcb8e98-1a13-41a9-ab3c-2169f4d716c0"));

            migrationBuilder.DeleteData(
                table: "companies",
                keyColumn: "id",
                keyValue: new Guid("1e8b124d-3a5b-4c31-a0c7-4455aea85ad7"));

            migrationBuilder.DeleteData(
                table: "tenant_plans",
                keyColumn: "id",
                keyValue: new Guid("d4c48f09-f7a4-4b3b-9fcb-a719dcda1903"));

            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "id",
                keyValue: new Guid("e848c2b5-09e1-49e5-9657-529622d027b0"));

            migrationBuilder.DeleteData(
                table: "companies",
                keyColumn: "id",
                keyValue: new Guid("9052dfb7-a67b-4ed7-afb7-658c7d1641a8"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("a58ece84-9834-4726-b0c0-10f43a82b990"));

            migrationBuilder.DeleteData(
                table: "profiles",
                keyColumn: "id",
                keyValue: new Guid("7d355714-763d-48ac-8886-50dab3f01e11"));

            migrationBuilder.DeleteData(
                table: "tenant_plans",
                keyColumn: "id",
                keyValue: new Guid("99d4f0c5-8d13-4bf4-9595-6438f89977f8"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("bbcb9edd-0b46-43eb-9419-1563a277ad58"));

            migrationBuilder.DropColumn(
                name: "avatar_url",
                table: "profiles");

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
    }
}
