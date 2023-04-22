using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Entities.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Models.Product>
    {
        public void Configure(EntityTypeBuilder<Models.Product> builder)
        {
            builder.HasData(
                new Models.Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Tomatoe",
                    Price = 123.00M
                },
                new Models.Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Potatoe",
                    Price = 100.00M
                },
                new Models.Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Sausage",
                    Price = 250.00M
                }
                );
        }
    }
}
