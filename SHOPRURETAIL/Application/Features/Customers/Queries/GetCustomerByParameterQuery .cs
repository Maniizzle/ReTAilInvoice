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
    
    public class GetCustomerByParameterQuery : IRequest<Response<IEnumerable<GetCustomerQueryResponse>>>
    {
        [Required]
        [StringLength(100,MinimumLength =2)]
        public string Name { get; set; }
    }
    public class GetCustomerByParameterQueryHandler : IRequestHandler<GetCustomerByParameterQuery, Response<IEnumerable<GetCustomerQueryResponse>>>
    {
        private readonly IGenericRepositoryAsync<Customer> _customerRepo;
        private readonly IMapper _mapper;
        public GetCustomerByParameterQueryHandler(IGenericRepositoryAsync<Customer> customerRepo, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
        }

        public Task<Response<IEnumerable<GetCustomerQueryResponse>>> Handle(GetCustomerByParameterQuery request, CancellationToken cancellationToken)
        {
  
            var customers =  _customerRepo.GetByParameter(c=>c.FirstName.ToLower().Contains(request.Name.ToLower()) || c.LastName.ToLower().Contains(request.Name.ToLower()));
            if (customers == null) throw new ApiException("customer cannot be found");

            var customersModel = _mapper.Map<IEnumerable<GetCustomerQueryResponse>>(customers);
            return Task.FromResult(new Response<IEnumerable<GetCustomerQueryResponse>> {Succeeded=true, Data=customersModel });
        }
    }
}
