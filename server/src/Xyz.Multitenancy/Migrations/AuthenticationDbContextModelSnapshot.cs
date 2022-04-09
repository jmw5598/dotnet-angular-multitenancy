﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Xyz.Multitenancy.Data;

#nullable disable

namespace Xyz.Multitenancy.Migrations
{
    [DbContext(typeof(AuthenticationDbContext))]
    partial class AuthenticationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            AspNetUserId = new Guid("ab0e1522-27ab-4a18-921e-e763a93d7212"),
                            TenantId = new Guid("c37dab57-8165-4961-be18-8b01ba5353be")
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
                            Id = new Guid("9f22eab1-9b43-4b91-9ab1-e94a0129e6ad"),
                            ConcurrencyStamp = "60f2d4fd-8177-4bde-a289-16e5c860e114",
                            Name = "ROOT",
                            NormalizedName = "ROOT"
                        },
                        new
                        {
                            Id = new Guid("0db7deec-9ab0-4a6a-b44a-5cff0f028db5"),
                            ConcurrencyStamp = "029632df-06a8-4e0b-aa36-d6a50480d859",
                            Name = "ADMIN",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("f0dafa3d-22e0-4d5a-b17a-675832754a37"),
                            ConcurrencyStamp = "a34c2b4a-8114-4d3e-be07-8307dd536f3c",
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
                            Id = new Guid("ab0e1522-27ab-4a18-921e-e763a93d7212"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b0d5ad44-1c0c-4d3d-b0e7-0d5bb656a71b",
                            Email = "jmw5598@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "JMW5598@gmail.com",
                            NormalizedUserName = "JMW5598@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEOF2VDmkhJX59h99+xjitHSyRPk5Yjhv4EJ9VEyyB2zLh9Ob36dzUDGXa9c6oIQBXA==",
                            PhoneNumberConfirmed = false,
                            ProfileId = new Guid("0c72fc2e-f24b-4382-b720-eadc337fcee7"),
                            TwoFactorEnabled = false,
                            UserName = "jmw5598@gmail.com"
                        });
                });

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.ApplicationUserRole", b =>
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
                            UserId = new Guid("ab0e1522-27ab-4a18-921e-e763a93d7212"),
                            RoleId = new Guid("9f22eab1-9b43-4b91-9ab1-e94a0129e6ad")
                        },
                        new
                        {
                            UserId = new Guid("ab0e1522-27ab-4a18-921e-e763a93d7212"),
                            RoleId = new Guid("0db7deec-9ab0-4a6a-b44a-5cff0f028db5")
                        },
                        new
                        {
                            UserId = new Guid("ab0e1522-27ab-4a18-921e-e763a93d7212"),
                            RoleId = new Guid("f0dafa3d-22e0-4d5a-b17a-675832754a37")
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
                            Id = new Guid("f028abad-6240-4614-90dd-3987343c8b55"),
                            Name = "Localhost"
                        },
                        new
                        {
                            Id = new Guid("e77083cd-0b25-49ad-9d46-3d52e154f7af"),
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
                            Id = new Guid("82b9acec-ce7c-4982-b4b8-6c97a4d2e691"),
                            MaxUserCount = 5,
                            Name = "Localhost Dev Plan",
                            Price = 0m,
                            RenewalRate = "MONTHLY"
                        },
                        new
                        {
                            Id = new Guid("0c6aa9b2-4bb8-40b0-8040-1b382c08679e"),
                            MaxUserCount = 5,
                            Name = "Dev",
                            Price = 0m,
                            RenewalRate = "MONTHLY"
                        },
                        new
                        {
                            Id = new Guid("980e101e-517a-47e3-9776-b957c0d4cdc8"),
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
                            Id = new Guid("0c72fc2e-f24b-4382-b720-eadc337fcee7"),
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
                            Id = new Guid("7dca1b51-adab-4337-8199-b6b04f040f48"),
                            CompanyId = new Guid("f028abad-6240-4614-90dd-3987343c8b55"),
                            ConnectionString = "Server=localhost;Port=5432;Database=xyz_localhost_company;User Id=xyz;Password=password;",
                            DisplayName = "Localhost",
                            DomainNames = "",
                            Guid = "093eea5a-c4a9-4e72-8de0-b0eba3d916ce",
                            IpAddresses = "",
                            IsActive = false,
                            IsConfigured = false,
                            Name = "localhost",
                            TenantPlanId = new Guid("93c762ed-8bc3-4cc2-aef6-e4b82647cde8")
                        },
                        new
                        {
                            Id = new Guid("c37dab57-8165-4961-be18-8b01ba5353be"),
                            CompanyId = new Guid("e77083cd-0b25-49ad-9d46-3d52e154f7af"),
                            ConnectionString = "Server=localhost;Port=5432;Database=xyz_dev_company;User Id=xyz;Password=password;",
                            DisplayName = "Dev Company",
                            DomainNames = "",
                            Guid = "ab914af2-6458-4e87-9219-4cd01d5d223f",
                            IpAddresses = "",
                            IsActive = true,
                            IsConfigured = true,
                            Name = "devcompany",
                            TenantPlanId = new Guid("e066c269-5895-4d89-ba89-266f12e011f5")
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
                            Id = new Guid("93c762ed-8bc3-4cc2-aef6-e4b82647cde8"),
                            MaxUserCount = 5,
                            PlanId = new Guid("82b9acec-ce7c-4982-b4b8-6c97a4d2e691"),
                            Price = 0m,
                            RenewalRate = "MONTHLY"
                        },
                        new
                        {
                            Id = new Guid("e066c269-5895-4d89-ba89-266f12e011f5"),
                            MaxUserCount = 5,
                            PlanId = new Guid("0c6aa9b2-4bb8-40b0-8040-1b382c08679e"),
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

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.ApplicationUserRole", b =>
                {
                    b.HasOne("Xyz.Core.Entities.Multitenancy.ApplicationRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_roles_asp_net_roles_role_id");

                    b.HasOne("Xyz.Core.Entities.Multitenancy.ApplicationUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_roles_asp_net_users_user_id");

                    b.Navigation("Role");

                    b.Navigation("User");
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

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.ApplicationRole", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.ApplicationUser", b =>
                {
                    b.Navigation("UserRoles");
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
