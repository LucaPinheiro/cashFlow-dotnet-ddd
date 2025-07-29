using CashFlow.Api.Filters;
using CashFlow.Application;
using CashFlow.Infrastructure;
using CashFlow.Infrastructure.Data;
using CashFlow.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;

var builder = WebApplication.CreateBuilder(args);

// ====================
// Serviços do Framework
// ====================
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

// ====================
// Injeção de Dependências da Solução
// ====================
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

// ====================
// Pipeline da Aplicação
// ====================
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

await MigrateDatabase();

app.Run();

async Task MigrateDatabase()
{
    await using var scope = app.Services.CreateAsyncScope();

    await DatabaseMigration.MigrateDatabase(scope.ServiceProvider);
}