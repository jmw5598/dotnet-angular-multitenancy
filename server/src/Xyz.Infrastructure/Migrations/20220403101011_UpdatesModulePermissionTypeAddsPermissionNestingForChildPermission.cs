using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Infrastructure.Migrations
{
    public partial class UpdatesModulePermissionTypeAddsPermissionNestingForChildPermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("782b2c55-dbd6-403f-8c9b-e07145a61cf5"));

            migrationBuilder.AddColumn<Guid>(
                name: "parent_permission_id",
                table: "permissions",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "name", "parent_permission_id", "type" },
                values: new object[] { new Guid("3b3247b2-76d7-4457-80aa-5e7538a9108c"), "Settings Module", null, "SETTINGS" });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "name", "parent_permission_id", "type" },
                values: new object[] { new Guid("8554d348-9156-4063-8b72-aacd4a0be046"), "User Accounts Module", new Guid("3b3247b2-76d7-4457-80aa-5e7538a9108c"), "USER_ACCOUNTS" });

            migrationBuilder.CreateIndex(
                name: "ix_permissions_parent_permission_id",
                table: "permissions",
                column: "parent_permission_id");

            migrationBuilder.AddForeignKey(
                name: "fk_permissions_permissions_parent_permission_id",
                table: "permissions",
                column: "parent_permission_id",
                principalTable: "permissions",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_permissions_permissions_parent_permission_id",
                table: "permissions");

            migrationBuilder.DropIndex(
                name: "ix_permissions_parent_permission_id",
                table: "permissions");

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("8554d348-9156-4063-8b72-aacd4a0be046"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("3b3247b2-76d7-4457-80aa-5e7538a9108c"));

            migrationBuilder.DropColumn(
                name: "parent_permission_id",
                table: "permissions");

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "name", "type" },
                values: new object[] { new Guid("782b2c55-dbd6-403f-8c9b-e07145a61cf5"), "Accounts Module", "ACCOUNTS" });
        }
    }
}
