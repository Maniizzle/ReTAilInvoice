using AutoMapper;
using MediatR;
using SHOPRURETAIL.Application.Exceptions;
using SHOPRURETAIL.Application.Interfaces;
using SHOPRURETAIL.Application.Requests;
using SHOPRURETAIL.Application.Wrappers;
using SHOPRURETAIL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SHOPRURETAIL.Application.Features.Discounts.Commands
{
    public class CreateDiscountCommand : CreateDiscountCommandRequest, IRequest<Response<long>>
    {

    }

    public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommand, Response<long>>
    {
        private readonly IGenericRepositoryAsync<DiscountType> _discountRepo;
        private readonly IMapper _mapper;
        public CreateDiscountCommandHandler(IGenericRepositoryAsync<DiscountType> discountRepo, IMapper mapper)
        {
            _discountRepo = discountRepo;
            _mapper = mapper;
        }

        public async Task<Response<long>> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            var discountType = _discountRepo.GetByParameter(c => c.Name.ToLower().Trim() == request.Name.ToLower().Trim()).FirstOrDefault();
            if (discountType is not null) throw new ApiException(" discount type already exist");

            if (request.CustomerTypeId == 0) request.CustomerTypeId = null;
            discountType = _mapper.Map<DiscountType>(request);
            await _discountRepo.AddAsync(discountType);
            return new Response<long>(discountType.Id);
        }
    }
}
