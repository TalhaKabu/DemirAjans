using Kab.DemirAjans.Business.Auth;
using Kab.DemirAjans.Business.Categories;
using Kab.DemirAjans.Business.Images;
using Kab.DemirAjans.Business.Products;
using Kab.DemirAjans.Business.SubCategories;
using Kab.DemirAjans.Business.Token;
using Kab.DemirAjans.Business.Users;
using Kab.DemirAjans.DataAccess.Auth;
using Kab.DemirAjans.DataAccess.Categories;
using Kab.DemirAjans.DataAccess.DbAccess;
using Kab.DemirAjans.DataAccess.Images;
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
            .AddSingleton<IAuthService, AuthManager>()
            .AddSingleton<IAuthDal, AuthDal>()

            .AddSingleton<IUserService, UserManager>()
            .AddSingleton<IUserDal, UserDal>()

            .AddSingleton<IImageService, ImageManager>()
            .AddSingleton<IImageDal, ImageDal>()

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