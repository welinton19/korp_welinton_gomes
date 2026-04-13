using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stock.Application.Interface;
using Stock.Application.Service;
using Stock.Domain.Interface;
using Stock.Infraestructure.Data;
using Stock.Infraestructure.HttpService;
using Stock.Infraestructure.Repositories;
using Stock_API.ServicesHtttp;

namespace Stock.Infraestructure.Injection;

public static class DepedencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<Data.StockDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("StockConnection"),
               (b => b.MigrationsAssembly(typeof(StockDbContext).Assembly.FullName)));
        });


        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IStockPordutoRepository, StockRepository>();

        services.AddScoped<IProdutoService, ProdutoService>();
        services.AddScoped<IStockService, StockService>();

        services.AddScoped<INotaFiscalApi, NotaFiscalServiceHttp>();

        return services;
    }
}
