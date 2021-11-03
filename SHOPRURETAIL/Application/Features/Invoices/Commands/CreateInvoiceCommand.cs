using AutoMapper;
using MediatR;
using SHOPRURETAIL.Application.Exceptions;
using SHOPRURETAIL.Application.Features.Requests;
using SHOPRURETAIL.Application.Interfaces;
using SHOPRURETAIL.Application.Interfaces.Repositories;
using SHOPRURETAIL.Application.Wrappers;
using SHOPRURETAIL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SHOPRURETAIL.Application.Features.Invoices.Commands
{
    public class CreateInvoiceCommand: CreateInvoiceCommandRequest, IRequest<Response<decimal>>
    {

    }

    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, Response<decimal>>
    {
        private readonly IGenericRepositoryAsync<Invoice> _invoiceRepo;
        private readonly IProductRepositoryAsync _productRepo;
        private readonly IGenericRepositoryAsync<DiscountType> _discountType;
        private readonly ICustomerRepositoryAsync _customerRepo;
        private readonly IGenericRepositoryAsync<InvoiceDetail> _invoiceDetailsRepo;
        private readonly IMapper _mapper;
        public CreateInvoiceCommandHandler(IGenericRepositoryAsync<DiscountType> discountType,ICustomerRepositoryAsync customerRepo, IProductRepositoryAsync productRepo, IGenericRepositoryAsync<InvoiceDetail> invoiceDetailsRepo,IGenericRepositoryAsync<Invoice> invoiceRepo, IMapper mapper)
        {
            _discountType = discountType;
            _productRepo = productRepo;
            _invoiceDetailsRepo = invoiceDetailsRepo;
            _invoiceRepo = invoiceRepo;
            _customerRepo = customerRepo;
            _mapper = mapper;
        }

        public async Task<Response<decimal>> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {

            var customer= await _customerRepo.GetCustomer(request.CustomerId);
            if (customer is null) throw new KeyNotFoundException("user not  found");

            //make sure all the products exist
            var productIds =request.InvoiceDetails.Select(c => c.ProductId);
             var products= (await _productRepo.GetProducts(productIds)).ToList();
            if (!(request.InvoiceDetails.Count == products.Count)) throw new ApiException("Some products dont exist");

            var invoiceDetails = new List<InvoiceDetail>();
            foreach (var item in request.InvoiceDetails)
            {
                var product = products.FirstOrDefault(c => item.ProductId == c.Id);
                var detail=new InvoiceDetail()
                {

                    ProductId = item.ProductId,
                    ProductName = product.Name,
                    ProductQuantity = item.ProductQuantity,
                    ProductUnitPrice = product.UnitPrice,
                     TotalDerivedCost= item.ProductQuantity* product.UnitPrice

                };
                invoiceDetails.Add(detail);
            }
            var invoice = new Invoice
            {
                CustomerId = customer.CustomerId,
                InvoiceDetails = invoiceDetails,
                SubTotalCost = invoiceDetails.Sum(c => c.TotalDerivedCost)
            };

            //Refactor discount calculator to use Strategy Design pattern
            //add check for groceries
            var discounts=await _discountType.GetAllAsync();
            decimal dollardiscount = 0;
            decimal userdiscountValue = 0;
            foreach (var discount in discounts)
            {
                if (discount.Equals(customer.CustomerType.Name) && discount.IsPercentage)
                {
                     userdiscountValue = invoice.SubTotalCost * (discount.Value / 100);
                    invoice.DiscountTypes = discount.Name;
                    invoice.DiscountRates = discount.Value.ToString();
                }
            }
            if (invoice.SubTotalCost >= 100)
            {
                //move the hardcode to appsettings
                var dollardiscountMax = Math.Floor(invoice.SubTotalCost / 100);
                var discountType= discounts.FirstOrDefault(c => c.Name == "100DollarBill");
                if (discountType != null)
                {
                    dollardiscount = dollardiscountMax * discountType.Value;
                    invoice.DiscountTypes += $",{discountType.Name}" ;
                    invoice.DiscountRates = $",{discountType.Value}";

                }
            }
            invoice.TotalCost = invoice.SubTotalCost- dollardiscount + userdiscountValue;
            invoice.TotalDiscount= dollardiscount + userdiscountValue;
            await _invoiceRepo.AddAsync(invoice);
            return new Response<decimal>(invoice.InvoiceId);
        }

    }
}
