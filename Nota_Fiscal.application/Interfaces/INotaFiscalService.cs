using Nota_Fiscal.application.DTO.NotaFiscalDTO.NotaFiscalDTO;
using Nota_Fiscal.application.DTO.NotaFiscalDTOs;

namespace Nota_Fiscal.application.Interfaces;

public interface INotaFiscalService
{
    Task <NotaFiscalDTO> CreateNotaFiscalAsync(CreateNotaFiscalDTO createNotaFiscalDTO);
    Task<NotaFiscalDTO> UpdateNotaFiscalAsync(UpdateNotaFiscalDTO updateNotaFiscalDTO);
    Task <NotaFiscalDTO> GetNotaFiscalByIdAsync(Guid id);
    Task <NotaFiscalDTO> ImprimirNotaFiscalAsync(Guid id);
    Task<List<NotaFiscalDTO>> GetNotasFiscaisAsync();
    Task<NotaFiscalDTO> DeleteNotaFiscalAsync(DeleteNotaFiscalDTO deleteNotaFiscalDTO);
}
