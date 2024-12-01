using Kab.DemirAjans.DataAccess.Categories;
using Kab.DemirAjans.DataAccess.DbAccess;
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
            .AddSingleton<ICategoryDal, CategoryDal>()

            .AddSingleton<ISqlDataAccess, SqlDataAccess>();
    }
}