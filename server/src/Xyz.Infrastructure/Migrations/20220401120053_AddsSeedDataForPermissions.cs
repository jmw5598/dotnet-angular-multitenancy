using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Infrastructure.Migrations
{
    public partial class AddsSeedDataForPermissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "name", "type" },
                values: new object[] { new Guid("782b2c55-dbd6-403f-8c9b-e07145a61cf5"), "Accounts Module", "ACCOUNTS" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("782b2c55-dbd6-403f-8c9b-e07145a61cf5"));
        }
    }
}
