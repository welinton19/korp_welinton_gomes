using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Stock.Infraestructure.Data;

namespace Stock.Infraestructure.Factory;

public class StockDbContextFactory : IDesignTimeDbContextFactory<StockDbContext>
{
    public StockDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<StockDbContext>();

        var connectionstring = "Host= localhost;Port = 5432;Database= Stock;Username = postgres;Password = 25bbg20lk@W";

        optionsBuilder.UseNpgsql(connectionstring);

        return new StockDbContext(optionsBuilder.Options);
    }
}
