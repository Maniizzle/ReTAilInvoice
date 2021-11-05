using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHOPRURETAIL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHOPRURETAIL.Infrastructure.Configurations
{
    public class SeedCustomerTypeData : IEntityTypeConfiguration<CustomerType>
    {
        public void Configure(EntityTypeBuilder<CustomerType> builder)
        {
            builder.HasIndex(c => c.Name).IsUnique();
            builder.HasData
            (
                new CustomerType
                {
                   Id=1,Name= "Regular"
                },
                new CustomerType
                {
                  Id=2, Name="Affiliate"
                },
                new CustomerType
                {
                  Id=3, Name="Employee"
                }
            );
        }
    }
}
