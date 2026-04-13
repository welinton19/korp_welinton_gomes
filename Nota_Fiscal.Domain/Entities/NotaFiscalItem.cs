namespace Nota_Fiscal.Domain.Entities;

public class NotaFiscalItem
{
    public Guid Id { get; set; }
    public Guid ProdutoId { get; set; }
    public string? CodeProduto { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

    public decimal SubTotal  => Quantity * UnitPrice;

    public NotaFiscalItem() { }

    public NotaFiscalItem(Guid produtoId, string codeProduto, int quantity, decimal unitPrice)
    {
        Id = Guid.NewGuid();
        ProdutoId = produtoId;
        CodeProduto = codeProduto;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}
