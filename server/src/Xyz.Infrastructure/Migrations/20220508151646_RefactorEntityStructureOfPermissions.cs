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
                name: "module_permissions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_module_permissions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_module_permissions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    has_access = table.Column<bool>(type: "boolean", nullable: false),
                    module_permission_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_module_permissions", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_module_permissions_module_permissions_module_permissio",
                        column: x => x.module_permission_id,
                        principalTable: "module_permissions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "module_permissions",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("8fc1acef-5ad0-45d5-aede-67a82633cc35"), "Dashboard Module" },
                    { new Guid("9c153e12-f706-4f1d-a0c8-478323008b69"), "Settings Module" }
                });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "module_permission_id", "name" },
                values: new object[,]
                {
                    { new Guid("903bcea3-cebc-41d4-92cf-ab75e653981a"), new Guid("9c153e12-f706-4f1d-a0c8-478323008b69"), "User Accounts Module" },
                    { new Guid("9d1ae49c-67a2-48f2-b1cb-e58ab255a339"), new Guid("8fc1acef-5ad0-45d5-aede-67a82633cc35"), "Dashboard Overview Module" }
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
                name: "ix_user_module_permissions_module_permission_id",
                table: "user_module_permissions",
                column: "module_permission_id");

            migrationBuilder.AddForeignKey(
                name: "fk_permissions_module_permissions_module_permission_id",
                table: "permissions",
                column: "module_permission_id",
                principalTable: "module_permissions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_permissions_user_module_permissions_user_module_permis",
                table: "user_permissions",
                column: "user_module_permission_id",
                principalTable: "user_module_permissions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_permissions_module_permissions_module_permission_id",
                table: "permissions");

            migrationBuilder.DropForeignKey(
                name: "fk_user_permissions_user_module_permissions_user_module_permis",
                table: "user_permissions");

            migrationBuilder.DropTable(
                name: "user_module_permissions");

            migrationBuilder.DropTable(
                name: "module_permissions");

            migrationBuilder.DropIndex(
                name: "ix_user_permissions_user_module_permission_id",
                table: "user_permissions");

            migrationBuilder.DropIndex(
                name: "ix_permissions_module_permission_id",
                table: "permissions");

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("903bcea3-cebc-41d4-92cf-ab75e653981a"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("9d1ae49c-67a2-48f2-b1cb-e58ab255a339"));

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
