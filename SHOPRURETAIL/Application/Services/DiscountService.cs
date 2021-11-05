using SHOPRURETAIL.Application.Interfaces;
using SHOPRURETAIL.Application.Interfaces.Services;
using SHOPRURETAIL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHOPRURETAIL.Application.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IGenericRepositoryAsync<DiscountType> _discountRepo;

        public DiscountService(IGenericRepositoryAsync<DiscountType> discountRepo)
        {
            _discountRepo = discountRepo;
        }
        public async Task<decimal> GenerateDiscount(Invoice invoice)
        {
            var discounts= await _discountRepo.GetAllAsync();
            var percentageDiscounts = discounts.Where(c => c.IsPercentage);
            var percentDiscount=CalculatePercentageDiscount(percentageDiscounts,  invoice);
            var dollardiscount =CalculateDollarBIllDiscount(discounts, invoice);
            return dollardiscount + percentDiscount;
        }

        private decimal CalculatePercentageDiscount(IEnumerable<DiscountType> discounts, Invoice invoice)
        {
            decimal discountedValue = 0;
            decimal subtotalWithoutGroceries = invoice.SubTotalCost - invoice.InvoiceItems.Where(c => c.ProduuctCategory == Category.Groceries).Sum(c => c.TotalCost);

            var discount=discounts.FirstOrDefault(c => c.CustomerTypeId == invoice.Customer.CustomerTypeId  &&  invoice.Customer.CustomerType.Name!=Constants.Constants.DefaultCustomerType);
            if(discount is null)
            {
                if(invoice.Customer.CustomerType.Name== Constants.Constants.DefaultCustomerType)
                {
                    var defaultDiscount = discounts.FirstOrDefault(c => c.CustomerTypeId == invoice.Customer.CustomerTypeId);
                    if(defaultDiscount is not null && DateTime.Today > invoice.Customer.DateCreated.AddYears(2))
                    {
                        discountedValue = subtotalWithoutGroceries * (defaultDiscount.Value / 100);
                        invoice.DiscountRates += $",{defaultDiscount.Value}";
                        invoice.DiscountTypes += $",{defaultDiscount.Name}";
                        return discountedValue;
                    }
                }
            }
            invoice.DiscountRates += $",{discount.Value}";
            invoice.DiscountTypes += $",{discount.Name}";
            return discountedValue = subtotalWithoutGroceries * (discount.Value / 100);
        }

        private decimal CalculateDollarBIllDiscount(IEnumerable<DiscountType> discounts, Invoice invoice)
        {
           var dollardiscountype= discounts.FirstOrDefault(c => c.Name == Constants.Constants.DollarDiscountType);
            var dollardiscountMax = Math.Floor(invoice.SubTotalCost / 100);
            if (dollardiscountype != null)
            {
                invoice.DiscountTypes += $",{dollardiscountype.Name}";
                invoice.DiscountRates = $",{dollardiscountype.Value}";
                return dollardiscountMax * dollardiscountype.Value;
            }
            return default;
        }

    }
}
