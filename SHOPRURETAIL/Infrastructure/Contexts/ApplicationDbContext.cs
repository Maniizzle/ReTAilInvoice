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
            builder.ApplyConfiguration(new SeedCustomerTypeData());
            builder.ApplyConfiguration(new SeedCustomerData());
            builder.ApplyConfiguration(new SeedProductData());
            builder.ApplyConfiguration(new SeedDiscountData());

        }
    }
}
