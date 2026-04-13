using Refit;

namespace Stock_API.ServicesHtttp;

public record NotaFiscalResponse(Guid Id, Guid ProductId, int Quantity, DateTime CreatedAt);
public interface INotaFiscalApi
{
    [Get("/api/NotaFiscal/{id}")]
    Task<NotaFiscalResponse> GetNotaFiscalByIdAsync(Guid id);
}
