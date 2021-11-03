using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHOPRURETAIL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHOPRURETAIL.Infrastructure.Configurations
{
    public class SeedDiscountData : IEntityTypeConfiguration<DiscountType>
    {
        public void Configure(EntityTypeBuilder<DiscountType> builder)
        {
            builder.HasIndex(c => c.Name).IsUnique();
            builder.HasData
            (
                new DiscountType
                {
                    Id = 1,
                    Name = "Affiliate",
                    Value = 10,
                    IsPercentage = true
                },
                new DiscountType
                {
                    Id = 2,
                    Name = "Employee",
                    Value = 30,
                    IsPercentage = true
                },
                new DiscountType
                {
                    Id = 3,
                    Name = "Customer",
                    Value = 5,
                    IsPercentage = true
                },
                new DiscountType
                {
                    Id = 4,
                    Name = "100DollarBill",
                    Value = 5,
                    IsPercentage = false
                }
            );
        }
    }
}
