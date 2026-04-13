using Nota_Fiscal.Domain.Entities;

namespace Nota_Fiscal.Domain.Interface;

public interface INotaFiscalRepository
{
    Task<NotaFiscal> GetByIdAsync(Guid id);
    Task<IEnumerable<NotaFiscal>> GetAllAsync();
    Task<NotaFiscal> AddAsync(NotaFiscal notaFiscal);
    Task<NotaFiscal> UpdateAsync(NotaFiscal notaFiscal);
    Task DeleteAsync(Guid id);
    Task DeduzirEstoque(Guid produtoId, int quantity);
}
