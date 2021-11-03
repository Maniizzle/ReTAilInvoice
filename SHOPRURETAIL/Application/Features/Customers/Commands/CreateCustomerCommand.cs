using SHOPRURETAIL.Application.Wrappers;
using AutoMapper;
using SHOPRURETAIL.Domain.Entities;
using MediatR;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using SHOPRURETAIL.Application.Requests;
using SHOPRURETAIL.Application.Interfaces;
using SHOPRURETAIL.Application.Exceptions;

namespace SHOPRURETAIL.Application.Features.Customers.Commands
{
    public partial class CreateCustomerCommand : CreateCustomerCommandRequest, IRequest<Response<long>>
    {
        
    }
    public class CreateProductCommandHandler : IRequestHandler<CreateCustomerCommand, Response<long>>
    {
        private readonly IGenericRepositoryAsync<Customer> _customerRepo;
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IGenericRepositoryAsync<Customer> customerRepo, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
        }

        public async Task<Response<long>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _customerRepo.GetByParameter(c => c.Email.ToLower().Trim() == request.Email.ToLower().Trim()).FirstOrDefault();
            if (customer is not null) throw new ApiException("duplicate email not allowed");

             customer = _mapper.Map<Customer>(request);
            await _customerRepo.AddAsync(customer);
            return new Response<long>(customer.CustomerId);
        }
    }
}
