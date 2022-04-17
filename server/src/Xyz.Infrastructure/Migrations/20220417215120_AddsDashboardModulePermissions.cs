using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Infrastructure.Migrations
{
    public partial class AddsDashboardModulePermissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[,]
                {
                    { new Guid("50c0d627-e8a7-4bdc-9eb8-884391def511"), "Settings Module", null, "Settings" },
                    { new Guid("fa4ddd13-c0eb-458f-b2b4-c41d7a930f40"), "Dashboard Module", null, "Dashboard" }
                });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "name", "parent_permission_id", "type" },
                values: new object[,]
                {
                    { new Guid("4cd906f7-60bd-49b2-9345-60e87fe5a5b3"), "Dashboard Overview Module", new Guid("fa4ddd13-c0eb-458f-b2b4-c41d7a930f40"), "DashboardOverview" },
                    { new Guid("f8e2858b-8ee6-493e-8b0f-5092c022a0ab"), "User Accounts Module", new Guid("50c0d627-e8a7-4bdc-9eb8-884391def511"), "UserAccounts" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("4cd906f7-60bd-49b2-9345-60e87fe5a5b3"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("f8e2858b-8ee6-493e-8b0f-5092c022a0ab"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("50c0d627-e8a7-4bdc-9eb8-884391def511"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("fa4ddd13-c0eb-458f-b2b4-c41d7a930f40"));

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "name", "parent_permission_id", "type" },
                values: new object[] { new Guid("5bde872c-1d66-4b89-9384-3a6b4aec6244"), "Settings Module", null, "Settings" });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "name", "parent_permission_id", "type" },
                values: new object[] { new Guid("57d93f69-741d-4809-9cee-8d066fadc5ec"), "User Accounts Module", new Guid("5bde872c-1d66-4b89-9384-3a6b4aec6244"), "UserAccounts" });
        }
    }
}
