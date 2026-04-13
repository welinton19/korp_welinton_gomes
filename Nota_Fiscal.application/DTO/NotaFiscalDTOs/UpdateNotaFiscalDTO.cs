using Nota_Fiscal.Domain.Enum;

namespace Nota_Fiscal.application.DTO.NotaFiscalDTOs;

public class UpdateNotaFiscalDTO
{
    public Guid Id { get; set; }
    public string? Number { get; set; }
    public DateTime IssueDate { get; set; }
    public string? ClientName { get; set; }
    public decimal TotalValue { get; set; }
    public string? IssuerCnpj { get; set; }
    public string? RecipientCnpj { get; set; }

    public StatusNota Status { get; set; }
}
