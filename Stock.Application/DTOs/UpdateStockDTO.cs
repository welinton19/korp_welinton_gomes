namespace Stock.Application.DTOs;

public class UpdateStockDTO
{
    public Guid Id { get; set; }
    public string? Code { get; set; }
    public int Quantity { get; set; }
}
