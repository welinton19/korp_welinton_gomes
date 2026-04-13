using Nota_Fiscal.Domain.Entities;
using Nota_Fiscal.Domain.Enum;

namespace Nota_Fiscal.application.DTO.NotaFiscalDTOs;

public class NotaFiscalDTO
{
    public Guid Id { get; set; }
    public string? Number { get; set; }
    public DateTime IssueDate { get; set; }
    public string? ClientName { get; set; }
    public decimal TotalValue { get; set; }
    public string? IssuerCnpj { get; set; }
    public string? RecipientCnpj { get; set; }
    public List<NotaFiscalItem> Items { get; set; } = new List<NotaFiscalItem>();
    public StatusNota Status { get; set; }
}
