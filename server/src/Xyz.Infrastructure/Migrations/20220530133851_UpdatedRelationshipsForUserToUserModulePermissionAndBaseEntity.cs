using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Infrastructure.Migrations
{
    public partial class UpdatedRelationshipsForUserToUserModulePermissionAndBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("2f3d6be4-2eab-4011-aed9-fc81fea7c130"), new Guid("f5e67db3-e447-4357-961a-892ce1d5b6f8") });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("35072c12-05ff-4cda-b1b0-8405e49fbeb6"), new Guid("f5e67db3-e447-4357-961a-892ce1d5b6f8") });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("66e15c21-cd33-4f94-8b49-765d689deb1d"), new Guid("f5e67db3-e447-4357-961a-892ce1d5b6f8") });

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("5ebed63a-e080-462b-a559-f641e5b5e0dd"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("7baa7483-440c-48de-ad93-540671d4d9ae"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("b07b71df-cd8b-4714-aad5-2ee334216f7e"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("d96e7a54-98c3-4c2b-b19b-1a2774e34f89"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("d97f39a8-4d27-4d2a-8160-29418cb4974f"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("2f3d6be4-2eab-4011-aed9-fc81fea7c130"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("35072c12-05ff-4cda-b1b0-8405e49fbeb6"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("66e15c21-cd33-4f94-8b49-765d689deb1d"));

            migrationBuilder.DeleteData(
                table: "asp_net_users",
                keyColumn: "id",
                keyValue: new Guid("f5e67db3-e447-4357-961a-892ce1d5b6f8"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("4cbbada9-b587-4a02-8368-7f76eaf38eea"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("e55d82c2-5f3b-456d-bd18-9cd0abcd687d"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("e9184f74-cf03-4a9e-9018-0c9643ff3a04"));

            migrationBuilder.DeleteData(
                table: "profiles",
                keyColumn: "id",
                keyValue: new Guid("58b69496-609d-4777-8ee6-1c2a6f1d14e0"));

            migrationBuilder.RenameColumn(
                name: "asp_net_user_id",
                table: "user_module_permissions",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "ix_user_module_permissions_asp_net_user_id",
                table: "user_module_permissions",
                newName: "ix_user_module_permissions_user_id");

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                table: "vehicles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "updated_by_id",
                table: "vehicles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                table: "vehicle_types",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "updated_by_id",
                table: "vehicle_types",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                table: "vehicle_models",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "updated_by_id",
                table: "vehicle_models",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                table: "vehicle_makes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "updated_by_id",
                table: "vehicle_makes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                table: "template_module_permission_names",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "updated_by_id",
                table: "template_module_permission_names",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "asp_net_roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { new Guid("77f3871c-a8ad-47d4-8634-45d1aa843c99"), "51a63b35-efad-44c7-b2a5-80d35a2bb7b4", "ADMIN", "ADMIN" },
                    { new Guid("94653a75-4a52-4af3-b194-1c856db5999f"), "b3ce7c60-cd9c-4bd6-95d3-1cf9fd277967", "USER", "USER" },
                    { new Guid("c502c688-3ce1-4d22-bbc3-c01ae8a5b31e"), "7e580def-6e69-4e1f-aa38-5e51dc65bea4", "ROOT", "ROOT" }
                });

            migrationBuilder.InsertData(
                table: "module_permissions",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("4b22cedd-e1ee-4ebe-a428-611f8e5d1cd8"), "Dashboard Module" },
                    { new Guid("c4d9e0d6-c463-460a-8fff-1a985abbbbc7"), "Administration Module" },
                    { new Guid("df59d9a4-b645-41dd-b4cc-cb96193ddf5a"), "Security Module" }
                });

            migrationBuilder.InsertData(
                table: "profiles",
                columns: new[] { "id", "avatar_url", "first_name", "last_name" },
                values: new object[] { new Guid("215890fe-c504-4859-bb18-d1aef06df1f8"), null, "Jason", "White" });

            migrationBuilder.InsertData(
                table: "asp_net_users",
                columns: new[] { "id", "access_failed_count", "concurrency_stamp", "email", "email_confirmed", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "profile_id", "security_stamp", "two_factor_enabled", "user_name" },
                values: new object[] { new Guid("2cba2e3a-ff88-4539-b688-e62f6bfd9651"), 0, "1bd4426d-803e-48d5-b660-e5b0ab1e9f1e", "jmw5598@gmail.com", true, false, null, "JMW5598@gmail.com", "JMW5598@GMAIL.COM", "AQAAAAEAACcQAAAAEEwkwwpArR8MGNXeKg5ehw0Kyq0F6RREPUirika+Piu7C36JhST8M28xPqo7MpnAbQ==", null, false, new Guid("215890fe-c504-4859-bb18-d1aef06df1f8"), null, false, "jmw5598@gmail.com" });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "module_permission_id", "name" },
                values: new object[,]
                {
                    { new Guid("49889c3a-1652-4fc3-9381-e126642f7823"), new Guid("c4d9e0d6-c463-460a-8fff-1a985abbbbc7"), "User Accounts" },
                    { new Guid("697ddfb1-551c-49f2-951e-6878741afa25"), new Guid("c4d9e0d6-c463-460a-8fff-1a985abbbbc7"), "Settings" },
                    { new Guid("6ee950e1-f6f1-4e79-9ba7-e2cc5be4b452"), new Guid("df59d9a4-b645-41dd-b4cc-cb96193ddf5a"), "Security General" },
                    { new Guid("cf82079a-20a2-4785-b238-369f5c561b05"), new Guid("4b22cedd-e1ee-4ebe-a428-611f8e5d1cd8"), "Dashboard Overview" },
                    { new Guid("f3251c41-883e-4b73-8408-98e7e123ffb8"), new Guid("df59d9a4-b645-41dd-b4cc-cb96193ddf5a"), "Security Permissions" }
                });

            migrationBuilder.InsertData(
                table: "asp_net_user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("77f3871c-a8ad-47d4-8634-45d1aa843c99"), new Guid("2cba2e3a-ff88-4539-b688-e62f6bfd9651") },
                    { new Guid("94653a75-4a52-4af3-b194-1c856db5999f"), new Guid("2cba2e3a-ff88-4539-b688-e62f6bfd9651") },
                    { new Guid("c502c688-3ce1-4d22-bbc3-c01ae8a5b31e"), new Guid("2cba2e3a-ff88-4539-b688-e62f6bfd9651") }
                });

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_created_by_id",
                table: "vehicles",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_updated_by_id",
                table: "vehicles",
                column: "updated_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicle_types_created_by_id",
                table: "vehicle_types",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicle_types_updated_by_id",
                table: "vehicle_types",
                column: "updated_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicle_models_created_by_id",
                table: "vehicle_models",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicle_models_updated_by_id",
                table: "vehicle_models",
                column: "updated_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicle_makes_created_by_id",
                table: "vehicle_makes",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicle_makes_updated_by_id",
                table: "vehicle_makes",
                column: "updated_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_template_module_permission_names_created_by_id",
                table: "template_module_permission_names",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_template_module_permission_names_updated_by_id",
                table: "template_module_permission_names",
                column: "updated_by_id");

            migrationBuilder.AddForeignKey(
                name: "fk_template_module_permission_names_users_created_by_id",
                table: "template_module_permission_names",
                column: "created_by_id",
                principalTable: "asp_net_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_template_module_permission_names_users_updated_by_id",
                table: "template_module_permission_names",
                column: "updated_by_id",
                principalTable: "asp_net_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_module_permissions_users_user_id",
                table: "user_module_permissions",
                column: "user_id",
                principalTable: "asp_net_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicle_makes_users_created_by_id",
                table: "vehicle_makes",
                column: "created_by_id",
                principalTable: "asp_net_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicle_makes_users_updated_by_id",
                table: "vehicle_makes",
                column: "updated_by_id",
                principalTable: "asp_net_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicle_models_users_created_by_id",
                table: "vehicle_models",
                column: "created_by_id",
                principalTable: "asp_net_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicle_models_users_updated_by_id",
                table: "vehicle_models",
                column: "updated_by_id",
                principalTable: "asp_net_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicle_types_users_created_by_id",
                table: "vehicle_types",
                column: "created_by_id",
                principalTable: "asp_net_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicle_types_users_updated_by_id",
                table: "vehicle_types",
                column: "updated_by_id",
                principalTable: "asp_net_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicles_users_created_by_id",
                table: "vehicles",
                column: "created_by_id",
                principalTable: "asp_net_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicles_users_updated_by_id",
                table: "vehicles",
                column: "updated_by_id",
                principalTable: "asp_net_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_template_module_permission_names_users_created_by_id",
                table: "template_module_permission_names");

            migrationBuilder.DropForeignKey(
                name: "fk_template_module_permission_names_users_updated_by_id",
                table: "template_module_permission_names");

            migrationBuilder.DropForeignKey(
                name: "fk_user_module_permissions_users_user_id",
                table: "user_module_permissions");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicle_makes_users_created_by_id",
                table: "vehicle_makes");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicle_makes_users_updated_by_id",
                table: "vehicle_makes");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicle_models_users_created_by_id",
                table: "vehicle_models");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicle_models_users_updated_by_id",
                table: "vehicle_models");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicle_types_users_created_by_id",
                table: "vehicle_types");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicle_types_users_updated_by_id",
                table: "vehicle_types");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_users_created_by_id",
                table: "vehicles");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_users_updated_by_id",
                table: "vehicles");

            migrationBuilder.DropIndex(
                name: "ix_vehicles_created_by_id",
                table: "vehicles");

            migrationBuilder.DropIndex(
                name: "ix_vehicles_updated_by_id",
                table: "vehicles");

            migrationBuilder.DropIndex(
                name: "ix_vehicle_types_created_by_id",
                table: "vehicle_types");

            migrationBuilder.DropIndex(
                name: "ix_vehicle_types_updated_by_id",
                table: "vehicle_types");

            migrationBuilder.DropIndex(
                name: "ix_vehicle_models_created_by_id",
                table: "vehicle_models");

            migrationBuilder.DropIndex(
                name: "ix_vehicle_models_updated_by_id",
                table: "vehicle_models");

            migrationBuilder.DropIndex(
                name: "ix_vehicle_makes_created_by_id",
                table: "vehicle_makes");

            migrationBuilder.DropIndex(
                name: "ix_vehicle_makes_updated_by_id",
                table: "vehicle_makes");

            migrationBuilder.DropIndex(
                name: "ix_template_module_permission_names_created_by_id",
                table: "template_module_permission_names");

            migrationBuilder.DropIndex(
                name: "ix_template_module_permission_names_updated_by_id",
                table: "template_module_permission_names");

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("77f3871c-a8ad-47d4-8634-45d1aa843c99"), new Guid("2cba2e3a-ff88-4539-b688-e62f6bfd9651") });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("94653a75-4a52-4af3-b194-1c856db5999f"), new Guid("2cba2e3a-ff88-4539-b688-e62f6bfd9651") });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("c502c688-3ce1-4d22-bbc3-c01ae8a5b31e"), new Guid("2cba2e3a-ff88-4539-b688-e62f6bfd9651") });

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("49889c3a-1652-4fc3-9381-e126642f7823"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("697ddfb1-551c-49f2-951e-6878741afa25"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("6ee950e1-f6f1-4e79-9ba7-e2cc5be4b452"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("cf82079a-20a2-4785-b238-369f5c561b05"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("f3251c41-883e-4b73-8408-98e7e123ffb8"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("77f3871c-a8ad-47d4-8634-45d1aa843c99"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("94653a75-4a52-4af3-b194-1c856db5999f"));

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("c502c688-3ce1-4d22-bbc3-c01ae8a5b31e"));

            migrationBuilder.DeleteData(
                table: "asp_net_users",
                keyColumn: "id",
                keyValue: new Guid("2cba2e3a-ff88-4539-b688-e62f6bfd9651"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("4b22cedd-e1ee-4ebe-a428-611f8e5d1cd8"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("c4d9e0d6-c463-460a-8fff-1a985abbbbc7"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("df59d9a4-b645-41dd-b4cc-cb96193ddf5a"));

            migrationBuilder.DeleteData(
                table: "profiles",
                keyColumn: "id",
                keyValue: new Guid("215890fe-c504-4859-bb18-d1aef06df1f8"));

            migrationBuilder.DropColumn(
                name: "created_by_id",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "updated_by_id",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                table: "vehicle_types");

            migrationBuilder.DropColumn(
                name: "updated_by_id",
                table: "vehicle_types");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                table: "vehicle_models");

            migrationBuilder.DropColumn(
                name: "updated_by_id",
                table: "vehicle_models");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                table: "vehicle_makes");

            migrationBuilder.DropColumn(
                name: "updated_by_id",
                table: "vehicle_makes");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                table: "template_module_permission_names");

            migrationBuilder.DropColumn(
                name: "updated_by_id",
                table: "template_module_permission_names");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "user_module_permissions",
                newName: "asp_net_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_user_module_permissions_user_id",
                table: "user_module_permissions",
                newName: "ix_user_module_permissions_asp_net_user_id");

            migrationBuilder.InsertData(
                table: "asp_net_roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { new Guid("2f3d6be4-2eab-4011-aed9-fc81fea7c130"), "cf0f5280-d0e7-4a22-b16b-47fe6fb48878", "USER", "USER" },
                    { new Guid("35072c12-05ff-4cda-b1b0-8405e49fbeb6"), "43bcf0f5-7643-43d7-8e73-05a32d6a5cdf", "ADMIN", "ADMIN" },
                    { new Guid("66e15c21-cd33-4f94-8b49-765d689deb1d"), "c44bfa05-ace3-4a31-bd9a-0de0739905cb", "ROOT", "ROOT" }
                });

            migrationBuilder.InsertData(
                table: "module_permissions",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("4cbbada9-b587-4a02-8368-7f76eaf38eea"), "Dashboard Module" },
                    { new Guid("e55d82c2-5f3b-456d-bd18-9cd0abcd687d"), "Security Module" },
                    { new Guid("e9184f74-cf03-4a9e-9018-0c9643ff3a04"), "Administration Module" }
                });

            migrationBuilder.InsertData(
                table: "profiles",
                columns: new[] { "id", "avatar_url", "first_name", "last_name" },
                values: new object[] { new Guid("58b69496-609d-4777-8ee6-1c2a6f1d14e0"), null, "Jason", "White" });

            migrationBuilder.InsertData(
                table: "asp_net_users",
                columns: new[] { "id", "access_failed_count", "concurrency_stamp", "email", "email_confirmed", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "profile_id", "security_stamp", "two_factor_enabled", "user_name" },
                values: new object[] { new Guid("f5e67db3-e447-4357-961a-892ce1d5b6f8"), 0, "2a9783b8-ae03-4707-bf55-c4c303f7d035", "jmw5598@gmail.com", true, false, null, "JMW5598@gmail.com", "JMW5598@GMAIL.COM", "AQAAAAEAACcQAAAAELwCJjmbfp6nIH70iomkE/DmTPoTbdZ9RMFDPrgietY6RTCrBcjEQOlRaIWzAAtPHw==", null, false, new Guid("58b69496-609d-4777-8ee6-1c2a6f1d14e0"), null, false, "jmw5598@gmail.com" });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "module_permission_id", "name" },
                values: new object[,]
                {
                    { new Guid("5ebed63a-e080-462b-a559-f641e5b5e0dd"), new Guid("e9184f74-cf03-4a9e-9018-0c9643ff3a04"), "Settings" },
                    { new Guid("7baa7483-440c-48de-ad93-540671d4d9ae"), new Guid("4cbbada9-b587-4a02-8368-7f76eaf38eea"), "Dashboard Overview" },
                    { new Guid("b07b71df-cd8b-4714-aad5-2ee334216f7e"), new Guid("e9184f74-cf03-4a9e-9018-0c9643ff3a04"), "User Accounts" },
                    { new Guid("d96e7a54-98c3-4c2b-b19b-1a2774e34f89"), new Guid("e55d82c2-5f3b-456d-bd18-9cd0abcd687d"), "Security General" },
                    { new Guid("d97f39a8-4d27-4d2a-8160-29418cb4974f"), new Guid("e55d82c2-5f3b-456d-bd18-9cd0abcd687d"), "Security Permissions" }
                });

            migrationBuilder.InsertData(
                table: "asp_net_user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("2f3d6be4-2eab-4011-aed9-fc81fea7c130"), new Guid("f5e67db3-e447-4357-961a-892ce1d5b6f8") },
                    { new Guid("35072c12-05ff-4cda-b1b0-8405e49fbeb6"), new Guid("f5e67db3-e447-4357-961a-892ce1d5b6f8") },
                    { new Guid("66e15c21-cd33-4f94-8b49-765d689deb1d"), new Guid("f5e67db3-e447-4357-961a-892ce1d5b6f8") }
                });
        }
    }
}
