using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Infrastructure.Migrations
{
    public partial class AddedNavigationalPropertyOnTemplateModulePermissionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("29e4d578-9ed5-4acf-9538-13f7b2d36ad8"), "Dashboard Module" },
                    { new Guid("380abf0f-8863-4161-8e10-bc2ce75acd9e"), "Administration Module" },
                    { new Guid("f5307d0f-9c16-43db-9d27-5d5f837f9526"), "Security Module" }
                });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "module_permission_id", "name" },
                values: new object[,]
                {
                    { new Guid("276b957c-40a2-4cd8-b30e-20d20a522408"), new Guid("f5307d0f-9c16-43db-9d27-5d5f837f9526"), "Security General" },
                    { new Guid("4ae259e8-2628-476d-8a0e-ddb665163d3d"), new Guid("380abf0f-8863-4161-8e10-bc2ce75acd9e"), "User Accounts" },
                    { new Guid("72d9c873-e7d2-41b6-9150-1384746ac4ab"), new Guid("380abf0f-8863-4161-8e10-bc2ce75acd9e"), "Settings" },
                    { new Guid("c856c8be-f628-4fa3-b2e5-905a16f1cfa0"), new Guid("29e4d578-9ed5-4acf-9538-13f7b2d36ad8"), "Dashboard Overview" },
                    { new Guid("d0537ea4-6f20-4bcd-9e36-10044d490296"), new Guid("f5307d0f-9c16-43db-9d27-5d5f837f9526"), "Security Permissions" }
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: new Guid("276b957c-40a2-4cd8-b30e-20d20a522408"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("4ae259e8-2628-476d-8a0e-ddb665163d3d"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("72d9c873-e7d2-41b6-9150-1384746ac4ab"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("c856c8be-f628-4fa3-b2e5-905a16f1cfa0"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("d0537ea4-6f20-4bcd-9e36-10044d490296"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("29e4d578-9ed5-4acf-9538-13f7b2d36ad8"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("380abf0f-8863-4161-8e10-bc2ce75acd9e"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("f5307d0f-9c16-43db-9d27-5d5f837f9526"));

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
    }
}
