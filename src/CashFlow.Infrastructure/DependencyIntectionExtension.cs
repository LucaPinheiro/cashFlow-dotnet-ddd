using CashFlow.Domain.Repositories;
using CashFlow.Infrastructure.Data;
using CashFlow.Infrastructure.Data.Repositories;
using CashFlow.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);

        services.AddScoped<IPasswordEncripter, Infrastructure.Security.BCrypter>();
    }

    public static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IExpensesRepository, ExpensesRepository>();
        services.AddScoped<IUserReadOnlyRepositories, UserRepository>();
    }
    
    public static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CashFlowDbContext>(options =>
            options.UseMySql(
                configuration.GetConnectionString("DefaultConnection"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection"))
            )
        );
    }
}