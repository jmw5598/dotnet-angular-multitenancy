using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xyz.Infrastructure.Migrations
{
    public partial class CreatesInitialTemplatedPermissionsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "template_module_permission_names",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_template_module_permission_names", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "template_module_permissions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    template_module_permission_name_id = table.Column<Guid>(type: "uuid", nullable: false),
                    has_access = table.Column<bool>(type: "boolean", nullable: false),
                    module_permission_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_template_module_permissions", x => x.id);
                    table.ForeignKey(
                        name: "fk_template_module_permissions_module_permissions_module_permi",
                        column: x => x.module_permission_id,
                        principalTable: "module_permissions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_template_module_permissions_template_module_permission_name",
                        column: x => x.template_module_permission_name_id,
                        principalTable: "template_module_permission_names",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "template_permissions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    template_module_permission_id = table.Column<Guid>(type: "uuid", nullable: false),
                    has_access = table.Column<bool>(type: "boolean", nullable: false),
                    module_permission_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_template_permissions", x => x.id);
                    table.ForeignKey(
                        name: "fk_template_permissions_module_permissions_module_permission_id",
                        column: x => x.module_permission_id,
                        principalTable: "module_permissions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_template_permissions_template_module_permissions_template_m",
                        column: x => x.template_module_permission_id,
                        principalTable: "template_module_permissions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "module_permissions",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("57945f00-f133-4937-ac23-191ff70c5eac"), "Administration Module" },
                    { new Guid("83f75318-b173-4a57-a3d8-3122cd2d30f1"), "Dashboard Module" },
                    { new Guid("b63b63a0-7acf-4874-8169-753348ff41e5"), "Security Module" }
                });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "module_permission_id", "name" },
                values: new object[,]
                {
                    { new Guid("142c596f-c655-4274-8dae-1d21cbfa4a40"), new Guid("83f75318-b173-4a57-a3d8-3122cd2d30f1"), "Dashboard Overview" },
                    { new Guid("4fa7caa6-5a7a-4789-b0c4-292d48370bf9"), new Guid("b63b63a0-7acf-4874-8169-753348ff41e5"), "Security General" },
                    { new Guid("5d02be93-cb3a-49f3-8628-58b0916fa9e1"), new Guid("57945f00-f133-4937-ac23-191ff70c5eac"), "Settings" },
                    { new Guid("75f0f7b9-dac3-4f10-8c49-9bd2f45a5bb3"), new Guid("b63b63a0-7acf-4874-8169-753348ff41e5"), "Security Permissions" },
                    { new Guid("c870ccc6-6daf-43ec-8de8-99d24a0ba2e5"), new Guid("57945f00-f133-4937-ac23-191ff70c5eac"), "User Accounts" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_template_module_permissions_module_permission_id",
                table: "template_module_permissions",
                column: "module_permission_id");

            migrationBuilder.CreateIndex(
                name: "ix_template_module_permissions_template_module_permission_name",
                table: "template_module_permissions",
                column: "template_module_permission_name_id");

            migrationBuilder.CreateIndex(
                name: "ix_template_permissions_module_permission_id",
                table: "template_permissions",
                column: "module_permission_id");

            migrationBuilder.CreateIndex(
                name: "ix_template_permissions_template_module_permission_id",
                table: "template_permissions",
                column: "template_module_permission_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "template_permissions");

            migrationBuilder.DropTable(
                name: "template_module_permissions");

            migrationBuilder.DropTable(
                name: "template_module_permission_names");

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("142c596f-c655-4274-8dae-1d21cbfa4a40"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("4fa7caa6-5a7a-4789-b0c4-292d48370bf9"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("5d02be93-cb3a-49f3-8628-58b0916fa9e1"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("75f0f7b9-dac3-4f10-8c49-9bd2f45a5bb3"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("c870ccc6-6daf-43ec-8de8-99d24a0ba2e5"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("57945f00-f133-4937-ac23-191ff70c5eac"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("83f75318-b173-4a57-a3d8-3122cd2d30f1"));

            migrationBuilder.DeleteData(
                table: "module_permissions",
                keyColumn: "id",
                keyValue: new Guid("b63b63a0-7acf-4874-8169-753348ff41e5"));

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
    }
}
