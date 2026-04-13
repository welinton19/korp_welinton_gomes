using Nota_Fiscal.application.Interfaces;
using Nota_Fiscal.application.Services;
using Nota_Fiscal.Domain.Interface;
using Nota_Fiscal.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);



//injection dependency
builder.Services.AddScoped<INotaFiscalRepository, NotaFiscalRepository>();
builder.Services.AddScoped<INotaFiscalItemRepository, NotaFiscalItemRepository>();

builder.Services.AddScoped<INotaFiscalService, NotaFiscalService>();
builder.Services.AddScoped<INotaFiscalItensService, NotaFiscalItensService>();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();



app.Run();


