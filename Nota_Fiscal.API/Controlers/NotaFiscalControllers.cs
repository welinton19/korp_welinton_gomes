using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nota_Fiscal.application.DTO.NotaFiscalDTO.NotaFiscalDTO;
using Nota_Fiscal.application.DTO.NotaFiscalDTOs;
using Nota_Fiscal.application.Interfaces;

namespace Nota_Fiscal.API.Controlers;

[Route("api/nota-fiscal/notafiscal")]
[ApiController]
public class NotaFiscalController : ControllerBase
{
    private readonly INotaFiscalService _notaFiscalService;

    public NotaFiscalController(INotaFiscalService notaFiscalService)
    {
        _notaFiscalService = notaFiscalService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _notaFiscalService.GetNotasFiscaisAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _notaFiscalService.GetNotaFiscalByIdAsync(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateNotaFiscalDTO notaFiscalCreateDto)
    {
        var result = await _notaFiscalService.CreateNotaFiscalAsync(notaFiscalCreateDto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateNotaFiscalDTO notaFiscalUpdateDto)
    {
        if (notaFiscalUpdateDto == null)
            return BadRequest();

        notaFiscalUpdateDto.Id = id;
        var result = await _notaFiscalService.UpdateNotaFiscalAsync(notaFiscalUpdateDto);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _notaFiscalService.DeleteNotaFiscalAsync(new DeleteNotaFiscalDTO { Id = id });
        return Ok();
    }

    [HttpPost("{id}/imprimir")]
    public async Task<IActionResult> Imprimir(Guid id)
    {
        var result = await _notaFiscalService.ImprimirNotaFiscalAsync(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }
}