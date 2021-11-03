using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SHOPRURETAIL.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Extensions
{
    public static class ServiceExtensions
    {
        //public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        //    services.AddScoped<IRepositoryManager, RepositoryManager>();


        public static void ConfigureSqlLite(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("sqlLiteConnection")));
    }
}
