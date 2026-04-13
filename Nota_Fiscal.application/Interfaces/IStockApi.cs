using Refit;

namespace Nota_Fiscal.application.Interfaces;

public record ProdutoResponse(Guid Id, string code);
public record StockRespose(Guid ProdutoId, int Balance);
public interface IStockApi
{
    [Get("/api/produto/{Id}")]
    Task<ProdutoResponse> GetById(Guid Id);

    [Get("/api/stock/{ProdutoId}/{Quantity}")]
    Task<StockRespose> GetById(Guid ProdutoId, int Quantity);
}
