using AutoMapper;
using SHOPRURETAIL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using SHOPRURETAIL.Application.Requests;
using SHOPRURETAIL.Application.Features.Responses;

namespace SHOPRURETAIL.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Customer, CreateCustomerCommandRequest>().ReverseMap();
            CreateMap<Customer, GetCustomerQueryResponse>().ReverseMap();
            CreateMap<DiscountType, CreateDiscountCommandRequest>().ReverseMap();
            CreateMap<DiscountType, GetDiscountQueryResponse>().ForMember(dest=> dest.Type, opt=>opt.MapFrom(c=>c.Name)).ReverseMap();
        }
    }
}
