using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CRM.Domain.Entities;
using System.Reflection.Emit;

namespace CRM.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Define relationships
            builder.Entity<Company>()
                .HasMany(c => c.Leads)
                .WithOne(l => l.Company)
                .HasForeignKey(l => l.CompanyId);

            builder.Entity<Company>()
                .HasOne(c => c.Product)
                .WithMany(p => p.Companies)
                .HasForeignKey(c => c.ProductId);

            builder.Entity<Sale>()
                .HasOne(s => s.Lead)
                .WithMany() // Assuming many sales can be made to the lead
                .HasForeignKey(s => s.LeadId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Sale>()
                .HasOne(s => s.Product)
                .WithMany() // Assuming same product can be sold many times to the lead
                .HasForeignKey(s => s.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // Specify decimal values SQL column type
            builder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            builder.Entity<Sale>()
                .Property(r => r.Revenue)
                .HasColumnType("decimal(18,2)");

            // Make table names singular
            builder.Entity<Lead>().ToTable("Lead");
            builder.Entity<Product>().ToTable("Product");
            builder.Entity<Company>().ToTable("Company");
            builder.Entity<Sale>().ToTable("Sale");
        }
    }
}
