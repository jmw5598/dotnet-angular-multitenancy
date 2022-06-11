using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Infrastructure.Migrations
{
    public partial class AddsAccountDetailsPermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac22"),
                column: "concurrency_stamp",
                value: "4511f0f7-6ad0-4b3f-be77-9928cb1ab043");

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac27"),
                column: "concurrency_stamp",
                value: "2f2b8faa-022c-4f05-88ab-4700d4ed6a06");

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac28"),
                column: "concurrency_stamp",
                value: "babdd63a-903a-4d22-b6df-695dfbeb3f74");

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "module_permission_id", "name" },
                values: new object[] { new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc44"), new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc27"), "Account Details" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc44"));

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac22"),
                column: "concurrency_stamp",
                value: "a9f47233-7d5d-451a-979e-cf6e48a018f4");

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac27"),
                column: "concurrency_stamp",
                value: "8bfd7037-3a57-4345-8cdd-581b37cccd9f");

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac28"),
                column: "concurrency_stamp",
                value: "271d0855-e7e4-403f-af3f-f378201cb8cd");
        }
    }
}
