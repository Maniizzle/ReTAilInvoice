using AutoMapper;
using MediatR;
using SHOPRURETAIL.Application.Exceptions;
using SHOPRURETAIL.Application.Features.Responses;
using SHOPRURETAIL.Application.Interfaces;
using SHOPRURETAIL.Application.Wrappers;
using SHOPRURETAIL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SHOPRURETAIL.Application.Features.Customers.Queries
{
    
    public class GetCustomerByIdQuery : IRequest<Response<GetCustomerQueryResponse>>
    {
        [Range(1,long.MaxValue)]
        public long Id { get; set; }
    }
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Response<GetCustomerQueryResponse>>
    {
        private readonly IGenericRepositoryAsync<Customer> _customerRepo;
        private readonly IMapper _mapper;
        public GetCustomerByIdQueryHandler(IGenericRepositoryAsync<Customer> customerRepo, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
        }

        public async Task<Response<GetCustomerQueryResponse>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
  
            var customer = await _customerRepo.GetByIdAsync(request.Id);
            if (customer == null) throw new ApiException("customer cannot be found");

            var customersModel = _mapper.Map<GetCustomerQueryResponse>(customer);
            return new Response<GetCustomerQueryResponse> {Succeeded=true, Data=customersModel };
        }
    }
}
