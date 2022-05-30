using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Xyz.Multitenancy.Migrations
{
    public partial class RemovesAuthenticationEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "asp_net_role_claims");

            migrationBuilder.DropTable(
                name: "asp_net_user_claims");

            migrationBuilder.DropTable(
                name: "asp_net_user_logins");

            migrationBuilder.DropTable(
                name: "asp_net_user_roles");

            migrationBuilder.DropTable(
                name: "asp_net_user_tokens");

            migrationBuilder.DropTable(
                name: "user_tenants");

            migrationBuilder.DropTable(
                name: "asp_net_roles");

            migrationBuilder.DropTable(
                name: "asp_net_users");

            migrationBuilder.DropTable(
                name: "profiles");

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("13cbf351-5269-4f76-b179-17414669c3d3"));

            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "id",
                keyValue: new Guid("a25535e2-56d0-453d-8989-09ddbc3da597"));

            migrationBuilder.DeleteData(
                table: "companies",
                keyColumn: "id",
                keyValue: new Guid("1e8b124d-3a5b-4c31-a0c7-4455aea85ad7"));

            migrationBuilder.DeleteData(
                table: "tenant_plans",
                keyColumn: "id",
                keyValue: new Guid("d4c48f09-f7a4-4b3b-9fcb-a719dcda1903"));

            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "id",
                keyValue: new Guid("e848c2b5-09e1-49e5-9657-529622d027b0"));

            migrationBuilder.DeleteData(
                table: "companies",
                keyColumn: "id",
                keyValue: new Guid("9052dfb7-a67b-4ed7-afb7-658c7d1641a8"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("a58ece84-9834-4726-b0c0-10f43a82b990"));

            migrationBuilder.DeleteData(
                table: "tenant_plans",
                keyColumn: "id",
                keyValue: new Guid("99d4f0c5-8d13-4bf4-9595-6438f89977f8"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("bbcb9edd-0b46-43eb-9419-1563a277ad58"));

            migrationBuilder.InsertData(
                table: "companies",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("06bfbbb9-c844-4b50-bbf6-205f12964e3f"), "Localhost" },
                    { new Guid("0a91c6b3-3e16-4727-b022-9a0d5e55e67b"), "Dev Company" }
                });

            migrationBuilder.InsertData(
                table: "plans",
                columns: new[] { "id", "max_user_count", "name", "price", "renewal_rate" },
                values: new object[,]
                {
                    { new Guid("2c5cc718-f1b5-4aca-8981-7edcd3fd20db"), 5, "Free", 0.00m, "MONTHLY" },
                    { new Guid("3f803de8-5d65-42c1-ba0d-92f0619fa83b"), 5, "Localhost Dev Plan", 0m, "MONTHLY" },
                    { new Guid("af461e08-d478-4737-8eb5-aac64d2f252c"), 5, "Dev", 0m, "MONTHLY" }
                });

            migrationBuilder.InsertData(
                table: "tenant_plans",
                columns: new[] { "id", "max_user_count", "plan_id", "price", "renewal_rate" },
                values: new object[,]
                {
                    { new Guid("488e506a-9a2c-4fb5-a619-87fb0b799d23"), 5, new Guid("3f803de8-5d65-42c1-ba0d-92f0619fa83b"), 0m, "MONTHLY" },
                    { new Guid("5337e10a-4aaf-477e-92c8-a36b13352134"), 5, new Guid("af461e08-d478-4737-8eb5-aac64d2f252c"), 0m, "MONTHLY" }
                });

            migrationBuilder.InsertData(
                table: "tenants",
                columns: new[] { "id", "company_id", "connection_string", "display_name", "domain_names", "guid", "ip_addresses", "is_active", "is_configured", "name", "tenant_plan_id" },
                values: new object[,]
                {
                    { new Guid("6516c72c-f91c-4e87-ae92-98c027382324"), new Guid("06bfbbb9-c844-4b50-bbf6-205f12964e3f"), "Server=localhost;Port=5432;Database=xyz_localhost_company;User Id=xyz;Password=password;", "Localhost", "", "cf4a21ee-9e49-4e39-8f02-9e28d32e1fde", "", false, false, "localhost", new Guid("488e506a-9a2c-4fb5-a619-87fb0b799d23") },
                    { new Guid("d9d0883f-4811-4d28-a51d-758a68884be3"), new Guid("0a91c6b3-3e16-4727-b022-9a0d5e55e67b"), "Server=localhost;Port=5432;Database=xyz_dev_company;User Id=xyz;Password=password;", "Dev Company", "", "92558851-fb0e-4616-898d-85857fc4016c", "", true, true, "devcompany", new Guid("5337e10a-4aaf-477e-92c8-a36b13352134") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("2c5cc718-f1b5-4aca-8981-7edcd3fd20db"));

            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "id",
                keyValue: new Guid("6516c72c-f91c-4e87-ae92-98c027382324"));

            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "id",
                keyValue: new Guid("d9d0883f-4811-4d28-a51d-758a68884be3"));

            migrationBuilder.DeleteData(
                table: "companies",
                keyColumn: "id",
                keyValue: new Guid("06bfbbb9-c844-4b50-bbf6-205f12964e3f"));

            migrationBuilder.DeleteData(
                table: "companies",
                keyColumn: "id",
                keyValue: new Guid("0a91c6b3-3e16-4727-b022-9a0d5e55e67b"));

            migrationBuilder.DeleteData(
                table: "tenant_plans",
                keyColumn: "id",
                keyValue: new Guid("488e506a-9a2c-4fb5-a619-87fb0b799d23"));

            migrationBuilder.DeleteData(
                table: "tenant_plans",
                keyColumn: "id",
                keyValue: new Guid("5337e10a-4aaf-477e-92c8-a36b13352134"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("3f803de8-5d65-42c1-ba0d-92f0619fa83b"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "id",
                keyValue: new Guid("af461e08-d478-4737-8eb5-aac64d2f252c"));

            migrationBuilder.CreateTable(
                name: "asp_net_roles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "profiles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    avatar_url = table.Column<string>(type: "text", nullable: true),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_profiles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "asp_net_role_claims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_role_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_role_claims_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "asp_net_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "asp_net_users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    profile_id = table.Column<Guid>(type: "uuid", nullable: false),
                    access_failed_count = table.Column<int>(type: "integer", nullable: false),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    lockout_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    normalized_email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    password_hash = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    security_stamp = table.Column<string>(type: "text", nullable: true),
                    two_factor_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_users_profiles_profile_id",
                        column: x => x.profile_id,
                        principalTable: "profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "asp_net_user_claims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_user_claims_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "asp_net_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "asp_net_user_logins",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    provider_key = table.Column<string>(type: "text", nullable: false),
                    provider_display_name = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_logins", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_asp_net_user_logins_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "asp_net_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "asp_net_user_roles",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "asp_net_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "asp_net_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "asp_net_user_tokens",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_tokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_asp_net_user_tokens_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "asp_net_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_tenants",
                columns: table => new
                {
                    asp_net_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_tenants", x => new { x.asp_net_user_id, x.tenant_id });
                    table.ForeignKey(
                        name: "fk_user_tenants_asp_net_users_asp_net_user_id",
                        column: x => x.asp_net_user_id,
                        principalTable: "asp_net_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_tenants_tenants_tenant_id",
                        column: x => x.tenant_id,
                        principalTable: "tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "asp_net_roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { new Guid("06af0ee3-d9f3-41ce-a85a-d2adf29325ef"), "01948a9a-fdcb-4886-987a-75d46ab3f44e", "ROOT", "ROOT" },
                    { new Guid("5d9f48f6-aea8-4b71-80db-c6bb65f78c73"), "14ef6600-c5a5-4c2d-81d4-c9274adccab2", "ADMIN", "ADMIN" },
                    { new Guid("b3ae0463-3f2b-4177-a4d2-07d0aeabba93"), "6b74f653-8970-4d2b-a4b5-483b3f8f0f17", "USER", "USER" }
                });

            migrationBuilder.InsertData(
                table: "companies",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("1e8b124d-3a5b-4c31-a0c7-4455aea85ad7"), "Localhost" },
                    { new Guid("9052dfb7-a67b-4ed7-afb7-658c7d1641a8"), "Dev Company" }
                });

            migrationBuilder.InsertData(
                table: "plans",
                columns: new[] { "id", "max_user_count", "name", "price", "renewal_rate" },
                values: new object[,]
                {
                    { new Guid("13cbf351-5269-4f76-b179-17414669c3d3"), 5, "Free", 0.00m, "MONTHLY" },
                    { new Guid("a58ece84-9834-4726-b0c0-10f43a82b990"), 5, "Localhost Dev Plan", 0m, "MONTHLY" },
                    { new Guid("bbcb9edd-0b46-43eb-9419-1563a277ad58"), 5, "Dev", 0m, "MONTHLY" }
                });

            migrationBuilder.InsertData(
                table: "profiles",
                columns: new[] { "id", "avatar_url", "first_name", "last_name" },
                values: new object[] { new Guid("7d355714-763d-48ac-8886-50dab3f01e11"), null, "Jason", "White" });

            migrationBuilder.InsertData(
                table: "asp_net_users",
                columns: new[] { "id", "access_failed_count", "concurrency_stamp", "email", "email_confirmed", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "profile_id", "security_stamp", "two_factor_enabled", "user_name" },
                values: new object[] { new Guid("6fcb8e98-1a13-41a9-ab3c-2169f4d716c0"), 0, "f0c46d90-8bef-4461-8f3f-8271cbe13c7c", "jmw5598@gmail.com", true, false, null, "JMW5598@gmail.com", "JMW5598@GMAIL.COM", "AQAAAAEAACcQAAAAENccJfHvrrswM3ayb7zpqGoATipLplJ4q+ZQCZ87p08cSf4SmRyDnOPnyde5KzdWvg==", null, false, new Guid("7d355714-763d-48ac-8886-50dab3f01e11"), null, false, "jmw5598@gmail.com" });

            migrationBuilder.InsertData(
                table: "tenant_plans",
                columns: new[] { "id", "max_user_count", "plan_id", "price", "renewal_rate" },
                values: new object[,]
                {
                    { new Guid("99d4f0c5-8d13-4bf4-9595-6438f89977f8"), 5, new Guid("bbcb9edd-0b46-43eb-9419-1563a277ad58"), 0m, "MONTHLY" },
                    { new Guid("d4c48f09-f7a4-4b3b-9fcb-a719dcda1903"), 5, new Guid("a58ece84-9834-4726-b0c0-10f43a82b990"), 0m, "MONTHLY" }
                });

            migrationBuilder.InsertData(
                table: "asp_net_user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("06af0ee3-d9f3-41ce-a85a-d2adf29325ef"), new Guid("6fcb8e98-1a13-41a9-ab3c-2169f4d716c0") },
                    { new Guid("5d9f48f6-aea8-4b71-80db-c6bb65f78c73"), new Guid("6fcb8e98-1a13-41a9-ab3c-2169f4d716c0") },
                    { new Guid("b3ae0463-3f2b-4177-a4d2-07d0aeabba93"), new Guid("6fcb8e98-1a13-41a9-ab3c-2169f4d716c0") }
                });

            migrationBuilder.InsertData(
                table: "tenants",
                columns: new[] { "id", "company_id", "connection_string", "display_name", "domain_names", "guid", "ip_addresses", "is_active", "is_configured", "name", "tenant_plan_id" },
                values: new object[,]
                {
                    { new Guid("a25535e2-56d0-453d-8989-09ddbc3da597"), new Guid("1e8b124d-3a5b-4c31-a0c7-4455aea85ad7"), "Server=localhost;Port=5432;Database=xyz_localhost_company;User Id=xyz;Password=password;", "Localhost", "", "f2d74c37-935c-4510-b52f-fa291cb12c3a", "", false, false, "localhost", new Guid("d4c48f09-f7a4-4b3b-9fcb-a719dcda1903") },
                    { new Guid("e848c2b5-09e1-49e5-9657-529622d027b0"), new Guid("9052dfb7-a67b-4ed7-afb7-658c7d1641a8"), "Server=localhost;Port=5432;Database=xyz_dev_company;User Id=xyz;Password=password;", "Dev Company", "", "61bd11a3-9f3e-46a7-bc2b-17b1a8981d1a", "", true, true, "devcompany", new Guid("99d4f0c5-8d13-4bf4-9595-6438f89977f8") }
                });

            migrationBuilder.InsertData(
                table: "user_tenants",
                columns: new[] { "asp_net_user_id", "tenant_id" },
                values: new object[] { new Guid("6fcb8e98-1a13-41a9-ab3c-2169f4d716c0"), new Guid("e848c2b5-09e1-49e5-9657-529622d027b0") });

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_role_claims_role_id",
                table: "asp_net_role_claims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "asp_net_roles",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_claims_user_id",
                table: "asp_net_user_claims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_logins_user_id",
                table: "asp_net_user_logins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_roles_role_id",
                table: "asp_net_user_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "asp_net_users",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_users_profile_id",
                table: "asp_net_users",
                column: "profile_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "asp_net_users",
                column: "normalized_user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_tenants_tenant_id",
                table: "user_tenants",
                column: "tenant_id");
        }
    }
}
