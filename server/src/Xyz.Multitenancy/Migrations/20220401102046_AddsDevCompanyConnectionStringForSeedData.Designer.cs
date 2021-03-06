// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Xyz.Multitenancy.Data;

#nullable disable

namespace Xyz.Multitenancy.Migrations
{
    [DbContext(typeof(MultitenancyDbContext))]
    [Migration("20220401102046_AddsDevCompanyConnectionStringForSeedData")]
    partial class AddsDevCompanyConnectionStringForSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("claim_value");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("role_id");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_role_claims");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_asp_net_role_claims_role_id");

                    b.ToTable("asp_net_role_claims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("claim_value");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_user_claims");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_asp_net_user_claims_user_id");

                    b.ToTable("asp_net_user_claims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text")
                        .HasColumnName("login_provider");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text")
                        .HasColumnName("provider_key");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text")
                        .HasColumnName("provider_display_name");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("pk_asp_net_user_logins");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_asp_net_user_logins_user_id");

                    b.ToTable("asp_net_user_logins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("role_id");

                    b.HasKey("UserId", "RoleId")
                        .HasName("pk_asp_net_user_roles");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_asp_net_user_roles_role_id");

                    b.ToTable("asp_net_user_roles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("56129b97-38e0-44e8-b723-490a4b1b94e5"),
                            RoleId = new Guid("382c1b96-1305-499c-bd87-1b382bb20b28")
                        },
                        new
                        {
                            UserId = new Guid("56129b97-38e0-44e8-b723-490a4b1b94e5"),
                            RoleId = new Guid("2fd64167-37e2-407f-a3e7-0115c22d0d58")
                        },
                        new
                        {
                            UserId = new Guid("56129b97-38e0-44e8-b723-490a4b1b94e5"),
                            RoleId = new Guid("bf290349-d826-45ce-8325-f4e65f544254")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text")
                        .HasColumnName("login_provider");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Value")
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("UserId", "LoginProvider", "Name")
                        .HasName("pk_asp_net_user_tokens");

                    b.ToTable("asp_net_user_tokens", (string)null);
                });

            modelBuilder.Entity("user_tenants", b =>
                {
                    b.Property<Guid>("AspNetUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("asp_net_user_id");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid")
                        .HasColumnName("tenant_id");

                    b.HasKey("AspNetUserId", "TenantId")
                        .HasName("pk_user_tenants");

                    b.HasIndex("TenantId")
                        .HasDatabaseName("ix_user_tenants_tenant_id");

                    b.ToTable("user_tenants", (string)null);

                    b.HasData(
                        new
                        {
                            AspNetUserId = new Guid("56129b97-38e0-44e8-b723-490a4b1b94e5"),
                            TenantId = new Guid("f16e781e-daca-4724-ab86-062210029054")
                        });
                });

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_name");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_roles");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("asp_net_roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("382c1b96-1305-499c-bd87-1b382bb20b28"),
                            ConcurrencyStamp = "a64dd50e-fa7e-4481-bde7-a4c523550d5c",
                            Name = "ROOT",
                            NormalizedName = "ROOT"
                        },
                        new
                        {
                            Id = new Guid("2fd64167-37e2-407f-a3e7-0115c22d0d58"),
                            ConcurrencyStamp = "5d4bcce1-6f3d-4d3f-bb2b-a4cba22b4288",
                            Name = "ADMIN",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("bf290349-d826-45ce-8325-f4e65f544254"),
                            ConcurrencyStamp = "402a1721-8dae-4cfc-98a9-9d76ed27bdb0",
                            Name = "USER",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer")
                        .HasColumnName("access_failed_count");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("email_confirmed");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("lockout_enabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("lockout_end");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_email");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_user_name");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("phone_number_confirmed");

                    b.Property<Guid>("ProfileId")
                        .HasColumnType("uuid")
                        .HasColumnName("profile_id");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text")
                        .HasColumnName("security_stamp");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("two_factor_enabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("user_name");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_users");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("ProfileId")
                        .IsUnique()
                        .HasDatabaseName("ix_asp_net_users_profile_id");

                    b.ToTable("asp_net_users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("56129b97-38e0-44e8-b723-490a4b1b94e5"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "60caf6a5-0cda-4d29-b8cf-ae1996470dea",
                            Email = "jmw5598@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "JMW5598@gmail.com",
                            NormalizedUserName = "JMW5598@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEM0H+KRbrcYgevwnMDbO1R7qvfnb63zzWtya75gM4DwN5ALRrWYNyXvLuQxjhY6naw==",
                            PhoneNumberConfirmed = false,
                            ProfileId = new Guid("1d77ca4c-1d17-4776-97d4-96f132163fcf"),
                            TwoFactorEnabled = false,
                            UserName = "jmw5598@gmail.com"
                        });
                });

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_companies");

                    b.ToTable("companies", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("1df72ec4-97ba-4f2b-8409-950492f45740"),
                            Name = "Localhost"
                        },
                        new
                        {
                            Id = new Guid("3779b72a-f2e6-469a-8f1d-107844f089d5"),
                            Name = "Dev Company"
                        });
                });

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.Plan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("MaxUserCount")
                        .HasColumnType("integer")
                        .HasColumnName("max_user_count");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<string>("RenewalRate")
                        .IsRequired()
                        .HasColumnType("varchar(24)")
                        .HasColumnName("renewal_rate");

                    b.HasKey("Id")
                        .HasName("pk_plans");

                    b.ToTable("plans", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("d56f702e-4a82-4085-8992-bd5f1fa36f4b"),
                            MaxUserCount = 5,
                            Name = "Localhost Dev Plan",
                            Price = 0m,
                            RenewalRate = "MONTHLY"
                        },
                        new
                        {
                            Id = new Guid("5b4a6a4b-8ecf-4d0e-80b9-fe8c73aaa4ba"),
                            MaxUserCount = 5,
                            Name = "Dev",
                            Price = 0m,
                            RenewalRate = "MONTHLY"
                        },
                        new
                        {
                            Id = new Guid("12aed472-9d3f-474a-97cb-36e67b058001"),
                            MaxUserCount = 5,
                            Name = "Free",
                            Price = 0.00m,
                            RenewalRate = "MONTHLY"
                        });
                });

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.HasKey("Id")
                        .HasName("pk_profiles");

                    b.ToTable("profiles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("1d77ca4c-1d17-4776-97d4-96f132163fcf"),
                            FirstName = "Jason",
                            LastName = "White"
                        });
                });

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.Tenant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid")
                        .HasColumnName("company_id");

                    b.Property<string>("ConnectionString")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("connection_string");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("display_name");

                    b.Property<string>("DomainNames")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("domain_names");

                    b.Property<string>("Guid")
                        .IsRequired()
                        .HasColumnType("varchar(36)")
                        .HasColumnName("guid");

                    b.Property<string>("IpAddresses")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ip_addresses");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<bool>("IsConfigured")
                        .HasColumnType("boolean")
                        .HasColumnName("is_configured");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<Guid>("TenantPlanId")
                        .HasColumnType("uuid")
                        .HasColumnName("tenant_plan_id");

                    b.HasKey("Id")
                        .HasName("pk_tenants");

                    b.HasIndex("CompanyId")
                        .HasDatabaseName("ix_tenants_company_id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ix_tenants_name");

                    b.HasIndex("TenantPlanId")
                        .IsUnique()
                        .HasDatabaseName("ix_tenants_tenant_plan_id");

                    b.ToTable("tenants", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("42abc90e-65b7-4aab-8795-c10c13a3bb23"),
                            CompanyId = new Guid("1df72ec4-97ba-4f2b-8409-950492f45740"),
                            ConnectionString = "Server=localhost;Port=5432;Database=xyz_localhost_company;User Id=xyz;Password=password;",
                            DisplayName = "Localhost",
                            DomainNames = "",
                            Guid = "b4c4c3f7-b39d-4f84-865f-27266bd7c973",
                            IpAddresses = "",
                            IsActive = false,
                            IsConfigured = false,
                            Name = "localhost",
                            TenantPlanId = new Guid("5da5823e-01bd-4bc7-8b57-519b1f664f9f")
                        },
                        new
                        {
                            Id = new Guid("f16e781e-daca-4724-ab86-062210029054"),
                            CompanyId = new Guid("3779b72a-f2e6-469a-8f1d-107844f089d5"),
                            ConnectionString = "Server=localhost;Port=5432;Database=xyz_dev_company;User Id=xyz;Password=password;",
                            DisplayName = "Dev Company",
                            DomainNames = "",
                            Guid = "2c5522a8-cbde-4fa9-9be1-87eb40f0b250",
                            IpAddresses = "",
                            IsActive = true,
                            IsConfigured = true,
                            Name = "devcompany",
                            TenantPlanId = new Guid("aa8963b1-5813-4f30-a4f5-b671f86d3647")
                        });
                });

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.TenantPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("MaxUserCount")
                        .HasColumnType("integer")
                        .HasColumnName("max_user_count");

                    b.Property<Guid>("PlanId")
                        .HasColumnType("uuid")
                        .HasColumnName("plan_id");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<string>("RenewalRate")
                        .IsRequired()
                        .HasColumnType("varchar(24)")
                        .HasColumnName("renewal_rate");

                    b.HasKey("Id")
                        .HasName("pk_tenant_plans");

                    b.HasIndex("PlanId")
                        .HasDatabaseName("ix_tenant_plans_plan_id");

                    b.ToTable("tenant_plans", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("5da5823e-01bd-4bc7-8b57-519b1f664f9f"),
                            MaxUserCount = 5,
                            PlanId = new Guid("d56f702e-4a82-4085-8992-bd5f1fa36f4b"),
                            Price = 0m,
                            RenewalRate = "MONTHLY"
                        },
                        new
                        {
                            Id = new Guid("aa8963b1-5813-4f30-a4f5-b671f86d3647"),
                            MaxUserCount = 5,
                            PlanId = new Guid("5b4a6a4b-8ecf-4d0e-80b9-fe8c73aaa4ba"),
                            Price = 0m,
                            RenewalRate = "MONTHLY"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Xyz.Core.Entities.Multitenancy.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_role_claims_asp_net_roles_role_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Xyz.Core.Entities.Multitenancy.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_claims_asp_net_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Xyz.Core.Entities.Multitenancy.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_logins_asp_net_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Xyz.Core.Entities.Multitenancy.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_roles_asp_net_roles_role_id");

                    b.HasOne("Xyz.Core.Entities.Multitenancy.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_roles_asp_net_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Xyz.Core.Entities.Multitenancy.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_tokens_asp_net_users_user_id");
                });

            modelBuilder.Entity("user_tenants", b =>
                {
                    b.HasOne("Xyz.Core.Entities.Multitenancy.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("AspNetUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_tenants_asp_net_users_asp_net_user_id");

                    b.HasOne("Xyz.Core.Entities.Multitenancy.Tenant", null)
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_tenants_tenants_tenant_id");
                });

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.ApplicationUser", b =>
                {
                    b.HasOne("Xyz.Core.Entities.Multitenancy.Profile", "Profile")
                        .WithOne("User")
                        .HasForeignKey("Xyz.Core.Entities.Multitenancy.ApplicationUser", "ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_users_profiles_profile_id");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.Tenant", b =>
                {
                    b.HasOne("Xyz.Core.Entities.Multitenancy.Company", "Company")
                        .WithMany("Tenants")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tenants_companies_company_id");

                    b.HasOne("Xyz.Core.Entities.Multitenancy.TenantPlan", "TenantPlan")
                        .WithOne("Tenant")
                        .HasForeignKey("Xyz.Core.Entities.Multitenancy.Tenant", "TenantPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tenants_tenant_plans_tenant_plan_id");

                    b.Navigation("Company");

                    b.Navigation("TenantPlan");
                });

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.TenantPlan", b =>
                {
                    b.HasOne("Xyz.Core.Entities.Multitenancy.Plan", "Plan")
                        .WithMany()
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tenant_plans_plans_plan_id");

                    b.Navigation("Plan");
                });

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.Company", b =>
                {
                    b.Navigation("Tenants");
                });

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.Profile", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.TenantPlan", b =>
                {
                    b.Navigation("Tenant")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
