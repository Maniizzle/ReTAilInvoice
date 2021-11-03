using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SHOPRURETAIL.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using FluentValidation;
using System.Reflection;
using MediatR;
using MediatR.Extensions.FluentValidation.AspNetCore;
using SHOPRURETAIL.Application.Interfaces;
using SHOPRURETAIL.Infrastructure.Persistence.Repository;
using SHOPRURETAIL.Application.Interfaces.Repositories;
using Infrastructure.Persistence.Repositories;

namespace SHOPRURETAIL.Extensions
{
    public static class ServiceExtensions
    {

        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region ApplicationConnection

            services.AddDbContext<ApplicationDbContext>(options =>
                     options.UseSqlite(
                         configuration.GetConnectionString("SQLITE"),
                         b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            #endregion

            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<ICustomerRepositoryAsync,CustomerRepositoryAsync>();
            services.AddTransient<IProductRepositoryAsync,ProductRepositoryAsync>();
            
        }
        public static void AddSwaggerExtension(this IServiceCollection services)
        {


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "SHOPRETAIL - Api",
                    Description = "This Api will be responsible for invoice management.",
                    Contact = new OpenApiContact
                    {
                        Name = "Olamide",
                        Email = "olamideonakoya@gmail.com"
                    }
                });
               
            });
        }
   

        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
