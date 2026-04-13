namespace Nota_Fiscal.application.DTO.NotaFiscalItensDTOs;

public class UpdateNotaFiscalItensDTO
{
    public Guid Id { get; set; }
    public Guid ProdutoId { get; set; }
    public string? CodeProduto { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
