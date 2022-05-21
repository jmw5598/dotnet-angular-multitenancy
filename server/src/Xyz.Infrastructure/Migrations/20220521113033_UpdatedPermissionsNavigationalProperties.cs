using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Infrastructure.Migrations
{
    public partial class UpdatedPermissionsNavigationalProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("0a729f5c-a9a6-4715-b478-6e01015c2bc2"), "Security Module" },
                    { new Guid("99c5f16e-9cd2-4ee1-892c-6503947e0efe"), "Dashboard Module" },
                    { new Guid("c706a7ed-9b36-4a7c-9563-9fcf5e751639"), "Administration Module" }
                });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "module_permission_id", "name" },
                values: new object[,]
                {
                    { new Guid("009d5db2-66c7-4ddc-b94f-cb97aea8d0de"), new Guid("99c5f16e-9cd2-4ee1-892c-6503947e0efe"), "Dashboard Overview" },
                    { new Guid("0fe6db99-3a8d-4e9a-b780-225ac909fa53"), new Guid("c706a7ed-9b36-4a7c-9563-9fcf5e751639"), "Settings" },
                    { new Guid("3f806cab-3194-4b40-b646-b2cc03b95e92"), new Guid("0a729f5c-a9a6-4715-b478-6e01015c2bc2"), "Security General" },
                    { new Guid("70eef41a-1d01-4bda-92c3-71155a5e755c"), new Guid("c706a7ed-9b36-4a7c-9563-9fcf5e751639"), "User Accounts" },
                    { new Guid("a821478c-d1a7-49bd-b6dc-4568ad1c30fe"), new Guid("0a729f5c-a9a6-4715-b478-6e01015c2bc2"), "Security Permissions" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("009d5db2-66c7-4ddc-b94f-cb97aea8d0de"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("0fe6db99-3a8d-4e9a-b780-225ac909fa53"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("3f806cab-3194-4b40-b646-b2cc03b95e92"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("70eef41a-1d01-4bda-92c3-71155a5e755c"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("a821478c-d1a7-49bd-b6dc-4568ad1c30fe"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("0a729f5c-a9a6-4715-b478-6e01015c2bc2"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("99c5f16e-9cd2-4ee1-892c-6503947e0efe"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("c706a7ed-9b36-4a7c-9563-9fcf5e751639"));

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
    }
}
