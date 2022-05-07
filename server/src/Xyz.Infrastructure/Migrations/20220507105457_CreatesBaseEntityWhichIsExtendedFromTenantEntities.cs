using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Infrastructure.Migrations
{
    public partial class CreatesBaseEntityWhichIsExtendedFromTenantEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "created_on",
                table: "vehicles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "delete_on",
                table: "vehicles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_on",
                table: "vehicles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_on",
                table: "vehicle_types",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "delete_on",
                table: "vehicle_types",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_on",
                table: "vehicle_types",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_on",
                table: "vehicle_models",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "delete_on",
                table: "vehicle_models",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_on",
                table: "vehicle_models",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_on",
                table: "vehicle_makes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "delete_on",
                table: "vehicle_makes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_on",
                table: "vehicle_makes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "created_on",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "delete_on",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "updated_on",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "created_on",
                table: "vehicle_types");

            migrationBuilder.DropColumn(
                name: "delete_on",
                table: "vehicle_types");

            migrationBuilder.DropColumn(
                name: "updated_on",
                table: "vehicle_types");

            migrationBuilder.DropColumn(
                name: "created_on",
                table: "vehicle_models");

            migrationBuilder.DropColumn(
                name: "delete_on",
                table: "vehicle_models");

            migrationBuilder.DropColumn(
                name: "updated_on",
                table: "vehicle_models");

            migrationBuilder.DropColumn(
                name: "created_on",
                table: "vehicle_makes");

            migrationBuilder.DropColumn(
                name: "delete_on",
                table: "vehicle_makes");

            migrationBuilder.DropColumn(
                name: "updated_on",
                table: "vehicle_makes");

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
    }
}
