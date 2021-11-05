using SHOPRURETAIL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHOPRURETAIL.Application.Interfaces.Services
{
   public interface IDiscountService
    {
        public Task<decimal> GenerateDiscount(Invoice invoice);
    }
}
