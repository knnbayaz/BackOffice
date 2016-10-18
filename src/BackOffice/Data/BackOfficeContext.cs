using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackOffice.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BackOffice.Data
{
    public class BackOfficeContext : IdentityDbContext<ApplicationUser>
    {
        public BackOfficeContext(DbContextOptions<BackOfficeContext> options) : base(options)
        {

        }

        public DbSet<MeterInfo> MeterInfos { get; set; }

        public DbSet<MeterInvoiceInfo> MeterInvoiceInfos { get; set; }

        public DbSet<MeterInvoiceDetailInfo> MeterInvoiceDetailInfos { get; set; }

        public DbSet<GDDKTracking> GDDKTrackings { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<GDDKTracking>()
            //    .HasOne(g => g.MeterInvoiceDetailInfo)
            //    .WithOne(m => m.GDDKTracking);

            modelBuilder.Entity<GDDKTracking>()
                .HasOne(m => m.MeterInvoiceDetailInfo)
                .WithOne(g => g.GDDKTracking)
                .HasForeignKey<MeterInvoiceDetailInfo>(p => p.MeterInvoiceDetailInfoId);


            base.OnModelCreating(modelBuilder);
        }

    }
}
