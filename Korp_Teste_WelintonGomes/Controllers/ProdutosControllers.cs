using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stock.Application.DTOs;
using Stock.Application.Interface;

namespace Stock_API.Controllers;

[Route("api/stock/produtos")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoService _produtoService;

    public ProdutosController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var produtos = await _produtoService.GetProdutosAsync();
        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var produto = await _produtoService.GetProdutoByIdAsync(id);
        if (produto == null)
        {
            return NotFound();
        }
        return Ok(produto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProdutoDTO createProdutoDto)
    {
        var createdProduto = await _produtoService.CreateProdutoAsync(createProdutoDto);
        return CreatedAtAction(nameof(GetById), new { id = createdProduto.Code }, createdProduto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var removerptoduto = await _produtoService.DeleteProdutoAsync(removeProdutoDTO: new RemoveProdutoDTO { Id = id });
        if (removerptoduto == null) { return NotFound(); }
        return Ok(removerptoduto);
    }
     
}
