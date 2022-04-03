using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Infrastructure.Migrations
{
    public partial class AltersModulePermissionTypeEnumAsCamelCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("99813fcd-1883-4f16-aa9e-1acabd4da77c"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("8c5aa2bc-6376-4981-bfc5-247ec67df4f3"));

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "name", "parent_permission_id", "type" },
                values: new object[] { new Guid("5bde872c-1d66-4b89-9384-3a6b4aec6244"), "Settings Module", null, "Settings" });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "name", "parent_permission_id", "type" },
                values: new object[] { new Guid("57d93f69-741d-4809-9cee-8d066fadc5ec"), "User Accounts Module", new Guid("5bde872c-1d66-4b89-9384-3a6b4aec6244"), "UserAccounts" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("57d93f69-741d-4809-9cee-8d066fadc5ec"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("5bde872c-1d66-4b89-9384-3a6b4aec6244"));

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "name", "parent_permission_id", "type" },
                values: new object[] { new Guid("8c5aa2bc-6376-4981-bfc5-247ec67df4f3"), "Settings Module", null, "SETTINGS" });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "name", "parent_permission_id", "type" },
                values: new object[] { new Guid("99813fcd-1883-4f16-aa9e-1acabd4da77c"), "User Accounts Module", new Guid("8c5aa2bc-6376-4981-bfc5-247ec67df4f3"), "USER_ACCOUNTS" });
        }
    }
}
