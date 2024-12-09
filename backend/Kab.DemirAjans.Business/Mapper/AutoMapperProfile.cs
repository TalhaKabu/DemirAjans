using AutoMapper;
using Kab.DemirAjans.Domain.Activations;
using Kab.DemirAjans.Domain.Categories;
using Kab.DemirAjans.Domain.Colors;
using Kab.DemirAjans.Domain.Products;
using Kab.DemirAjans.Domain.SubCategories;
using Kab.DemirAjans.Domain.Users;
using Kab.DemirAjans.Entities.Activations;
using Kab.DemirAjans.Entities.Categories;
using Kab.DemirAjans.Entities.Colors;
using Kab.DemirAjans.Entities.Products;
using Kab.DemirAjans.Entities.SubCategories;
using Kab.DemirAjans.Entities.Users;
using System;

namespace Kab.DemirAjans.Business.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Category, CategoryDto>();

        CreateMap<SubCategory, SubCategoryDto>();

        CreateMap<Product, ProductDto>();

        CreateMap<User, UserDto>();

        CreateMap<Activation, ActivationDto>();

        CreateMap<Color, ColorDto>();
    }
}