using CashFlow.Api.Filters;
using CashFlow.Application;
using CashFlow.Infrastructure;
using CashFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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

app.Run();