using Microsoft.EntityFrameworkCore;

namespace Stock.Infraestructure.Data;

public class StockDbContext : DbContext
{
    public StockDbContext(DbContextOptions<StockDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Entities.Produto> Produtos { get; set; }
    public DbSet<Domain.Entities.StockProduto> StockProdutos { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StockDbContext).Assembly);
    }

}
