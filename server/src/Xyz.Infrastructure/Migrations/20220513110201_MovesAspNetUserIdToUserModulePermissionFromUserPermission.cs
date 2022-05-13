using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Infrastructure.Migrations
{
    public partial class MovesAspNetUserIdToUserModulePermissionFromUserPermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_user_permissions_asp_net_user_id",
                table: "user_permissions");

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("903bcea3-cebc-41d4-92cf-ab75e653981a"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("9d1ae49c-67a2-48f2-b1cb-e58ab255a339"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("8fc1acef-5ad0-45d5-aede-67a82633cc35"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("9c153e12-f706-4f1d-a0c8-478323008b69"));

            migrationBuilder.DropColumn(
                name: "asp_net_user_id",
                table: "user_permissions");

            migrationBuilder.AddColumn<Guid>(
                name: "asp_net_user_id",
                table: "user_module_permissions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "module_permissions",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("0c45c99e-25e0-42b5-8eb0-fd5289cde12e"), "Settings Module" },
                    { new Guid("657547fa-8607-4e74-8a9c-68ec6c928181"), "Dashboard Module" }
                });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "module_permission_id", "name" },
                values: new object[,]
                {
                    { new Guid("96b791ff-9b91-4506-9ddb-fdfd1209bd57"), new Guid("657547fa-8607-4e74-8a9c-68ec6c928181"), "Dashboard Overview Module" },
                    { new Guid("d936141e-4635-45b9-840d-339b90ee7036"), new Guid("0c45c99e-25e0-42b5-8eb0-fd5289cde12e"), "User Accounts Module" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_user_module_permissions_asp_net_user_id",
                table: "user_module_permissions",
                column: "asp_net_user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_user_module_permissions_asp_net_user_id",
                table: "user_module_permissions");

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("96b791ff-9b91-4506-9ddb-fdfd1209bd57"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("d936141e-4635-45b9-840d-339b90ee7036"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("0c45c99e-25e0-42b5-8eb0-fd5289cde12e"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("657547fa-8607-4e74-8a9c-68ec6c928181"));

            migrationBuilder.DropColumn(
                name: "asp_net_user_id",
                table: "user_module_permissions");

            migrationBuilder.AddColumn<Guid>(
                name: "asp_net_user_id",
                table: "user_permissions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                name: "ix_user_permissions_asp_net_user_id",
                table: "user_permissions",
                column: "asp_net_user_id");
        }
    }
}
