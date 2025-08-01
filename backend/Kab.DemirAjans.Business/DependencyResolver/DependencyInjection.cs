﻿using Kab.DemirAjans.Business.Activations;
using Kab.DemirAjans.Business.Auth;
using Kab.DemirAjans.Business.Carts;
using Kab.DemirAjans.Business.Categories;
using Kab.DemirAjans.Business.Colors;
using Kab.DemirAjans.Business.Products;
using Kab.DemirAjans.Business.SubCategories;
using Kab.DemirAjans.Business.Token;
using Kab.DemirAjans.Business.Users;
using Kab.DemirAjans.DataAccess.Activations;
using Kab.DemirAjans.DataAccess.Auth;
using Kab.DemirAjans.DataAccess.Carts;
using Kab.DemirAjans.DataAccess.Categories;
using Kab.DemirAjans.DataAccess.Colors;
using Kab.DemirAjans.DataAccess.DbAccess;
using Kab.DemirAjans.DataAccess.Products;
using Kab.DemirAjans.DataAccess.SubCategories;
using Kab.DemirAjans.DataAccess.Users;
using Kab.DemirAjans.EntityFrameworkCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Kab.DemirAjans.Business.DependencyResolver;

public static class DependencyInjection
{
    public static void Resolve(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<KabDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Default"));
        });

        services
            .AddSingleton<ICartService, CartManager>()
            .AddSingleton<ICartDal, CartDal>()

            .AddSingleton<IColorService, ColorManager>()
            .AddSingleton<IColorDal, ColorDal>()

            .AddSingleton<IActivationService, ActivationManager>()
            .AddSingleton<IActivationDal, ActivationDal>()

            .AddSingleton<IAuthService, AuthManager>()
            .AddSingleton<IAuthDal, AuthDal>()

            .AddSingleton<IUserService, UserManager>()
            .AddSingleton<IUserDal, UserDal>()

            .AddSingleton<IProductService, ProductManager>()
            .AddSingleton<IProductDal, ProductDal>()

            .AddSingleton<ISubCategoryService, SubCategoryManager>()
            .AddSingleton<ISubCategoryDal, SubCategoryDal>()

            .AddSingleton<ICategoryService, CategoryManager>()
            .AddSingleton<ICategoryDal, CategoryDal>()

            .AddSingleton<ITokenService, TokenManager>()

            .AddSingleton<ISqlDataAccess, SqlDataAccess>();
    }
}