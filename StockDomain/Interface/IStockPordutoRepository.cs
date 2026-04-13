using Stock.Domain.Entities;

namespace Stock.Domain.Interface;

public interface IStockPordutoRepository
{
    Task<StockProduto> DeductBalanceAsync(Guid produtoId, int quantity);


    Task<StockProduto> UpdateBalanceAsync(Guid produtoId, int quantity);
}
