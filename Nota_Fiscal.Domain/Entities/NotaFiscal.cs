using Nota_Fiscal.Domain.Enum;

namespace Nota_Fiscal.Domain.Entities;

public class NotaFiscal
{
    public Guid Id { get; set; }
    public string? Number { get; set; }
    public DateTime IssueDate { get; set; }
    public string? ClientName { get; set; }
    public decimal TotalValue { get; set; }
    public string? IssuerCnpj { get; set; }
    public string? RecipientCnpj { get; set; }
    public List<NotaFiscalItem> Items { get; set; } = new List<NotaFiscalItem>();
    public StatusNota Status{ get; set; }

    public NotaFiscal() { }

    public NotaFiscal(string number, DateTime issueDate, string clientName, decimal totalValue, string issuerCnpj, string recipientCnpj, List<NotaFiscalItem> items)
    {
        Id = Guid.NewGuid();
        Number = number;
        IssueDate = issueDate;
        ClientName = clientName;
        TotalValue = totalValue;
        IssuerCnpj = issuerCnpj;
        RecipientCnpj = recipientCnpj;
        Items = items;
        Status = StatusNota.Emitida; 
    }

    private decimal CalculateTotalValue()
    {
        return Items.Sum(item => item.Quantity * item.UnitPrice);
    }

    private string GenerateNumber()
    {
        return $"NF-{DateTime.Now:yyyyMMddHHmmss}-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";
    }
}
