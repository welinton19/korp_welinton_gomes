namespace Stock.Application.DTOs;

public class UpdateProdutoDTO
{
    public Guid Id { get; set; }
    public string? Code { get; set; }
    public string? Description { get;  set; }
    public decimal Price { get;  set; }

    public int Balance { get;  set; }
}
