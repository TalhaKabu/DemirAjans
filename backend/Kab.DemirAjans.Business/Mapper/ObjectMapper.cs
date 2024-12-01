using AutoMapper;
using System;

namespace Kab.DemirAjans.Business.Mapper;

public static class ObjectMapper
{
    private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AutoMapperProfile>();
        });
        return config.CreateMapper();
    });

    public static IMapper Mapper => Lazy.Value;
}