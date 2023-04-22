using Microsoft.EntityFrameworkCore;
using Product.Entities.Configuration;
using Product.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Product.Entities
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Models.Product>().Property(e => e.Price).HasPrecision(18, 2);

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }

        public DbSet<Models.Product> Product { get; set; }
    }
}
