namespace Stock.Domain.Entities;

public class StockProduto
{
    public Guid Id { get; set; }
    public bool IsSuccess { get; set; }
    public string Error { get; set; }

    private StockProduto(bool isSuccess, string error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static StockProduto Success() => new(true, null);
    public static StockProduto Failure(string error) => new(false, error);
}
