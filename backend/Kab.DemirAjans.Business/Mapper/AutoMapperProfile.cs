using AutoMapper;
using Kab.DemirAjans.Domain.Categories;
using Kab.DemirAjans.Entities.Categories;
using System;
namespace Kab.DemirAjans.Business.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile() 
    {
        CreateMap<CategoryDto, Category>().ReverseMap();
    }
}