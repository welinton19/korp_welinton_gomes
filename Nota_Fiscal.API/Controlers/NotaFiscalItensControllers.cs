using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nota_Fiscal.application.DTO.NotaFiscalItensDTOs;
using Nota_Fiscal.application.Interfaces;

namespace Nota_Fiscal.API.Controlers;

[Route("api/nota-fiscal/notafiscalitens")]
[ApiController]
public class NotaFiscalItensController : ControllerBase
{
    private readonly INotaFiscalItensService _notaFiscalItensService;

    public NotaFiscalItensController(INotaFiscalItensService notaFiscalItensService)
    {
        _notaFiscalItensService = notaFiscalItensService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _notaFiscalItensService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id) 
    {
        var result = await _notaFiscalItensService.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] NotaFiscalItensDTO notaFiscalItemDto)
    {
        var result = await _notaFiscalItensService.CreateAsync(notaFiscalItemDto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _notaFiscalItensService.DeleteAsync(id);
        return Ok();
    }
}
