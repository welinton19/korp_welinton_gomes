using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stock.Application.Interface;

namespace Stock_API.Controllers;

[Route("api/stock/stock")]
[ApiController]
public class StockController : ControllerBase
{
    private readonly IStockService _stockService;

    public StockController(IStockService stockService)
    {
        _stockService = stockService;
    }

    [HttpPut]
    public async Task<IActionResult> UpdateStock(Guid productId, int quantity)
    {
        await _stockService.UpdateStockAsync(productId, quantity);
        return Ok();
    }
}
