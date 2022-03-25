using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Multitenancy.Migrations
{
    public partial class SeedIdentityRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "asp_net_roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { "2fd82cea-964b-4f79-8162-61f16007561e", "f35941f7-e5e5-4581-8719-20d13ae8879a", "USER", "USER" },
                    { "6e46173d-8674-474c-8c4e-5188f94c52da", "2760ad3c-b226-42e2-ba0e-9e29abce5042", "ADMIN", "ADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: "2fd82cea-964b-4f79-8162-61f16007561e");

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: "6e46173d-8674-474c-8c4e-5188f94c52da");
        }
    }
}
