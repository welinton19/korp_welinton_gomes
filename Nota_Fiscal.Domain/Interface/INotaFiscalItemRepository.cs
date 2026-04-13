using Nota_Fiscal.Domain.Entities;

namespace Nota_Fiscal.Domain.Interface;

public interface INotaFiscalItemRepository
{
    Task<NotaFiscalItem> GetByIdAsync(Guid id);
    Task<IEnumerable<NotaFiscalItem>> GetAllAsync();
    Task<NotaFiscalItem> AddAsync(NotaFiscalItem notaFiscalItem);
    Task<NotaFiscalItem> UpdateAsync(NotaFiscalItem notaFiscalItem);
    Task DeleteAsync(Guid id);
}
