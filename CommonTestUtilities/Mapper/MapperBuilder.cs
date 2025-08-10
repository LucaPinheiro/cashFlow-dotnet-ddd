using AutoMapper;
using CashFlow.Application.AutoMapper;
using Microsoft.Extensions.Logging;

namespace CommonTestUtilities.Mapper;

public static class MapperBuilder
{
    private static readonly ILoggerFactory _loggerFactory =
        LoggerFactory.Create(_ => { });

    public static IMapper Build()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AutoMapping());
        }, _loggerFactory);

        return config.CreateMapper();
    }
}