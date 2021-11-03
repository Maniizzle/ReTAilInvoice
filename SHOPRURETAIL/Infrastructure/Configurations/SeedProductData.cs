using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHOPRURETAIL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHOPRURETAIL.Infrastructure.Configurations

{
    public class SeedProductData : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData
            (
                new Product
                {
                     Id=1,
                    Category = "Groceries",
                    Description="OLoyin Beans",
                    Name="Beans",
                       UnitPrice=500
                },
                new Product
                {
                    Id = 2,
                    Category = "Electronics",
                    Description = "Beats by Dre Headset",
                    Name = "HeadSet",
                    UnitPrice = 5000
                },
                new Product
                {
                    Id = 3,
                    Category = "Groceries",
                    Description = "Power Oil",
                    Name = " Oil",
                    UnitPrice = 1500
                },
               new Product
               {
                   Id = 4,
                   Category = "Groceries",
                    Description = "Poundo Yam",
                   Name = "Poundo Yam",
                   UnitPrice = 7800
               },
               new Product
               {
                   Id = 5,
                    Description = "Poundo Yam",
                   Category = "1 Crate of Raw Egg",
                   Name = "Egg",
                   UnitPrice = 5600
               },
               new Product
               {
                   Id = 6,
                    Description = "Binatone Standing Fan",
                   Category = "Electronics",
                   Name = "Binatone Fan",
                   UnitPrice = 9000
               }
            );
        }
    }
}
