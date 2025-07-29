using CashFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure.Migrations;

public class DatabaseMigration
{
    public async static Task MigrateDatabase(IServiceProvider provider)
    { 
        var dbContext = provider.GetRequiredService<CashFlowDbContext>();
        await dbContext.Database.MigrateAsync();
    }
}