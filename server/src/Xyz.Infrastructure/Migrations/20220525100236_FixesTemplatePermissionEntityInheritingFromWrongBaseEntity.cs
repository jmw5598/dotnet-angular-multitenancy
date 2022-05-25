using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Infrastructure.Migrations
{
    public partial class FixesTemplatePermissionEntityInheritingFromWrongBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_template_permissions_module_permissions_module_permission_id",
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

            migrationBuilder.RenameColumn(
                name: "module_permission_id",
                table: "template_permissions",
                newName: "permission_id");

            migrationBuilder.RenameColumn(
                name: "has_access",
                table: "template_permissions",
                newName: "can_update");

            migrationBuilder.RenameIndex(
                name: "ix_template_permissions_module_permission_id",
                table: "template_permissions",
                newName: "ix_template_permissions_permission_id");

            migrationBuilder.AddColumn<bool>(
                name: "can_create",
                table: "template_permissions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "can_delete",
                table: "template_permissions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "can_read",
                table: "template_permissions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "module_permissions",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("45223ef9-0b0e-439e-a2d9-49ad606b561f"), "Security Module" },
                    { new Guid("7a6e951e-50df-4622-9707-d35431781302"), "Administration Module" },
                    { new Guid("d4959629-dd10-4f16-92b6-32b9002a5aca"), "Dashboard Module" }
                });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "module_permission_id", "name" },
                values: new object[,]
                {
                    { new Guid("3b7875dd-031f-497d-a277-11e6bbf1b6f4"), new Guid("45223ef9-0b0e-439e-a2d9-49ad606b561f"), "Security General" },
                    { new Guid("83355e63-f3ca-42fc-8a4b-edd973715cd1"), new Guid("7a6e951e-50df-4622-9707-d35431781302"), "Settings" },
                    { new Guid("8e7397ac-2e26-498f-906f-cc46baf3bab2"), new Guid("7a6e951e-50df-4622-9707-d35431781302"), "User Accounts" },
                    { new Guid("b834d5c2-4d12-4aad-ad1f-16dceecc5074"), new Guid("45223ef9-0b0e-439e-a2d9-49ad606b561f"), "Security Permissions" },
                    { new Guid("d72a57c8-e2a5-44ae-a5a1-eb33a8736799"), new Guid("d4959629-dd10-4f16-92b6-32b9002a5aca"), "Dashboard Overview" }
                });

            migrationBuilder.AddForeignKey(
                name: "fk_template_permissions_permissions_permission_id",
                table: "template_permissions",
                column: "permission_id",
                principalTable: "permissions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_template_permissions_permissions_permission_id",
                table: "template_permissions");

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("3b7875dd-031f-497d-a277-11e6bbf1b6f4"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("83355e63-f3ca-42fc-8a4b-edd973715cd1"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("8e7397ac-2e26-498f-906f-cc46baf3bab2"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("b834d5c2-4d12-4aad-ad1f-16dceecc5074"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("d72a57c8-e2a5-44ae-a5a1-eb33a8736799"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("45223ef9-0b0e-439e-a2d9-49ad606b561f"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("7a6e951e-50df-4622-9707-d35431781302"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("d4959629-dd10-4f16-92b6-32b9002a5aca"));

            migrationBuilder.DropColumn(
                name: "can_create",
                table: "template_permissions");

            migrationBuilder.DropColumn(
                name: "can_delete",
                table: "template_permissions");

            migrationBuilder.DropColumn(
                name: "can_read",
                table: "template_permissions");

            migrationBuilder.RenameColumn(
                name: "permission_id",
                table: "template_permissions",
                newName: "module_permission_id");

            migrationBuilder.RenameColumn(
                name: "can_update",
                table: "template_permissions",
                newName: "has_access");

            migrationBuilder.RenameIndex(
                name: "ix_template_permissions_permission_id",
                table: "template_permissions",
                newName: "ix_template_permissions_module_permission_id");

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

            migrationBuilder.AddForeignKey(
                name: "fk_template_permissions_module_permissions_module_permission_id",
                table: "template_permissions",
                column: "module_permission_id",
                principalTable: "module_permissions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
