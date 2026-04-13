using Nota_Fiscal.application.Interfaces;
using Nota_Fiscal.application.Services;
using Nota_Fiscal.Infrastructure.Injection;
using Nota_Fiscal.Infrastructure.Data; 
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Refit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Nota Fiscal API",
        Description = "API para Gerenciamento de Nota Fiscal",
        Contact = new OpenApiContact
        {
            Name = "Welinton Gomes",
            Email = "batistawelinton54@gmail.com"
        }
    });
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddScoped<INotaFiscalService, NotaFiscalService>();
builder.Services.AddScoped<INotaFiscalItensService, NotaFiscalItensService>();

string apiUris = builder.Configuration["ApiSettings:Uri"] ?? throw new InvalidOperationException("ApiSettings:Uri não está configurado");

builder.Services.AddRefitClient<IStockApi>()
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri(apiUris);
    });

var app = builder.Build();

// ✅ Aplica migrations automaticamente
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<NotaFiscalDbContext>();
    db.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nota Fiscal API v1");
    c.RoutePrefix = "swagger";
});

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();