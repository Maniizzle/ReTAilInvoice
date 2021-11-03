using SHOPRURETAIL.Application.Interfaces;
using SHOPRURETAIL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SHOPRURETAIL.Application.Interfaces.Repositories
{
    public interface IProductRepositoryAsync : IGenericRepositoryAsync<Product>
    {
        public Task<IEnumerable<Product>> GetProducts(IEnumerable<long> Ids);
    }
}
