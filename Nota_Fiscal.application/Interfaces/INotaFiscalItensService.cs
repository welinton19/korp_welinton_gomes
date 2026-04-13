using Nota_Fiscal.application.DTO.NotaFiscalItensDTOs;

namespace Nota_Fiscal.application.Interfaces;

public interface INotaFiscalItensService
{
    Task<NotaFiscalItensDTO> GetByIdAsync(Guid id);
        Task<IEnumerable<NotaFiscalItensDTO>> GetAllAsync();
        Task<NotaFiscalItensDTO> CreateAsync(NotaFiscalItensDTO item);
        Task UpdateAsync(Guid id, NotaFiscalItensDTO item);
        Task DeleteAsync(Guid id);
}
