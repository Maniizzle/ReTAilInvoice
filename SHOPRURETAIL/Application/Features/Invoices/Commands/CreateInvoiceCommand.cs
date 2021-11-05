using MediatR;
using SHOPRURETAIL.Application.Exceptions;
using SHOPRURETAIL.Application.Features.Requests;
using SHOPRURETAIL.Application.Interfaces;
using SHOPRURETAIL.Application.Interfaces.Repositories;
using SHOPRURETAIL.Application.Interfaces.Services;
using SHOPRURETAIL.Application.Wrappers;
using SHOPRURETAIL.Domain.Entities;
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
        private readonly ICustomerRepositoryAsync _customerRepo;
        private readonly IDiscountService _discountService;
        public CreateInvoiceCommandHandler(IDiscountService discountService,ICustomerRepositoryAsync customerRepo, IProductRepositoryAsync productRepo,IGenericRepositoryAsync<Invoice> invoiceRepo)
        {
            _discountService = discountService;
            _productRepo = productRepo;
            _invoiceRepo = invoiceRepo;
            _customerRepo = customerRepo;
        }

        public async Task<Response<decimal>> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {

            var customer= await _customerRepo.GetCustomer(request.CustomerId);
            if (customer is null) throw new KeyNotFoundException("user not  found");

            //make sure all the products exist
            var productIds =request.InvoiceItems.Select(c => c.ProductId);
             var products= (await _productRepo.GetProducts(productIds)).ToList();
            if (!(request.InvoiceItems.Count == products.Count)) throw new ApiException("Some products dont exist");

            var invoiceItems = new List<InvoiceItem>();
            foreach (var item in request.InvoiceItems)
            {
                var product = products.FirstOrDefault(c => item.ProductId == c.Id);
                var InvoiceItem=new InvoiceItem()
                {

                    ProductId = item.ProductId,
                    ProductName = product.Name,
                    ProductQuantity = item.ProductQuantity,
                    ProductUnitPrice = product.UnitPrice,
                     TotalCost= item.ProductQuantity* product.UnitPrice,
                     ProduuctCategory=product.Category

                };
                invoiceItems.Add(InvoiceItem);
            }
            var invoice = new Invoice
            {
                CustomerId = customer.CustomerId,
                InvoiceItems = invoiceItems,
                SubTotalCost = invoiceItems.Sum(c => c.TotalCost)
            };

            invoice.TotalDiscount = await _discountService.GenerateDiscount(invoice);
            invoice.TotalCost = invoice.SubTotalCost- invoice.TotalDiscount;
            await _invoiceRepo.AddAsync(invoice);
            return new Response<decimal>(invoice.TotalCost);
        }

    }
}
