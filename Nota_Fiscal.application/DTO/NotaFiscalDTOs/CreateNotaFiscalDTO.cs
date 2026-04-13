using Nota_Fiscal.Domain.Entities;
using Nota_Fiscal.Domain.Enum;

namespace Nota_Fiscal.application.DTO.NotaFiscalDTO.NotaFiscalDTO;

public class CreateNotaFiscalDTO
{
    
    public string? Number { get; set; }
    public DateTime IssueDate { get; set; }
    public string? ClientName { get; set; }
    public decimal TotalValue { get; set; }
    public string? IssuerCnpj { get; set; }
    public string? RecipientCnpj { get; set; }
   
    public StatusNota Status { get; set; }
}
