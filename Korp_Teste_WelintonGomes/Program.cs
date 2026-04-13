using Microsoft.OpenApi.Models;
using Refit;
using Stock.Infraestructure.Injection;
using Stock_API.ServicesHtttp;
using Microsoft.EntityFrameworkCore;
using Stock.Infraestructure.Data; // ← ajusta para o namespace do seu DbContext

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Stock API",
        Description = "API para Gerenciamento de Estoque",
        Contact = new OpenApiContact
        {
            Name = "Welinton Gomes",
            Email = "batistawelinton54@gmail.com"
        }
    });
});

builder.Services.AddCors(options => 
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddInfrastructure(builder.Configuration);

string apiUris = builder.Configuration["ApiSettings:Uri"] ?? throw new InvalidOperationException("ApiSettings:Uri não está configurado");

builder.Services.AddRefitClient<INotaFiscalApi>()
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri(apiUris);
    });

var app = builder.Build();

// ✅ Aplica migrations automaticamente
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<StockDbContext>();
    db.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Stock API v1");
    c.RoutePrefix = "swagger";
});

app.UseCors();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();