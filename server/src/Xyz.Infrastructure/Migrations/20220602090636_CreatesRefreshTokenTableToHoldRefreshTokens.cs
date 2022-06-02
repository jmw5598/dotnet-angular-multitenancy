using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Infrastructure.Migrations
{
    public partial class CreatesRefreshTokenTableToHoldRefreshTokens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "profiles",
                keyColumn: "id",
                keyValue: new Guid("233f9479-34e3-46f3-b992-b70897ad50a1"));

            migrationBuilder.CreateTable(
                name: "refresh_tokens",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    token = table.Column<Guid>(type: "uuid", nullable: false),
                    is_blacklisted = table.Column<bool>(type: "boolean", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_refresh_tokens", x => x.id);
                    table.ForeignKey(
                        name: "fk_refresh_tokens_users_user_id",
                        column: x => x.user_id,
                        principalTable: "asp_net_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac22"),
                column: "concurrency_stamp",
                value: "9ea7d496-988c-4e7d-8dae-f215de561ea2");

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac27"),
                column: "concurrency_stamp",
                value: "f2fb624d-193b-45cc-b54c-475cd0edcd78");

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac28"),
                column: "concurrency_stamp",
                value: "8e33ee6c-be53-424b-9177-9543ecf90b98");

            migrationBuilder.InsertData(
                table: "profiles",
                columns: new[] { "id", "avatar_url", "first_name", "last_name" },
                values: new object[] { new Guid("a716ef02-8030-4eba-a61b-9fd4020ca579"), null, "Jason", "White" });

            migrationBuilder.InsertData(
                table: "asp_net_users",
                columns: new[] { "id", "access_failed_count", "concurrency_stamp", "email", "email_confirmed", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "profile_id", "security_stamp", "two_factor_enabled", "user_name" },
                values: new object[] { new Guid("1b0ba72f-9d36-41a0-87d1-98484f91b193"), 0, "8dc21503-d697-4989-8916-54d6c733c25a", "jmw5598@gmail.com", true, false, null, "JMW5598@gmail.com", "JMW5598@GMAIL.COM", "AQAAAAEAACcQAAAAEN1mCEkZS7cLuZfGgMvCNS0OIzwZ0KIfwHWgx2M2kWANYJlTHsBM7DbQTcfYEIK6xw==", null, false, new Guid("a716ef02-8030-4eba-a61b-9fd4020ca579"), null, false, "jmw5598@gmail.com" });

            migrationBuilder.InsertData(
                table: "asp_net_user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac22"), new Guid("1b0ba72f-9d36-41a0-87d1-98484f91b193") },
                    { new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac27"), new Guid("1b0ba72f-9d36-41a0-87d1-98484f91b193") },
                    { new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac28"), new Guid("1b0ba72f-9d36-41a0-87d1-98484f91b193") }
                });

            migrationBuilder.InsertData(
                table: "user_module_permissions",
                columns: new[] { "id", "has_access", "module_permission_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("032c5065-167b-407a-b3d7-0422810c71f0"), true, new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc16"), new Guid("1b0ba72f-9d36-41a0-87d1-98484f91b193") },
                    { new Guid("7d500527-d1ce-45df-b027-6ac778182f36"), true, new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc27"), new Guid("1b0ba72f-9d36-41a0-87d1-98484f91b193") },
                    { new Guid("f67ff374-7c21-4ad1-9dac-9ddcc4a45e52"), true, new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc17"), new Guid("1b0ba72f-9d36-41a0-87d1-98484f91b193") }
                });

            migrationBuilder.InsertData(
                table: "user_permissions",
                columns: new[] { "id", "can_create", "can_delete", "can_read", "can_update", "permission_id", "user_module_permission_id" },
                values: new object[,]
                {
                    { new Guid("1a5bc43b-504d-450d-8289-c06fee39f554"), true, true, true, true, new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacd27"), new Guid("032c5065-167b-407a-b3d7-0422810c71f0") },
                    { new Guid("2c2aaab5-1da2-4f60-83cc-32089044c0bb"), true, true, true, true, new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc22"), new Guid("7d500527-d1ce-45df-b027-6ac778182f36") },
                    { new Guid("9ccf3065-c7b7-45f3-906f-02dafc956fdf"), true, true, true, true, new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc07"), new Guid("f67ff374-7c21-4ad1-9dac-9ddcc4a45e52") },
                    { new Guid("c3920c92-d728-487f-a58c-8ee873b3cea6"), true, true, true, true, new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc11"), new Guid("032c5065-167b-407a-b3d7-0422810c71f0") },
                    { new Guid("d70742c7-9b12-49c7-90ca-1712c827aa64"), true, true, true, true, new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc21"), new Guid("7d500527-d1ce-45df-b027-6ac778182f36") }
                });

            migrationBuilder.CreateIndex(
                name: "ix_refresh_tokens_user_id",
                table: "refresh_tokens",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "refresh_tokens");

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac22"), new Guid("1b0ba72f-9d36-41a0-87d1-98484f91b193") });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac27"), new Guid("1b0ba72f-9d36-41a0-87d1-98484f91b193") });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac28"), new Guid("1b0ba72f-9d36-41a0-87d1-98484f91b193") });

            migrationBuilder.DeleteData(
                table: "user_permissions",
                keyColumn: "id",
                keyValue: new Guid("1a5bc43b-504d-450d-8289-c06fee39f554"));

            migrationBuilder.DeleteData(
                table: "user_permissions",
                keyColumn: "id",
                keyValue: new Guid("2c2aaab5-1da2-4f60-83cc-32089044c0bb"));

            migrationBuilder.DeleteData(
                table: "user_permissions",
                keyColumn: "id",
                keyValue: new Guid("9ccf3065-c7b7-45f3-906f-02dafc956fdf"));

            migrationBuilder.DeleteData(
                table: "user_permissions",
                keyColumn: "id",
                keyValue: new Guid("c3920c92-d728-487f-a58c-8ee873b3cea6"));

            migrationBuilder.DeleteData(
                table: "user_permissions",
                keyColumn: "id",
                keyValue: new Guid("d70742c7-9b12-49c7-90ca-1712c827aa64"));

            migrationBuilder.DeleteData(
                table: "user_module_permissions",
                keyColumn: "id",
                keyValue: new Guid("032c5065-167b-407a-b3d7-0422810c71f0"));

            migrationBuilder.DeleteData(
                table: "user_module_permissions",
                keyColumn: "id",
                keyValue: new Guid("7d500527-d1ce-45df-b027-6ac778182f36"));

            migrationBuilder.DeleteData(
                table: "user_module_permissions",
                keyColumn: "id",
                keyValue: new Guid("f67ff374-7c21-4ad1-9dac-9ddcc4a45e52"));

            migrationBuilder.DeleteData(
                table: "asp_net_users",
                keyColumn: "id",
                keyValue: new Guid("1b0ba72f-9d36-41a0-87d1-98484f91b193"));

            migrationBuilder.DeleteData(
                table: "profiles",
                keyColumn: "id",
                keyValue: new Guid("a716ef02-8030-4eba-a61b-9fd4020ca579"));

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac22"),
                column: "concurrency_stamp",
                value: "a915dc6d-6e24-441e-b102-73830a7a5629");

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac27"),
                column: "concurrency_stamp",
                value: "221022b3-38f3-4779-9061-47e379a29fbd");

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac28"),
                column: "concurrency_stamp",
                value: "b593d6fc-922d-427c-8fe4-4c00ef996219");

            migrationBuilder.InsertData(
                table: "profiles",
                columns: new[] { "id", "avatar_url", "first_name", "last_name" },
                values: new object[] { new Guid("233f9479-34e3-46f3-b992-b70897ad50a1"), null, "Jason", "White" });

            migrationBuilder.InsertData(
                table: "asp_net_users",
                columns: new[] { "id", "access_failed_count", "concurrency_stamp", "email", "email_confirmed", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "profile_id", "security_stamp", "two_factor_enabled", "user_name" },
                values: new object[] { new Guid("d63125c0-4c0d-459b-bf19-7be15ba38405"), 0, "a60d68f6-c174-4788-9e4c-64d0061b2fbf", "jmw5598@gmail.com", true, false, null, "JMW5598@gmail.com", "JMW5598@GMAIL.COM", "AQAAAAEAACcQAAAAECYCojMtCjiWOiWkC9mLBIfrGmPaJK4C70LZmB4vd7TNAx8KGzHMwingwx07kOF6+w==", null, false, new Guid("233f9479-34e3-46f3-b992-b70897ad50a1"), null, false, "jmw5598@gmail.com" });

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
    }
}
