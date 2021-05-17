using Domain.Authentication;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class DataBaseContext: IdentityDbContext<ApplicationUser>  // Używając identity należy dziedziczyć po tym db context
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {  
        }
        public DbSet<Deliveries> Deliveries { get; set; }
        public DbSet<GraphicsCard> GraphicsCards { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Processor> Processors { get; set; }
        public DbSet<Suborder> Suborders { get; set; }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Ram> Rams { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<LaptopRamRelationship>()
                .HasKey(lr => new { lr.LaptopId, lr.RamId });
            builder.Entity<LaptopRamRelationship>()
                .HasOne(lr => lr.Laptop)
                .WithMany(lr => lr.Rams)
                .HasForeignKey(lr => lr.LaptopId);
            builder.Entity<LaptopRamRelationship>()
               .HasOne(lr => lr.Ram)
               .WithMany(lr => lr.Laptops)
               .HasForeignKey(lr => lr.RamId);
        }
        
    }
}
