using SHOPRURETAIL.Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SHOPRURETAIL.Domain.Entities;
using SHOPRURETAIL.Application.Interfaces;
using SHOPRURETAIL.Application.Features.Responses;

namespace SHOPRURETAIL.Application.Features.Customers.Queries
{
    public class GetAllCustomersQuery : IRequest<PagedResponse<IEnumerable<GetCustomerQueryResponse>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllCustomersQuery, PagedResponse<IEnumerable<GetCustomerQueryResponse>>>
    {
        private readonly IGenericRepositoryAsync<Customer> _customerRepo;
        private readonly IMapper _mapper;
        public GetAllProductsQueryHandler(IGenericRepositoryAsync<Customer> customerRepo, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetCustomerQueryResponse>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var pageNumber = request.PageNumber < 1 ? 1 : request.PageNumber;
            var pageSize = request.PageSize < 10 ? 50 : request.PageSize;
            var customers = await _customerRepo.GetPagedReponseAsync(pageNumber, pageSize);
            var customersModel = _mapper.Map<IEnumerable<GetCustomerQueryResponse>>(customers);
            return new PagedResponse<IEnumerable<GetCustomerQueryResponse>>(customersModel, pageNumber,pageNumber);           
        }
    }
}
