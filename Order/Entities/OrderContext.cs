using Order.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Order.Entities
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().Property(e => e.Price).HasPrecision(18, 2);
            modelBuilder.Entity<Models.Order>().Property(e => e.Total).HasPrecision(18, 2);
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Models.Order> Order { get; set; }
        public DbSet<OrderProducts> OrderProducts { get; set; }
    }
}