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

            modelBuilder.Entity("Xyz.Core.Entities.Tenant.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid?>("ParentPermissionId")
                        .HasColumnType("uuid")
                        .HasColumnName("parent_permission_id");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("varchar(24)")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_permissions");

                    b.HasIndex("ParentPermissionId")
                        .HasDatabaseName("ix_permissions_parent_permission_id");

                    b.ToTable("permissions", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("5bde872c-1d66-4b89-9384-3a6b4aec6244"),
                            Name = "Settings Module",
                            Type = "Settings"
                        },
                        new
                        {
                            Id = new Guid("57d93f69-741d-4809-9cee-8d066fadc5ec"),
                            Name = "User Accounts Module",
                            ParentPermissionId = new Guid("5bde872c-1d66-4b89-9384-3a6b4aec6244"),
                            Type = "UserAccounts"
                        });
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

                    b.Property<Guid?>("ParentUserPermissionId")
                        .HasColumnType("uuid")
                        .HasColumnName("parent_user_permission_id");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uuid")
                        .HasColumnName("permission_id");

                    b.HasKey("Id")
                        .HasName("pk_user_permissions");

                    b.HasIndex("AspNetUserId")
                        .HasDatabaseName("ix_user_permissions_asp_net_user_id");

                    b.HasIndex("ParentUserPermissionId")
                        .HasDatabaseName("ix_user_permissions_parent_user_permission_id");

                    b.HasIndex("PermissionId")
                        .HasDatabaseName("ix_user_permissions_permission_id");

                    b.ToTable("user_permissions", (string)null);
                });

            modelBuilder.Entity("Xyz.Core.Entities.Tenant.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("MakeId")
                        .HasColumnType("uuid")
                        .HasColumnName("make_id");

                    b.Property<Guid>("ModelId")
                        .HasColumnType("uuid")
                        .HasColumnName("model_id");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uuid")
                        .HasColumnName("type_id");

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

                    b.HasKey("Id")
                        .HasName("pk_vehicle_types");

                    b.ToTable("vehicle_types", (string)null);
                });

            modelBuilder.Entity("Xyz.Core.Entities.Tenant.Permission", b =>
                {
                    b.HasOne("Xyz.Core.Entities.Tenant.Permission", "ParentPermission")
                        .WithMany()
                        .HasForeignKey("ParentPermissionId")
                        .HasConstraintName("fk_permissions_permissions_parent_permission_id");

                    b.Navigation("ParentPermission");
                });

            modelBuilder.Entity("Xyz.Core.Entities.Tenant.UserPermission", b =>
                {
                    b.HasOne("Xyz.Core.Entities.Tenant.UserPermission", "ParentUserPermission")
                        .WithMany()
                        .HasForeignKey("ParentUserPermissionId")
                        .HasConstraintName("fk_user_permissions_user_permissions_parent_user_permission_id");

                    b.HasOne("Xyz.Core.Entities.Tenant.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_permissions_permissions_permission_id");

                    b.Navigation("ParentUserPermission");

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
#pragma warning restore 612, 618
        }
    }
}
