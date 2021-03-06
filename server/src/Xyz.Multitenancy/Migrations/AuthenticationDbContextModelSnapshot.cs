// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Xyz.Multitenancy.Data;

#nullable disable

namespace Xyz.Multitenancy.Migrations
{
    [DbContext(typeof(MultitenancyDbContext))]
    partial class AuthenticationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.BillingInvoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<decimal>("AmountDue")
                        .HasColumnType("numeric")
                        .HasColumnName("amount_due");

                    b.Property<decimal>("AmountPaid")
                        .HasColumnType("numeric")
                        .HasColumnName("amount_paid");

                    b.Property<string>("BillingReason")
                        .HasColumnType("text")
                        .HasColumnName("billing_reason");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on")
                        .HasColumnOrder(1);

                    b.Property<DateTime?>("DeleteOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("delete_on")
                        .HasColumnOrder(3);

                    b.Property<string>("ExternalInvoiceId")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasColumnName("external_invoice_id");

                    b.Property<string>("InvoicePdfUrl")
                        .HasColumnType("text")
                        .HasColumnName("invoice_pdf_url");

                    b.Property<string>("InvoiceUrl")
                        .HasColumnType("text")
                        .HasColumnName("invoice_url");

                    b.Property<DateTime?>("PaidDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("paid_date");

                    b.Property<DateTime>("PeriodEndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("period_end_date");

                    b.Property<DateTime>("PeriodStartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("period_start_date");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(24)")
                        .HasColumnName("status");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid")
                        .HasColumnName("tenant_id");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("transaction_date");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_on")
                        .HasColumnOrder(2);

                    b.HasKey("Id")
                        .HasName("pk_billing_invoices");

                    b.HasIndex("ExternalInvoiceId")
                        .IsUnique()
                        .HasDatabaseName("ix_billing_invoices_external_invoice_id");

                    b.HasIndex("TenantId")
                        .HasDatabaseName("ix_billing_invoices_tenant_id");

                    b.ToTable("billing_invoices", (string)null);
                });

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.CardDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("brand");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on")
                        .HasColumnOrder(1);

                    b.Property<DateTime?>("DeleteOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("delete_on")
                        .HasColumnOrder(3);

                    b.Property<string>("ExternalDefaultPaymentSourceId")
                        .HasColumnType("varchar(256)")
                        .HasColumnName("external_default_payment_source_id");

                    b.Property<bool>("IsValid")
                        .HasColumnType("boolean")
                        .HasColumnName("is_valid");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("token");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_on")
                        .HasColumnOrder(2);

                    b.HasKey("Id")
                        .HasName("pk_card_details");

                    b.HasIndex("ExternalDefaultPaymentSourceId")
                        .IsUnique()
                        .HasDatabaseName("ix_card_details_external_default_payment_source_id");

                    b.ToTable("card_details", (string)null);
                });

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("ExternalCustomerId")
                        .HasColumnType("varchar(256)")
                        .HasColumnName("external_customer_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_companies");

                    b.HasIndex("ExternalCustomerId")
                        .IsUnique()
                        .HasDatabaseName("ix_companies_external_customer_id");

