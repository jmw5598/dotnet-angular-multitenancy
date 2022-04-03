using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Infrastructure.Migrations
{
    public partial class AddsParentUserPermissionRelationshipInUserPermissionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("8554d348-9156-4063-8b72-aacd4a0be046"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("3b3247b2-76d7-4457-80aa-5e7538a9108c"));

            migrationBuilder.AddColumn<Guid>(
                name: "parent_user_permission_id",
                table: "user_permissions",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "name", "parent_permission_id", "type" },
                values: new object[] { new Guid("8c5aa2bc-6376-4981-bfc5-247ec67df4f3"), "Settings Module", null, "SETTINGS" });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "name", "parent_permission_id", "type" },
                values: new object[] { new Guid("99813fcd-1883-4f16-aa9e-1acabd4da77c"), "User Accounts Module", new Guid("8c5aa2bc-6376-4981-bfc5-247ec67df4f3"), "USER_ACCOUNTS" });

            migrationBuilder.CreateIndex(
                name: "ix_user_permissions_parent_user_permission_id",
                table: "user_permissions",
                column: "parent_user_permission_id");

            migrationBuilder.AddForeignKey(
                name: "fk_user_permissions_user_permissions_parent_user_permission_id",
                table: "user_permissions",
                column: "parent_user_permission_id",
                principalTable: "user_permissions",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_user_permissions_user_permissions_parent_user_permission_id",
                table: "user_permissions");

            migrationBuilder.DropIndex(
                name: "ix_user_permissions_parent_user_permission_id",
                table: "user_permissions");

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("99813fcd-1883-4f16-aa9e-1acabd4da77c"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("8c5aa2bc-6376-4981-bfc5-247ec67df4f3"));

            migrationBuilder.DropColumn(
                name: "parent_user_permission_id",
                table: "user_permissions");

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "name", "parent_permission_id", "type" },
                values: new object[] { new Guid("3b3247b2-76d7-4457-80aa-5e7538a9108c"), "Settings Module", null, "SETTINGS" });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "name", "parent_permission_id", "type" },
                values: new object[] { new Guid("8554d348-9156-4063-8b72-aacd4a0be046"), "User Accounts Module", new Guid("3b3247b2-76d7-4457-80aa-5e7538a9108c"), "USER_ACCOUNTS" });
        }
    }
}
