using Microsoft.EntityFrameworkCore;
using Nota_Fiscal.Domain.Entities;
using Stock.Domain.Entities;

namespace Nota_Fiscal.Infrastructure.Data;

public class NotaFiscalDbContext : DbContext
{
    public NotaFiscalDbContext(DbContextOptions<NotaFiscalDbContext> options) : base(options) { }

    public DbSet<NotaFiscal> NotasFiscais { get; set; }
    public DbSet<NotaFiscalItem> NotaFiscalItens { get; set; }
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
    }
}
