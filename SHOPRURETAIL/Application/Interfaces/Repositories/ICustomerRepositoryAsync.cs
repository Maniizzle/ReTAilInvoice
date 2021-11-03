using SHOPRURETAIL.Application.Interfaces;
using SHOPRURETAIL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SHOPRURETAIL.Application.Interfaces.Repositories
{
    public interface ICustomerRepositoryAsync : IGenericRepositoryAsync<Customer>
    {
        public Task<Customer> GetCustomer(long id);
    }
}
