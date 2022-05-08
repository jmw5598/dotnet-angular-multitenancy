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
                            Id = new Guid("9c153e12-f706-4f1d-a0c8-478323008b69"),
                            Name = "Settings Module"
                        },
                        new
                        {
                            Id = new Guid("8fc1acef-5ad0-45d5-aede-67a82633cc35"),
                            Name = "Dashboard Module"
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
                            Id = new Guid("903bcea3-cebc-41d4-92cf-ab75e653981a"),
                            ModulePermissionId = new Guid("9c153e12-f706-4f1d-a0c8-478323008b69"),
                            Name = "User Accounts Module"
                        },
                        new
                        {
                            Id = new Guid("9d1ae49c-67a2-48f2-b1cb-e58ab255a339"),
                            ModulePermissionId = new Guid("8fc1acef-5ad0-45d5-aede-67a82633cc35"),
                            Name = "Dashboard Overview Module"
                        });
                });

            modelBuilder.Entity("Xyz.Core.Entities.Tenant.UserModulePermission", b =>
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

                    b.HasKey("Id")
                        .HasName("pk_user_module_permissions");

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

                    b.Property<Guid>("AspNetUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("asp_net_user_id");

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

                    b.HasIndex("AspNetUserId")
                        .HasDatabaseName("ix_user_permissions_asp_net_user_id");

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
                    b.HasOne("Xyz.Core.Entities.Tenant.ModulePermission", "ModulePermission")
                        .WithMany("Permissions")
                        .HasForeignKey("ModulePermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_permissions_module_permissions_module_permission_id");

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

                    b.HasOne("Xyz.Core.Entities.Tenant.UserModulePermission", "UserModulePermission")
                        .WithMany("UserPermissions")
                        .HasForeignKey("UserModulePermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_permissions_user_module_permissions_user_module_permis");

                    b.Navigation("Permission");

                    b.Navigation("UserModulePermission");
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

            modelBuilder.Entity("Xyz.Core.Entities.Tenant.UserModulePermission", b =>
                {
                    b.Navigation("UserPermissions");
                });
#pragma warning restore 612, 618
        }
    }
}
