using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BackOffice.Data;

namespace BackOffice.Migrations
{
    [DbContext(typeof(BackOfficeContext))]
    [Migration("20161018191555_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackOffice.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("BackOffice.Models.GDDKTracking", b =>
                {
                    b.Property<int>("GDDKTrackingId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("ConsumeAfter");

                    b.Property<decimal>("ConsumeBefore");

                    b.Property<DateTime>("ConsumePeriod");

                    b.Property<int>("EnxpConsumeId");

                    b.Property<int?>("MeterInfoId");

                    b.Property<decimal>("RemainedConsume");

                    b.HasKey("GDDKTrackingId");

                    b.HasIndex("MeterInfoId");

                    b.ToTable("GDDKTrackings");
                });

            modelBuilder.Entity("BackOffice.Models.MeterInfo", b =>
                {
                    b.Property<int>("MeterInfoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CityName");

                    b.Property<string>("DistrictName");

                    b.Property<int>("EnxpId");

                    b.Property<string>("MeterName");

                    b.Property<int>("MunicipalityTaxRatio");

                    b.Property<int>("PmumId");

                    b.HasKey("MeterInfoId");

                    b.ToTable("MeterInfos");
                });

            modelBuilder.Entity("BackOffice.Models.MeterInvoiceDetailInfo", b =>
                {
                    b.Property<int>("MeterInvoiceDetailInfoId");

                    b.Property<decimal>("Consume");

                    b.Property<decimal>("DistributionPrice");

                    b.Property<decimal>("EnergyFundTax");

                    b.Property<decimal>("EnergyPrice");

                    b.Property<int?>("MeterInvoiceInfoId");

                    b.Property<decimal>("MunicipalityTax");

                    b.Property<decimal>("TRTTax");

                    b.HasKey("MeterInvoiceDetailInfoId");

                    b.HasIndex("MeterInvoiceDetailInfoId")
                        .IsUnique();

                    b.HasIndex("MeterInvoiceInfoId");

                    b.ToTable("MeterInvoiceDetailInfos");
                });

            modelBuilder.Entity("BackOffice.Models.MeterInvoiceInfo", b =>
                {
                    b.Property<int>("MeterInvoiceInfoId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal?>("ClearingConsumeTotalPrice");

                    b.Property<decimal?>("CorrectionConsumeTotalPrice");

                    b.Property<int?>("MeterInfoId");

                    b.Property<DateTime>("Period");

                    b.Property<decimal>("PeriodConsumeTotalPrice");

                    b.Property<decimal>("Tax");

                    b.Property<decimal>("TotalPriceWithTax");

                    b.HasKey("MeterInvoiceInfoId");

                    b.HasIndex("MeterInfoId");

                    b.ToTable("MeterInvoiceInfos");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BackOffice.Models.GDDKTracking", b =>
                {
                    b.HasOne("BackOffice.Models.MeterInfo", "MeterInfo")
                        .WithMany("GDDTrackings")
                        .HasForeignKey("MeterInfoId");
                });

            modelBuilder.Entity("BackOffice.Models.MeterInvoiceDetailInfo", b =>
                {
                    b.HasOne("BackOffice.Models.GDDKTracking", "GDDKTracking")
                        .WithOne("MeterInvoiceDetailInfo")
                        .HasForeignKey("BackOffice.Models.MeterInvoiceDetailInfo", "MeterInvoiceDetailInfoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BackOffice.Models.MeterInvoiceInfo", "MeterInvoiceInfo")
                        .WithMany("MeterInvoiceDetailInfos")
                        .HasForeignKey("MeterInvoiceInfoId");
                });

            modelBuilder.Entity("BackOffice.Models.MeterInvoiceInfo", b =>
                {
                    b.HasOne("BackOffice.Models.MeterInfo", "MeterInfo")
                        .WithMany("MeterInvoiceInfos")
                        .HasForeignKey("MeterInfoId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BackOffice.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BackOffice.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BackOffice.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
