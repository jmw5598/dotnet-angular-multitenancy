using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Infrastructure.Migrations
{
    public partial class AddsSecurityModulerPermissionsAndSubPermissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "module_permissions",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("434e7705-6a0e-44ec-af0b-34c6d20a81b2"), "Security Module" },
                    { new Guid("a1b1b4ed-7421-479b-bd36-66a25066c1cc"), "Dashboard Module" },
                    { new Guid("f830a9a2-7823-49d6-a8ef-74c474906432"), "Administration Module" }
                });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "module_permission_id", "name" },
                values: new object[,]
                {
                    { new Guid("361e6014-9fef-4afe-b2a2-a9fa375c3887"), new Guid("a1b1b4ed-7421-479b-bd36-66a25066c1cc"), "Dashboard Overview" },
                    { new Guid("9d72acb1-6965-4a00-90f7-7713e7773c91"), new Guid("434e7705-6a0e-44ec-af0b-34c6d20a81b2"), "Security General" },
                    { new Guid("a0b452b9-7b7a-411c-8a97-4ad8fb18223c"), new Guid("f830a9a2-7823-49d6-a8ef-74c474906432"), "Settings" },
                    { new Guid("b34384bf-7342-4174-8a6d-1603ad770d75"), new Guid("434e7705-6a0e-44ec-af0b-34c6d20a81b2"), "Security Permissions" },
                    { new Guid("ce820086-82de-4a71-9bd9-4d203a2c7aeb"), new Guid("f830a9a2-7823-49d6-a8ef-74c474906432"), "User Accounts" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("361e6014-9fef-4afe-b2a2-a9fa375c3887"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("9d72acb1-6965-4a00-90f7-7713e7773c91"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("a0b452b9-7b7a-411c-8a97-4ad8fb18223c"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("b34384bf-7342-4174-8a6d-1603ad770d75"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("ce820086-82de-4a71-9bd9-4d203a2c7aeb"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("434e7705-6a0e-44ec-af0b-34c6d20a81b2"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("a1b1b4ed-7421-479b-bd36-66a25066c1cc"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("f830a9a2-7823-49d6-a8ef-74c474906432"));

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
        }
    }
}
