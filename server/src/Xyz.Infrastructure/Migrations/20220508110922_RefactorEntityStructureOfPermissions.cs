using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Infrastructure.Migrations
{
    public partial class RefactorEntityStructureOfPermissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_permissions_permissions_parent_permission_id",
                table: "permissions");

            migrationBuilder.DropForeignKey(
                name: "fk_user_permissions_user_permissions_parent_user_permission_id",
                table: "user_permissions");

            migrationBuilder.DropIndex(
                name: "ix_user_permissions_parent_user_permission_id",
                table: "user_permissions");

            migrationBuilder.DropIndex(
                name: "ix_permissions_parent_permission_id",
                table: "permissions");

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("3d8b694a-4956-45e1-9bff-aca14512fa85"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("e39be0dc-70b4-4663-aff8-3a3d0c849713"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("05bca710-8bec-4379-9ffb-0dd06cec1f6a"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("355ae37c-959f-4377-a4e0-d11ef38af3b8"));

            migrationBuilder.DropColumn(
                name: "parent_user_permission_id",
                table: "user_permissions");

            migrationBuilder.DropColumn(
                name: "parent_permission_id",
                table: "permissions");

            migrationBuilder.DropColumn(
                name: "type",
                table: "permissions");

            migrationBuilder.AddColumn<Guid>(
                name: "user_module_permission_id",
                table: "user_permissions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "module_permission_id",
                table: "permissions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "module_permission",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_module_permission", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_module_permission",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    has_access = table.Column<bool>(type: "boolean", nullable: false),
                    module_permission_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_module_permission", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_module_permission_module_permission_module_permission_",
                        column: x => x.module_permission_id,
                        principalTable: "module_permission",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "module_permission",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("27646707-0d62-4bd5-b347-6e03c87f6dee"), "Settings Module" },
                    { new Guid("4f78b694-f87e-40ab-97df-165fd5560732"), "Dashboard Module" }
                });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "module_permission_id", "name" },
                values: new object[,]
                {
                    { new Guid("23fc53f7-715e-4ac8-ab6f-3ebb24878111"), new Guid("27646707-0d62-4bd5-b347-6e03c87f6dee"), "User Accounts Module" },
                    { new Guid("f4ab5cef-5727-4fa6-a3f0-eaa417c2ac9c"), new Guid("4f78b694-f87e-40ab-97df-165fd5560732"), "Dashboard Overview Module" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_user_permissions_user_module_permission_id",
                table: "user_permissions",
                column: "user_module_permission_id");

            migrationBuilder.CreateIndex(
                name: "ix_permissions_module_permission_id",
                table: "permissions",
                column: "module_permission_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_module_permission_module_permission_id",
                table: "user_module_permission",
                column: "module_permission_id");

            migrationBuilder.AddForeignKey(
                name: "fk_permissions_module_permission_module_permission_id",
                table: "permissions",
                column: "module_permission_id",
                principalTable: "module_permission",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_permissions_user_module_permission_user_module_permiss",
                table: "user_permissions",
                column: "user_module_permission_id",
                principalTable: "user_module_permission",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_permissions_module_permission_module_permission_id",
                table: "permissions");

            migrationBuilder.DropForeignKey(
                name: "fk_user_permissions_user_module_permission_user_module_permiss",
                table: "user_permissions");

            migrationBuilder.DropTable(
                name: "user_module_permission");

            migrationBuilder.DropTable(
                name: "module_permission");

            migrationBuilder.DropIndex(
                name: "ix_user_permissions_user_module_permission_id",
                table: "user_permissions");

            migrationBuilder.DropIndex(
                name: "ix_permissions_module_permission_id",
                table: "permissions");

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("23fc53f7-715e-4ac8-ab6f-3ebb24878111"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("f4ab5cef-5727-4fa6-a3f0-eaa417c2ac9c"));

            migrationBuilder.DropColumn(
                name: "user_module_permission_id",
                table: "user_permissions");

            migrationBuilder.DropColumn(
                name: "module_permission_id",
                table: "permissions");

            migrationBuilder.AddColumn<Guid>(
                name: "parent_user_permission_id",
                table: "user_permissions",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "parent_permission_id",
                table: "permissions",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "permissions",
                type: "varchar(24)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "name", "parent_permission_id", "type" },
                values: new object[,]
                {
                    { new Guid("05bca710-8bec-4379-9ffb-0dd06cec1f6a"), "Dashboard Module", null, "Dashboard" },
                    { new Guid("355ae37c-959f-4377-a4e0-d11ef38af3b8"), "Settings Module", null, "Settings" }
                });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "name", "parent_permission_id", "type" },
                values: new object[,]
                {
                    { new Guid("3d8b694a-4956-45e1-9bff-aca14512fa85"), "Dashboard Overview Module", new Guid("05bca710-8bec-4379-9ffb-0dd06cec1f6a"), "DashboardOverview" },
                    { new Guid("e39be0dc-70b4-4663-aff8-3a3d0c849713"), "User Accounts Module", new Guid("355ae37c-959f-4377-a4e0-d11ef38af3b8"), "UserAccounts" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_user_permissions_parent_user_permission_id",
                table: "user_permissions",
                column: "parent_user_permission_id");

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

            migrationBuilder.AddForeignKey(
                name: "fk_user_permissions_user_permissions_parent_user_permission_id",
                table: "user_permissions",
                column: "parent_user_permission_id",
                principalTable: "user_permissions",
                principalColumn: "id");
        }
    }
}
