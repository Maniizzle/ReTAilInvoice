using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SHOPRURETAIL.Infrastructure.Persistence.Repository;
using SHOPRURETAIL.Domain.Entities;
using SHOPRURETAIL.Infrastructure.Contexts;
using SHOPRURETAIL.Application.Interfaces.Repositories;

namespace Infrastructure.Persistence.Repositories
{
    public class ProductRepositoryAsync : GenericRepositoryAsync<Product>, IProductRepositoryAsync
    {
        private readonly DbSet<Product> _products;

        public ProductRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _products = dbContext.Set<Product>();
        }

        public Task<IEnumerable<Product>> GetProducts(IEnumerable<long> Ids)
        {
            return Task.FromResult( _products.Where(c => Ids.Contains(c.Id)).AsEnumerable());
        }
    }
}
