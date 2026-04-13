namespace Stock.Domain.Entities;

public class Produto
{
    public Guid Id { get;  set; }
    public string? Code { get;  set; }
    public string? Description { get;  set; }
    public decimal Price { get;  set; }

    public int Balance { get;  set; }
    

    public StockProduto DeductBalance(int quantity)
    {
        if (quantity > Balance)
            return StockProduto.Failure("Saldo insuficiente");
        Balance -= quantity;
        return StockProduto.Success();
    }
}
