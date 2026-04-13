using Stock.Domain.Entities;
using Stock.Domain.Interface;
using Stock.Infraestructure.Data;

namespace Stock.Infraestructure.Repositories;

public class StockRepository : IStockPordutoRepository
{
    private readonly StockDbContext _context;

    public StockRepository(StockDbContext context)
    {
        _context = context;
    }



    public Task<StockProduto> DeductBalanceAsync(Guid produtoId, int quantity)
    {
        _context.AddAsync(produtoId);
        _context.AddAsync(quantity);
        _context.SaveChanges();
        return Task.FromResult(StockProduto.Success());
    }



    public async Task<StockProduto> UpdateBalanceAsync(Guid produtoId, int quantity)
    {
        var produto = await _context.Produtos.FindAsync(produtoId);

        if (produto == null)
            return StockProduto.Failure("Produto não encontrado");

        produto.Balance += quantity;

        await _context.SaveChangesAsync();

        return StockProduto.Success();
    }
}
