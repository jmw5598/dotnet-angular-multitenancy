using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Infrastructure.Migrations
{
    public partial class AddsColumnOrderAttributeToBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_on",
                table: "vehicles",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<Guid>(
                name: "updated_by_id",
                table: "vehicles",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<DateTime>(
                name: "delete_on",
                table: "vehicles",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "vehicles",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<Guid>(
                name: "created_by_id",
                table: "vehicles",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "vehicles",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_on",
                table: "vehicle_types",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<Guid>(
                name: "updated_by_id",
                table: "vehicle_types",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<DateTime>(
                name: "delete_on",
                table: "vehicle_types",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "vehicle_types",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<Guid>(
                name: "created_by_id",
                table: "vehicle_types",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "vehicle_types",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_on",
                table: "vehicle_models",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<Guid>(
                name: "updated_by_id",
                table: "vehicle_models",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<DateTime>(
                name: "delete_on",
                table: "vehicle_models",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "vehicle_models",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<Guid>(
                name: "created_by_id",
                table: "vehicle_models",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "vehicle_models",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_on",
                table: "vehicle_makes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<Guid>(
                name: "updated_by_id",
                table: "vehicle_makes",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<DateTime>(
                name: "delete_on",
                table: "vehicle_makes",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "vehicle_makes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<Guid>(
                name: "created_by_id",
                table: "vehicle_makes",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "vehicle_makes",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_on",
                table: "template_module_permission_names",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<Guid>(
                name: "updated_by_id",
                table: "template_module_permission_names",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<DateTime>(
                name: "delete_on",
                table: "template_module_permission_names",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "template_module_permission_names",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<Guid>(
                name: "created_by_id",
                table: "template_module_permission_names",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "template_module_permission_names",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_on",
                table: "vehicles",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<Guid>(
                name: "updated_by_id",
                table: "vehicles",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<DateTime>(
                name: "delete_on",
                table: "vehicles",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "vehicles",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<Guid>(
                name: "created_by_id",
                table: "vehicles",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "vehicles",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_on",
                table: "vehicle_types",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<Guid>(
                name: "updated_by_id",
                table: "vehicle_types",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<DateTime>(
                name: "delete_on",
                table: "vehicle_types",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "vehicle_types",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<Guid>(
                name: "created_by_id",
                table: "vehicle_types",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "vehicle_types",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_on",
                table: "vehicle_models",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<Guid>(
                name: "updated_by_id",
                table: "vehicle_models",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<DateTime>(
                name: "delete_on",
                table: "vehicle_models",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "vehicle_models",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<Guid>(
                name: "created_by_id",
                table: "vehicle_models",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "vehicle_models",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_on",
                table: "vehicle_makes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<Guid>(
                name: "updated_by_id",
                table: "vehicle_makes",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<DateTime>(
                name: "delete_on",
                table: "vehicle_makes",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "vehicle_makes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<Guid>(
                name: "created_by_id",
                table: "vehicle_makes",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "vehicle_makes",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_on",
                table: "template_module_permission_names",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<Guid>(
                name: "updated_by_id",
                table: "template_module_permission_names",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<DateTime>(
                name: "delete_on",
                table: "template_module_permission_names",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "template_module_permission_names",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<Guid>(
                name: "created_by_id",
                table: "template_module_permission_names",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "template_module_permission_names",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .OldAnnotation("Relational:ColumnOrder", 0);

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
        }
    }
}
