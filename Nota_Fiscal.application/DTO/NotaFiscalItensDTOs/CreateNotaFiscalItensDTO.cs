namespace Nota_Fiscal.application.DTO.NotaFiscalItensDTOs;

public class CreateNotaFiscalItensDTO
{
    public Guid ProdutoId { get; set; }
    public string? CodeProduto { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
