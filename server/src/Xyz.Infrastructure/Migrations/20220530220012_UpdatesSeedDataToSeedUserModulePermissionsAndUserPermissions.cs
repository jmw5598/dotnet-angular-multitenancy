using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Infrastructure.Migrations
{
    public partial class UpdatesSeedDataToSeedUserModulePermissionsAndUserPermissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("3c21b629-a968-4fe2-9fee-22be79d0a223"), new Guid("d9f178d0-a1bf-4d93-b13f-dd9328c80b3a") });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("44d34c23-263a-4541-a6ba-ddcdc6e6bc9d"), new Guid("d9f178d0-a1bf-4d93-b13f-dd9328c80b3a") });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("93fdb1c0-d000-42ae-8cee-287c5c7031fa"), new Guid("d9f178d0-a1bf-4d93-b13f-dd9328c80b3a") });

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("8c04ef5c-3cc9-447e-bd8d-669abf5801d6"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("8e6ecacb-d781-4760-946a-fcf4f1b0d4cc"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("9399ac6c-1c9a-4803-bfae-ec4ddc41341d"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("b06e333b-7cc6-44d5-ad37-7effba966572"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("ee62f516-df49-4105-af41-164f20aa13cc"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("3c21b629-a968-4fe2-9fee-22be79d0a223"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("44d34c23-263a-4541-a6ba-ddcdc6e6bc9d"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("93fdb1c0-d000-42ae-8cee-287c5c7031fa"));

            migrationBuilder.DeleteData(
                table: "asp_net_users",
                keyColumn: "id",
                keyValue: new Guid("d9f178d0-a1bf-4d93-b13f-dd9328c80b3a"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("008b147a-235a-4e6c-a675-e42a89f15d95"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("0c78ee77-95e7-44d9-bd83-e30439232f84"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("be996882-2dda-492e-bc67-006c2c1ebab3"));

            migrationBuilder.DeleteData(
                table: "profiles",
                keyColumn: "id",
                keyValue: new Guid("1fd5e9d9-11da-4163-8f18-08f1e4299776"));

            migrationBuilder.InsertData(
                table: "asp_net_roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac22"), "a915dc6d-6e24-441e-b102-73830a7a5629", "USER", "USER" },
                    { new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac27"), "221022b3-38f3-4779-9061-47e379a29fbd", "ROOT", "ROOT" },
                    { new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac28"), "b593d6fc-922d-427c-8fe4-4c00ef996219", "ADMIN", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "module_permissions",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc16"), "Security Module" },
                    { new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc17"), "Dashboard Module" },
                    { new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc27"), "Administration Module" }
                });

            migrationBuilder.InsertData(
                table: "profiles",
                columns: new[] { "id", "avatar_url", "first_name", "last_name" },
                values: new object[] { new Guid("233f9479-34e3-46f3-b992-b70897ad50a1"), null, "Jason", "White" });

            migrationBuilder.InsertData(
                table: "asp_net_users",
                columns: new[] { "id", "access_failed_count", "concurrency_stamp", "email", "email_confirmed", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "profile_id", "security_stamp", "two_factor_enabled", "user_name" },
                values: new object[] { new Guid("d63125c0-4c0d-459b-bf19-7be15ba38405"), 0, "a60d68f6-c174-4788-9e4c-64d0061b2fbf", "jmw5598@gmail.com", true, false, null, "JMW5598@gmail.com", "JMW5598@GMAIL.COM", "AQAAAAEAACcQAAAAECYCojMtCjiWOiWkC9mLBIfrGmPaJK4C70LZmB4vd7TNAx8KGzHMwingwx07kOF6+w==", null, false, new Guid("233f9479-34e3-46f3-b992-b70897ad50a1"), null, false, "jmw5598@gmail.com" });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "module_permission_id", "name" },
                values: new object[,]
                {
                    { new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc07"), new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc17"), "Dashboard Overview" },
                    { new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc11"), new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc16"), "Security General" },
                    { new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc21"), new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc27"), "User Accounts" },
                    { new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc22"), new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc27"), "Settings" },
                    { new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacd27"), new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc16"), "Security Permissions" }
                });

            migrationBuilder.InsertData(
                table: "asp_net_user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac22"), new Guid("d63125c0-4c0d-459b-bf19-7be15ba38405") },
                    { new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac27"), new Guid("d63125c0-4c0d-459b-bf19-7be15ba38405") },
                    { new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac28"), new Guid("d63125c0-4c0d-459b-bf19-7be15ba38405") }
                });

            migrationBuilder.InsertData(
                table: "user_module_permissions",
                columns: new[] { "id", "has_access", "module_permission_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("3609c2ab-d858-4ba9-ae9a-9a08c5749e93"), true, new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc16"), new Guid("d63125c0-4c0d-459b-bf19-7be15ba38405") },
                    { new Guid("990d6385-fff8-4559-a549-0b8451b426b3"), true, new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc17"), new Guid("d63125c0-4c0d-459b-bf19-7be15ba38405") },
                    { new Guid("effd8225-334b-4700-a874-d33eb840fa6f"), true, new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc27"), new Guid("d63125c0-4c0d-459b-bf19-7be15ba38405") }
                });

            migrationBuilder.InsertData(
                table: "user_permissions",
                columns: new[] { "id", "can_create", "can_delete", "can_read", "can_update", "permission_id", "user_module_permission_id" },
                values: new object[,]
                {
                    { new Guid("22f92323-ad90-4609-ad84-3b0724e1dc92"), true, true, true, true, new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc21"), new Guid("effd8225-334b-4700-a874-d33eb840fa6f") },
                    { new Guid("72e4c218-9278-4755-9445-204ba2d33a6f"), true, true, true, true, new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc07"), new Guid("990d6385-fff8-4559-a549-0b8451b426b3") },
                    { new Guid("c24d3f5c-45f5-4823-a02e-388f6602abae"), true, true, true, true, new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacd27"), new Guid("3609c2ab-d858-4ba9-ae9a-9a08c5749e93") },
                    { new Guid("cfa307d5-3ac8-4d2c-9686-84d5e4efeeb3"), true, true, true, true, new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc22"), new Guid("effd8225-334b-4700-a874-d33eb840fa6f") },
                    { new Guid("f0ba657b-4dd7-45ba-b491-60422ddd8242"), true, true, true, true, new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc11"), new Guid("3609c2ab-d858-4ba9-ae9a-9a08c5749e93") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac22"), new Guid("d63125c0-4c0d-459b-bf19-7be15ba38405") });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac27"), new Guid("d63125c0-4c0d-459b-bf19-7be15ba38405") });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac28"), new Guid("d63125c0-4c0d-459b-bf19-7be15ba38405") });

            migrationBuilder.DeleteData(
                table: "user_permissions",
                keyColumn: "id",
                keyValue: new Guid("22f92323-ad90-4609-ad84-3b0724e1dc92"));

            migrationBuilder.DeleteData(
                table: "user_permissions",
                keyColumn: "id",
                keyValue: new Guid("72e4c218-9278-4755-9445-204ba2d33a6f"));

            migrationBuilder.DeleteData(
                table: "user_permissions",
                keyColumn: "id",
                keyValue: new Guid("c24d3f5c-45f5-4823-a02e-388f6602abae"));

            migrationBuilder.DeleteData(
                table: "user_permissions",
                keyColumn: "id",
                keyValue: new Guid("cfa307d5-3ac8-4d2c-9686-84d5e4efeeb3"));

            migrationBuilder.DeleteData(
                table: "user_permissions",
                keyColumn: "id",
                keyValue: new Guid("f0ba657b-4dd7-45ba-b491-60422ddd8242"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac22"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac27"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac28"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc07"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc11"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc21"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc22"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacd27"));

            migrationBuilder.DeleteData(
                table: "user_module_permissions",
                keyColumn: "id",
                keyValue: new Guid("3609c2ab-d858-4ba9-ae9a-9a08c5749e93"));

            migrationBuilder.DeleteData(
                table: "user_module_permissions",
                keyColumn: "id",
                keyValue: new Guid("990d6385-fff8-4559-a549-0b8451b426b3"));

            migrationBuilder.DeleteData(
                table: "user_module_permissions",
                keyColumn: "id",
                keyValue: new Guid("effd8225-334b-4700-a874-d33eb840fa6f"));

            migrationBuilder.DeleteData(
                table: "asp_net_users",
                keyColumn: "id",
                keyValue: new Guid("d63125c0-4c0d-459b-bf19-7be15ba38405"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc16"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc17"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc27"));

            migrationBuilder.DeleteData(
                table: "profiles",
                keyColumn: "id",
                keyValue: new Guid("233f9479-34e3-46f3-b992-b70897ad50a1"));

            migrationBuilder.InsertData(
                table: "asp_net_roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { new Guid("3c21b629-a968-4fe2-9fee-22be79d0a223"), "bad94c1a-cf63-40a4-993b-203791f7e6c1", "USER", "USER" },
                    { new Guid("44d34c23-263a-4541-a6ba-ddcdc6e6bc9d"), "64453c07-a1a5-40c6-9fc7-8f6fad3d2a6a", "ADMIN", "ADMIN" },
                    { new Guid("93fdb1c0-d000-42ae-8cee-287c5c7031fa"), "9e7781de-629e-4904-a088-b09250a75e96", "ROOT", "ROOT" }
                });

            migrationBuilder.InsertData(
                table: "module_permissions",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("008b147a-235a-4e6c-a675-e42a89f15d95"), "Administration Module" },
                    { new Guid("0c78ee77-95e7-44d9-bd83-e30439232f84"), "Security Module" },
                    { new Guid("be996882-2dda-492e-bc67-006c2c1ebab3"), "Dashboard Module" }
                });

            migrationBuilder.InsertData(
                table: "profiles",
                columns: new[] { "id", "avatar_url", "first_name", "last_name" },
                values: new object[] { new Guid("1fd5e9d9-11da-4163-8f18-08f1e4299776"), null, "Jason", "White" });

            migrationBuilder.InsertData(
                table: "asp_net_users",
                columns: new[] { "id", "access_failed_count", "concurrency_stamp", "email", "email_confirmed", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "profile_id", "security_stamp", "two_factor_enabled", "user_name" },
                values: new object[] { new Guid("d9f178d0-a1bf-4d93-b13f-dd9328c80b3a"), 0, "8320340d-7380-4f4f-be11-52744cca1187", "jmw5598@gmail.com", true, false, null, "JMW5598@gmail.com", "JMW5598@GMAIL.COM", "AQAAAAEAACcQAAAAEBGpxH1Uz9p1POltxkyiEMQsJU+K5wJDDysFc8qlGe9A0aZwOKC1TUgT1GDwzPehnA==", null, false, new Guid("1fd5e9d9-11da-4163-8f18-08f1e4299776"), null, false, "jmw5598@gmail.com" });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "module_permission_id", "name" },
                values: new object[,]
                {
                    { new Guid("8c04ef5c-3cc9-447e-bd8d-669abf5801d6"), new Guid("be996882-2dda-492e-bc67-006c2c1ebab3"), "Dashboard Overview" },
                    { new Guid("8e6ecacb-d781-4760-946a-fcf4f1b0d4cc"), new Guid("008b147a-235a-4e6c-a675-e42a89f15d95"), "Settings" },
                    { new Guid("9399ac6c-1c9a-4803-bfae-ec4ddc41341d"), new Guid("0c78ee77-95e7-44d9-bd83-e30439232f84"), "Security Permissions" },
                    { new Guid("b06e333b-7cc6-44d5-ad37-7effba966572"), new Guid("0c78ee77-95e7-44d9-bd83-e30439232f84"), "Security General" },
                    { new Guid("ee62f516-df49-4105-af41-164f20aa13cc"), new Guid("008b147a-235a-4e6c-a675-e42a89f15d95"), "User Accounts" }
                });

            migrationBuilder.InsertData(
                table: "asp_net_user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("3c21b629-a968-4fe2-9fee-22be79d0a223"), new Guid("d9f178d0-a1bf-4d93-b13f-dd9328c80b3a") },
                    { new Guid("44d34c23-263a-4541-a6ba-ddcdc6e6bc9d"), new Guid("d9f178d0-a1bf-4d93-b13f-dd9328c80b3a") },
                    { new Guid("93fdb1c0-d000-42ae-8cee-287c5c7031fa"), new Guid("d9f178d0-a1bf-4d93-b13f-dd9328c80b3a") }
                });
        }
    }
}
