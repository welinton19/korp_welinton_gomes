using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nota_Fiscal.Domain.Interface;
using Nota_Fiscal.Infrastructure.Data;
using Nota_Fiscal.Infrastructure.Repositories;

namespace Nota_Fiscal.Infrastructure.Injection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddDbContext<NotaFiscalDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("NotaFiscalConnection"),
               (b => b.MigrationsAssembly(typeof(NotaFiscalDbContext).Assembly.FullName)));
        });

        services.AddScoped<INotaFiscalRepository, NotaFiscalRepository>();
        services.AddScoped<INotaFiscalItemRepository, NotaFiscalItensRepository>();

        return services;
    }
}
