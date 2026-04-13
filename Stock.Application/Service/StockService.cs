using System;
using System.Threading.Tasks;
using Stock.Application.Interface;
using Stock.Domain.Interface;

namespace Stock.Application.Service;

public class StockService : IStockService
{
    private readonly IStockPordutoRepository _stockPordutoRepository;

   

    public StockService(IStockPordutoRepository stockPordutoRepository)
    {
        _stockPordutoRepository = stockPordutoRepository;
    }

    public async Task UpdateStockAsync(Guid produtoId, int quantity)
    {
        await _stockPordutoRepository.UpdateBalanceAsync(produtoId, quantity);
    }
}
