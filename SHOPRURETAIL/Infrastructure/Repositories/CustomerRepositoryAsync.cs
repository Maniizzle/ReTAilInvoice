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
    public class CustomerRepositoryAsync : GenericRepositoryAsync<Customer>, ICustomerRepositoryAsync
    {
        private readonly DbSet<Customer> _customers;

        public CustomerRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _customers = dbContext.Set<Customer>();
        }

        public Task<Customer> GetCustomer(long id)
        {
           return  _customers.Include(c => c.CustomerType).FirstOrDefaultAsync(c=>c.CustomerId==id);
        }

        public async Task<Customer> GetCustomerByEmail(string email)
        {
          return await _customers.FirstOrDefaultAsync(c => c.Email.Trim().ToLower() == email.ToLower().Trim());
        }
    }
}