                    b.ToTable("companies", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("1853ecf6-5273-4190-852f-7deb338edcd7"),
                            Name = "Localhost"
                        });
                });

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.PaymentDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<Guid>("CardDetailsId")
                        .HasColumnType("uuid")
                        .HasColumnName("card_details_id");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("city");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on")
                        .HasColumnOrder(1);

                    b.Property<DateTime?>("DeleteOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("delete_on")
                        .HasColumnOrder(3);

                    b.Property<string>("ExternalSubscriptionId")
                        .HasColumnType("varchar(256)")
                        .HasColumnName("external_subscription_id");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("PaymentProcessor")
                        .IsRequired()
                        .HasColumnType("varchar(24)")
                        .HasColumnName("payment_processor");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("state");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_on")
                        .HasColumnOrder(2);

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("zip");

                    b.HasKey("Id")
                        .HasName("pk_payment_details");

                    b.HasIndex("CardDetailsId")
                        .HasDatabaseName("ix_payment_details_card_details_id");

                    b.HasIndex("ExternalSubscriptionId")
                        .IsUnique()
                        .HasDatabaseName("ix_payment_details_external_subscription_id");

                    b.ToTable("payment_details", (string)null);
                });

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.Plan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("ExternalPlanId")
                        .HasColumnType("varchar(256)")
                        .HasColumnName("external_plan_id");

                    b.Property<int>("MaxUserCount")
                        .HasColumnType("integer")
                        .HasColumnName("max_user_count");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<bool>("PaymentRequired")
                        .HasColumnType("boolean")
                        .HasColumnName("payment_required");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<string>("RenewalRate")
                        .IsRequired()
                        .HasColumnType("varchar(24)")
                        .HasColumnName("renewal_rate");

                    b.HasKey("Id")
                        .HasName("pk_plans");

                    b.HasIndex("ExternalPlanId")
                        .IsUnique()
                        .HasDatabaseName("ix_plans_external_plan_id");

                    b.ToTable("plans", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("81048da5-948f-4304-a5b2-908ac1ee44b7"),
                            MaxUserCount = 2,
                            Name = "Free",
                            PaymentRequired = false,
                            Price = 0.00m,
                            RenewalRate = "MONTHLY"
                        },
                        new
                        {
                            Id = new Guid("81048da5-948f-4304-a5b2-908ac1ee44b8"),
                            MaxUserCount = 5,
                            Name = "Basic",
                            PaymentRequired = true,
                            Price = 10.00m,
                            RenewalRate = "MONTHLY"
                        },
                        new
                        {
                            Id = new Guid("81048da5-948f-4304-a5b2-908ac1ee44b9"),
                            MaxUserCount = 100,
                            Name = "Pro",
                            PaymentRequired = true,
                            Price = 100.00m,
                            RenewalRate = "MONTHLY"
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

                    b.Property<Guid?>("PaymentDetailsId")
                        .HasColumnType("uuid")
                        .HasColumnName("payment_details_id");

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

                    b.HasIndex("PaymentDetailsId")
                        .HasDatabaseName("ix_tenants_payment_details_id");

                    b.HasIndex("TenantPlanId")
                        .IsUnique()
                        .HasDatabaseName("ix_tenants_tenant_plan_id");

                    b.ToTable("tenants", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("1d9466ad-61e8-4890-8edc-9d89218135c0"),
                            CompanyId = new Guid("1853ecf6-5273-4190-852f-7deb338edcd7"),
                            ConnectionString = "Server=localhost;Port=5432;Database=xyz_localhost_company;User Id=xyz;Password=password;",
                            DisplayName = "Localhost",
                            DomainNames = "",
                            Guid = "fb86c89b-f310-4180-8fd2-d85e22f64b8f",
                            IpAddresses = "",
                            IsActive = false,
                            IsConfigured = false,
                            Name = "localhost",
                            TenantPlanId = new Guid("d687edcb-68de-49f2-ae55-081e962d2a6e")
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
                            Id = new Guid("d687edcb-68de-49f2-ae55-081e962d2a6e"),
                            MaxUserCount = 2,
                            PlanId = new Guid("81048da5-948f-4304-a5b2-908ac1ee44b7"),
                            Price = 0.00m,
                            RenewalRate = "MONTHLY"
                        });
                });

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.BillingInvoice", b =>
                {
                    b.HasOne("Xyz.Core.Entities.Multitenancy.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_billing_invoices_tenants_tenant_id");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.PaymentDetails", b =>
                {
                    b.HasOne("Xyz.Core.Entities.Multitenancy.CardDetails", "CardDetails")
                        .WithMany()
                        .HasForeignKey("CardDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_payment_details_card_details_card_details_id");

                    b.Navigation("CardDetails");
                });

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.Tenant", b =>
                {
                    b.HasOne("Xyz.Core.Entities.Multitenancy.Company", "Company")
                        .WithMany("Tenants")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tenants_companies_company_id");

                    b.HasOne("Xyz.Core.Entities.Multitenancy.PaymentDetails", "PaymentDetails")
                        .WithMany()
                        .HasForeignKey("PaymentDetailsId")
                        .HasConstraintName("fk_tenants_payment_details_payment_details_id");

                    b.HasOne("Xyz.Core.Entities.Multitenancy.TenantPlan", "TenantPlan")
                        .WithOne("Tenant")
                        .HasForeignKey("Xyz.Core.Entities.Multitenancy.Tenant", "TenantPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tenants_tenant_plans_tenant_plan_id");

                    b.Navigation("Company");

                    b.Navigation("PaymentDetails");

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

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.TenantPlan", b =>
                {
                    b.Navigation("Tenant")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
