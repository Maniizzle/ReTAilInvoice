using AutoMapper;
using MediatR;
using SHOPRURETAIL.Application.Features.Responses;
using SHOPRURETAIL.Application.Interfaces;
using SHOPRURETAIL.Application.Wrappers;
using SHOPRURETAIL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SHOPRURETAIL.Application.Features.Discounts.Queries
{
    public class GetAllDiscountQuery : IRequest<PagedResponse<IEnumerable<GetDiscountQueryResponse>>>

    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }

    public class GetAllDiscountQueryHandler : IRequestHandler<GetAllDiscountQuery, PagedResponse<IEnumerable<GetDiscountQueryResponse>>>
    {
        private readonly IGenericRepositoryAsync<DiscountType> _discountRepo;
        private readonly IMapper _mapper;
        public GetAllDiscountQueryHandler(IGenericRepositoryAsync<DiscountType> discountRepo, IMapper mapper)
        {
            _discountRepo = discountRepo;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetDiscountQueryResponse>>> Handle(GetAllDiscountQuery request, CancellationToken cancellationToken)
        {
            var pageNumber = request.PageNumber < 1 ? 1 : request.PageNumber;
            var pageSize = request.PageSize < 10 ? 50 : request.PageSize;
            var discounts = await _discountRepo.GetPagedReponseAsync(pageNumber, pageSize);
            var discountsResponse = _mapper.Map<IEnumerable<GetDiscountQueryResponse>>(discounts);
            return new PagedResponse<IEnumerable<GetDiscountQueryResponse>>(discountsResponse, pageNumber, pageNumber);
        }
    }
}
