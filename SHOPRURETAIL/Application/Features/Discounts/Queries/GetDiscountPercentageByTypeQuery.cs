using MediatR;
using SHOPRURETAIL.Application.Interfaces;
using SHOPRURETAIL.Application.Wrappers;
using SHOPRURETAIL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SHOPRURETAIL.Application.Features.Discounts.Queries
{
    public class GetDiscountPercentageByTypeQuery: IRequest<Response<decimal>>
    {
        public string Type { get; set; }
    }

    public class GetDiscountPercentageByTypeQueryHandler : IRequestHandler<GetDiscountPercentageByTypeQuery, Response<decimal>>
    {
        private readonly IGenericRepositoryAsync<DiscountType> _discountRepo;

        public GetDiscountPercentageByTypeQueryHandler(IGenericRepositoryAsync<DiscountType> discountRepo)
        {
            _discountRepo = discountRepo;
        }

        public Task<Response<decimal>> Handle(GetDiscountPercentageByTypeQuery request, CancellationToken cancellationToken)
        {

            var discount = _discountRepo.GetByParameter(c => c.Name.ToLower().Contains(request.Type.ToLower().Trim()) && c.IsPercentage==true).FirstOrDefault();
            if (discount == null) throw new KeyNotFoundException("discount type cannot be found");

            return Task.FromResult(new Response<decimal>{ Succeeded = true, Data =discount.Value});
        }
    }
}
