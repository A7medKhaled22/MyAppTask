using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MyAppTask.DAL;

namespace MyAppTask.Services;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(dto => dto.TotalValue, opt => opt.MapFrom(src => src.Price * src.Quantity))
            .ReverseMap().ForSourceMember(dto => dto.TotalValue, opt => opt.DoNotValidate())
            .ForSourceMember(dto => dto.Id, opt => opt.DoNotValidate());

        CreateMap<ProductAddDto, Product>();
    }
}