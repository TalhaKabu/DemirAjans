using AutoMapper;
using Kab.DemirAjans.Domain.Categories;
using Kab.DemirAjans.Domain.SubCategories;
using Kab.DemirAjans.Entities.Categories;
using Kab.DemirAjans.Entities.SubCategories;
using System;
namespace Kab.DemirAjans.Business.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile() 
    {
        CreateMap<Category, CategoryDto>();

        CreateMap<SubCategory, SubCategoryDto>();
    }
}