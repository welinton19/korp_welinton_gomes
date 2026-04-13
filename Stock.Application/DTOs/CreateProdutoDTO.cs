namespace Stock.Application.DTOs;

public class CreateProdutoDTO
{
    public string? Code { get; set; }
    public string? Description { get; set; }
    public Decimal? Price { get; set; }
    public int Balance { get; set; }

}
