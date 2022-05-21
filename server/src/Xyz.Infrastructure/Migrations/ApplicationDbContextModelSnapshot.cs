﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Xyz.Infrastructure.Data;

#nullable disable

namespace Xyz.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Xyz.Core.Entities.Tenant.ModulePermission", b =>
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
                        .HasName("pk_module_permissions");

                    b.ToTable("module_permissions", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("9c4b9ac3-049b-4ca4-a3ee-31feb38db5aa"),
                            Name = "Administration Module"
                        },
                        new
                        {
                            Id = new Guid("bbbd9612-79ba-4eff-98c6-e8b4adeaa8e1"),
                            Name = "Dashboard Module"
                        },
                        new
                        {
                            Id = new Guid("ff7b5436-680a-439f-92f2-0c1d94063a0e"),
                            Name = "Security Module"
                        });
                });

            modelBuilder.Entity("Xyz.Core.Entities.Tenant.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("ModulePermissionId")
                        .HasColumnType("uuid")
                        .HasColumnName("module_permission_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_permissions");

                    b.HasIndex("ModulePermissionId")
                        .HasDatabaseName("ix_permissions_module_permission_id");

                    b.ToTable("permissions", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("659c145c-9cb3-44a1-9460-33ce62fe2a1a"),
                            ModulePermissionId = new Guid("9c4b9ac3-049b-4ca4-a3ee-31feb38db5aa"),
                            Name = "Settings"
                        },
                        new
                        {
                            Id = new Guid("a5446dd7-49d8-47df-a6a6-1dd7e19db66f"),
                            ModulePermissionId = new Guid("9c4b9ac3-049b-4ca4-a3ee-31feb38db5aa"),
                            Name = "User Accounts"
                        },
                        new
                        {
                            Id = new Guid("1b7e0a04-0b20-43bf-8b3f-e55aeff03eca"),
                            ModulePermissionId = new Guid("bbbd9612-79ba-4eff-98c6-e8b4adeaa8e1"),
                            Name = "Dashboard Overview"
                        },
                        new
                        {
                            Id = new Guid("2f81c044-9412-47d2-a64b-5dca08b98c97"),
                            ModulePermissionId = new Guid("ff7b5436-680a-439f-92f2-0c1d94063a0e"),
                            Name = "Security General"
                        },
                        new
                        {
                            Id = new Guid("e792babe-a410-436f-8f4b-bcae9d71423f"),
                            ModulePermissionId = new Guid("ff7b5436-680a-439f-92f2-0c1d94063a0e"),
                            Name = "Security Permissions"
                        });
                });

            modelBuilder.Entity("Xyz.Core.Entities.Tenant.TemplateModulePermission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("HasAccess")
                        .HasColumnType("boolean")
                        .HasColumnName("has_access");

                    b.Property<Guid>("ModulePermissionId")
                        .HasColumnType("uuid")
                        .HasColumnName("module_permission_id");

                    b.Property<Guid>("TemplateModulePermissionNameId")
                        .HasColumnType("uuid")
                        .HasColumnName("template_module_permission_name_id");

                    b.HasKey("Id")
                        .HasName("pk_template_module_permissions");

                    b.HasIndex("ModulePermissionId")
                        .HasDatabaseName("ix_template_module_permissions_module_permission_id");

                    b.HasIndex("TemplateModulePermissionNameId")
                        .HasDatabaseName("ix_template_module_permissions_template_module_permission_name");

                    b.ToTable("template_module_permissions", (string)null);
                });

            modelBuilder.Entity("Xyz.Core.Entities.Tenant.TemplateModulePermissionName", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on");

                    b.Property<DateTime?>("DeleteOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("delete_on");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_on");

                    b.HasKey("Id")
                        .HasName("pk_template_module_permission_names");

                    b.ToTable("template_module_permission_names", (string)null);
                });

            modelBuilder.Entity("Xyz.Core.Entities.Tenant.TemplatePermission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("HasAccess")
                        .HasColumnType("boolean")
                        .HasColumnName("has_access");

                    b.Property<Guid>("ModulePermissionId")
                        .HasColumnType("uuid")
                        .HasColumnName("module_permission_id");

                    b.Property<Guid>("TemplateModulePermissionId")
                        .HasColumnType("uuid")
                        .HasColumnName("template_module_permission_id");

                    b.HasKey("Id")
                        .HasName("pk_template_permissions");

                    b.HasIndex("ModulePermissionId")
                        .HasDatabaseName("ix_template_permissions_module_permission_id");

                    b.HasIndex("TemplateModulePermissionId")
                        .HasDatabaseName("ix_template_permissions_template_module_permission_id");

                    b.ToTable("template_permissions", (string)null);
                });

            modelBuilder.Entity("Xyz.Core.Entities.Tenant.UserModulePermission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AspNetUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("asp_net_user_id");

                    b.Property<bool>("HasAccess")
                        .HasColumnType("boolean")
                        .HasColumnName("has_access");

                    b.Property<Guid>("ModulePermissionId")
                        .HasColumnType("uuid")
                        .HasColumnName("module_permission_id");

                    b.HasKey("Id")
                        .HasName("pk_user_module_permissions");

                    b.HasIndex("AspNetUserId")
                        .HasDatabaseName("ix_user_module_permissions_asp_net_user_id");

                    b.HasIndex("ModulePermissionId")
                        .HasDatabaseName("ix_user_module_permissions_module_permission_id");

                    b.ToTable("user_module_permissions", (string)null);
                });

            modelBuilder.Entity("Xyz.Core.Entities.Tenant.UserPermission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("CanCreate")
                        .HasColumnType("boolean")
                        .HasColumnName("can_create");

                    b.Property<bool>("CanDelete")
                        .HasColumnType("boolean")
                        .HasColumnName("can_delete");

                    b.Property<bool>("CanRead")
                        .HasColumnType("boolean")
                        .HasColumnName("can_read");

                    b.Property<bool>("CanUpdate")
                        .HasColumnType("boolean")
                        .HasColumnName("can_update");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uuid")
                        .HasColumnName("permission_id");

                    b.Property<Guid>("UserModulePermissionId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_module_permission_id");

                    b.HasKey("Id")
                        .HasName("pk_user_permissions");

                    b.HasIndex("PermissionId")
                        .HasDatabaseName("ix_user_permissions_permission_id");

                    b.HasIndex("UserModulePermissionId")
                        .HasDatabaseName("ix_user_permissions_user_module_permission_id");

                    b.ToTable("user_permissions", (string)null);
                });

            modelBuilder.Entity("Xyz.Core.Entities.Tenant.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on");

                    b.Property<DateTime?>("DeleteOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("delete_on");

                    b.Property<Guid>("MakeId")
                        .HasColumnType("uuid")
                        .HasColumnName("make_id");

                    b.Property<Guid>("ModelId")
                        .HasColumnType("uuid")
                        .HasColumnName("model_id");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uuid")
                        .HasColumnName("type_id");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_on");

                    b.Property<string>("Vin")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("vin");

                    b.HasKey("Id")
                        .HasName("pk_vehicles");

                    b.HasIndex("MakeId")
                        .HasDatabaseName("ix_vehicles_make_id");

                    b.HasIndex("ModelId")
                        .HasDatabaseName("ix_vehicles_model_id");

                    b.HasIndex("TypeId")
                        .HasDatabaseName("ix_vehicles_type_id");

                    b.ToTable("vehicles", (string)null);
                });

            modelBuilder.Entity("Xyz.Core.Entities.Tenant.VehicleMake", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on");

                    b.Property<DateTime?>("DeleteOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("delete_on");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_on");

                    b.HasKey("Id")
                        .HasName("pk_vehicle_makes");

                    b.ToTable("vehicle_makes", (string)null);
                });

            modelBuilder.Entity("Xyz.Core.Entities.Tenant.VehicleModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on");

                    b.Property<DateTime?>("DeleteOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("delete_on");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_on");

                    b.HasKey("Id")
                        .HasName("pk_vehicle_models");

                    b.ToTable("vehicle_models", (string)null);
                });

            modelBuilder.Entity("Xyz.Core.Entities.Tenant.VehicleType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on");

                    b.Property<DateTime?>("DeleteOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("delete_on");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_on");

                    b.HasKey("Id")
                        .HasName("pk_vehicle_types");

                    b.ToTable("vehicle_types", (string)null);
                });

            modelBuilder.Entity("Xyz.Core.Entities.Tenant.Permission", b =>
                {
                    b.HasOne("Xyz.Core.Entities.Tenant.ModulePermission", null)
                        .WithMany("Permissions")
                        .HasForeignKey("ModulePermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_permissions_module_permissions_module_permission_id");
                });

            modelBuilder.Entity("Xyz.Core.Entities.Tenant.TemplateModulePermission", b =>
                {
                    b.HasOne("Xyz.Core.Entities.Tenant.ModulePermission", "ModulePermission")
                        .WithMany()
                        .HasForeignKey("ModulePermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_template_module_permissions_module_permissions_module_permi");

                    b.HasOne("Xyz.Core.Entities.Tenant.TemplateModulePermissionName", null)
                        .WithMany("TemplateModulePermissions")
                        .HasForeignKey("TemplateModulePermissionNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_template_module_permissions_template_module_permission_name");

                    b.Navigation("ModulePermission");
                });

            modelBuilder.Entity("Xyz.Core.Entities.Tenant.TemplatePermission", b =>
                {
                    b.HasOne("Xyz.Core.Entities.Tenant.ModulePermission", "ModulePermission")
                        .WithMany()
                        .HasForeignKey("ModulePermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_template_permissions_module_permissions_module_permission_id");

                    b.HasOne("Xyz.Core.Entities.Tenant.TemplateModulePermission", null)
                        .WithMany("TemplatePermissions")
                        .HasForeignKey("TemplateModulePermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_template_permissions_template_module_permissions_template_m");

                    b.Navigation("ModulePermission");
                });

            modelBuilder.Entity("Xyz.Core.Entities.Tenant.UserModulePermission", b =>
                {
                    b.HasOne("Xyz.Core.Entities.Tenant.ModulePermission", "ModulePermission")
                        .WithMany()
                        .HasForeignKey("ModulePermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_module_permissions_module_permissions_module_permissio");

                    b.Navigation("ModulePermission");
                });

            modelBuilder.Entity("Xyz.Core.Entities.Tenant.UserPermission", b =>
                {
                    b.HasOne("Xyz.Core.Entities.Tenant.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_permissions_permissions_permission_id");

                    b.HasOne("Xyz.Core.Entities.Tenant.UserModulePermission", null)
                        .WithMany("UserPermissions")
                        .HasForeignKey("UserModulePermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_permissions_user_module_permissions_user_module_permis");

                    b.Navigation("Permission");
                });

            modelBuilder.Entity("Xyz.Core.Entities.Tenant.Vehicle", b =>
                {
                    b.HasOne("Xyz.Core.Entities.Tenant.VehicleMake", "Make")
                        .WithMany()
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_vehicles_vehicle_makes_make_id");

                    b.HasOne("Xyz.Core.Entities.Tenant.VehicleModel", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_vehicles_vehicle_models_model_id");

                    b.HasOne("Xyz.Core.Entities.Tenant.VehicleType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_vehicles_vehicle_types_type_id");

                    b.Navigation("Make");

                    b.Navigation("Model");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Xyz.Core.Entities.Tenant.ModulePermission", b =>
                {
                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("Xyz.Core.Entities.Tenant.TemplateModulePermission", b =>
                {
                    b.Navigation("TemplatePermissions");
                });

            modelBuilder.Entity("Xyz.Core.Entities.Tenant.TemplateModulePermissionName", b =>
                {
                    b.Navigation("TemplateModulePermissions");
                });

            modelBuilder.Entity("Xyz.Core.Entities.Tenant.UserModulePermission", b =>
                {
                    b.Navigation("UserPermissions");
                });
#pragma warning restore 612, 618
        }
    }
}
