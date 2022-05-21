using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Infrastructure.Migrations
{
    public partial class AddsBaseEnttiyAndDescriptionPropertiesToTemplateModulePermissionNameEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("142c596f-c655-4274-8dae-1d21cbfa4a40"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("4fa7caa6-5a7a-4789-b0c4-292d48370bf9"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("5d02be93-cb3a-49f3-8628-58b0916fa9e1"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("75f0f7b9-dac3-4f10-8c49-9bd2f45a5bb3"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("c870ccc6-6daf-43ec-8de8-99d24a0ba2e5"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("57945f00-f133-4937-ac23-191ff70c5eac"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("83f75318-b173-4a57-a3d8-3122cd2d30f1"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("b63b63a0-7acf-4874-8169-753348ff41e5"));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_on",
                table: "template_module_permission_names",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "delete_on",
                table: "template_module_permission_names",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "template_module_permission_names",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_on",
                table: "template_module_permission_names",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "module_permissions",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("9c4b9ac3-049b-4ca4-a3ee-31feb38db5aa"), "Administration Module" },
                    { new Guid("bbbd9612-79ba-4eff-98c6-e8b4adeaa8e1"), "Dashboard Module" },
                    { new Guid("ff7b5436-680a-439f-92f2-0c1d94063a0e"), "Security Module" }
                });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "module_permission_id", "name" },
                values: new object[,]
                {
                    { new Guid("1b7e0a04-0b20-43bf-8b3f-e55aeff03eca"), new Guid("bbbd9612-79ba-4eff-98c6-e8b4adeaa8e1"), "Dashboard Overview" },
                    { new Guid("2f81c044-9412-47d2-a64b-5dca08b98c97"), new Guid("ff7b5436-680a-439f-92f2-0c1d94063a0e"), "Security General" },
                    { new Guid("659c145c-9cb3-44a1-9460-33ce62fe2a1a"), new Guid("9c4b9ac3-049b-4ca4-a3ee-31feb38db5aa"), "Settings" },
                    { new Guid("a5446dd7-49d8-47df-a6a6-1dd7e19db66f"), new Guid("9c4b9ac3-049b-4ca4-a3ee-31feb38db5aa"), "User Accounts" },
                    { new Guid("e792babe-a410-436f-8f4b-bcae9d71423f"), new Guid("ff7b5436-680a-439f-92f2-0c1d94063a0e"), "Security Permissions" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("1b7e0a04-0b20-43bf-8b3f-e55aeff03eca"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("2f81c044-9412-47d2-a64b-5dca08b98c97"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("659c145c-9cb3-44a1-9460-33ce62fe2a1a"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("a5446dd7-49d8-47df-a6a6-1dd7e19db66f"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("e792babe-a410-436f-8f4b-bcae9d71423f"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("9c4b9ac3-049b-4ca4-a3ee-31feb38db5aa"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("bbbd9612-79ba-4eff-98c6-e8b4adeaa8e1"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("ff7b5436-680a-439f-92f2-0c1d94063a0e"));

            migrationBuilder.DropColumn(
                name: "created_on",
                table: "template_module_permission_names");

            migrationBuilder.DropColumn(
                name: "delete_on",
                table: "template_module_permission_names");

            migrationBuilder.DropColumn(
                name: "description",
                table: "template_module_permission_names");

            migrationBuilder.DropColumn(
                name: "updated_on",
                table: "template_module_permission_names");

            migrationBuilder.InsertData(
                table: "module_permissions",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("57945f00-f133-4937-ac23-191ff70c5eac"), "Administration Module" },
                    { new Guid("83f75318-b173-4a57-a3d8-3122cd2d30f1"), "Dashboard Module" },
                    { new Guid("b63b63a0-7acf-4874-8169-753348ff41e5"), "Security Module" }
                });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "module_permission_id", "name" },
                values: new object[,]
                {
                    { new Guid("142c596f-c655-4274-8dae-1d21cbfa4a40"), new Guid("83f75318-b173-4a57-a3d8-3122cd2d30f1"), "Dashboard Overview" },
                    { new Guid("4fa7caa6-5a7a-4789-b0c4-292d48370bf9"), new Guid("b63b63a0-7acf-4874-8169-753348ff41e5"), "Security General" },
                    { new Guid("5d02be93-cb3a-49f3-8628-58b0916fa9e1"), new Guid("57945f00-f133-4937-ac23-191ff70c5eac"), "Settings" },
                    { new Guid("75f0f7b9-dac3-4f10-8c49-9bd2f45a5bb3"), new Guid("b63b63a0-7acf-4874-8169-753348ff41e5"), "Security Permissions" },
                    { new Guid("c870ccc6-6daf-43ec-8de8-99d24a0ba2e5"), new Guid("57945f00-f133-4937-ac23-191ff70c5eac"), "User Accounts" }
                });
        }
    }
}
