using SHOPRURETAIL.Domain.Common;
using SHOPRURETAIL.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SHOPRURETAIL.Infrastructure.Configurations;

namespace SHOPRURETAIL.Infrastructure.Contexts
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //All Decimals will have 18,6 Range
            foreach (var property in builder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,6)");
            }

            builder.ApplyConfiguration(new SeedCustomerTypeData());
            builder.ApplyConfiguration(new SeedCustomerData());
            builder.ApplyConfiguration(new SeedDiscountData());
            builder.ApplyConfiguration(new SeedProductData());
            //builder.ApplyConfiguration(new SeedInvoiceData());
            //builder.ApplyConfiguration(new SeedInvoiceDetailsData());
        }
    }
}
