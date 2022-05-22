using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Infrastructure.Migrations
{
    public partial class UpdatedPropertiesOnTemplateModulePermissionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_template_permissions_template_module_permissions_template_m",
                table: "template_permissions");

            migrationBuilder.DropIndex(
                name: "ix_template_permissions_template_module_permission_id",
                table: "template_permissions");

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

            migrationBuilder.InsertData(
                table: "module_permissions",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("10864688-840b-4b14-ac2b-e63fb52b46d4"), "Security Module" },
                    { new Guid("7fb03136-60de-4013-8c7b-1453a4b0446a"), "Dashboard Module" },
                    { new Guid("a71c42c1-20d1-4c8c-b365-e62726a69ad7"), "Administration Module" }
                });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "module_permission_id", "name" },
                values: new object[,]
                {
                    { new Guid("3222fc30-e464-434a-9c4b-1bcb71f62eaa"), new Guid("7fb03136-60de-4013-8c7b-1453a4b0446a"), "Dashboard Overview" },
                    { new Guid("72954492-4548-4293-ac10-35e74628349c"), new Guid("a71c42c1-20d1-4c8c-b365-e62726a69ad7"), "User Accounts" },
                    { new Guid("c7503fca-99ba-4dc8-a1bc-833bec310975"), new Guid("a71c42c1-20d1-4c8c-b365-e62726a69ad7"), "Settings" },
                    { new Guid("d2f64db1-357d-4559-a221-9cb625ebd50d"), new Guid("10864688-840b-4b14-ac2b-e63fb52b46d4"), "Security Permissions" },
                    { new Guid("fe56e6b1-03be-41a9-8f9c-8a0f34564684"), new Guid("10864688-840b-4b14-ac2b-e63fb52b46d4"), "Security General" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("3222fc30-e464-434a-9c4b-1bcb71f62eaa"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("72954492-4548-4293-ac10-35e74628349c"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("c7503fca-99ba-4dc8-a1bc-833bec310975"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("d2f64db1-357d-4559-a221-9cb625ebd50d"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("fe56e6b1-03be-41a9-8f9c-8a0f34564684"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("10864688-840b-4b14-ac2b-e63fb52b46d4"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("7fb03136-60de-4013-8c7b-1453a4b0446a"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("a71c42c1-20d1-4c8c-b365-e62726a69ad7"));

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

            migrationBuilder.CreateIndex(
                name: "ix_template_permissions_template_module_permission_id",
                table: "template_permissions",
                column: "template_module_permission_id");

            migrationBuilder.AddForeignKey(
                name: "fk_template_permissions_template_module_permissions_template_m",
                table: "template_permissions",
                column: "template_module_permission_id",
                principalTable: "template_module_permissions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
