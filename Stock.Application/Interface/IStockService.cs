namespace Stock.Application.Interface;

public interface IStockService 
{
    Task UpdateStockAsync(Guid produtoId, int quantity);
}
