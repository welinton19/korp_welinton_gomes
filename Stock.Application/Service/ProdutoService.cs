using System;
using System.Threading.Tasks;
using Stock.Application.DTOs;
using Stock.Application.Interface;
using Stock.Domain.Entities;
using Stock.Domain.Interface;
using Stock_API.ServicesHtttp;

namespace Stock.Application.Service;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    private readonly INotaFiscalApi _notaFiscalApi;

    public ProdutoService(IProdutoRepository produtoRepository, INotaFiscalApi notaFiscalApi)
    {
        _produtoRepository = produtoRepository;
        _notaFiscalApi = notaFiscalApi;
    }

    public async Task<ProdutoDTO> CreateProdutoAsync(CreateProdutoDTO createProdutoDTO)
    {
        if (createProdutoDTO is null) throw new ArgumentNullException(nameof(createProdutoDTO));

        var produtoType = typeof(Produto);
        var produto = Activator.CreateInstance(produtoType, nonPublic: true) as Produto
            ?? throw new InvalidOperationException($"Não foi possível criar uma instância de {produtoType.FullName}.");

        
        produtoType.GetProperty(nameof(Produto.Id))?.SetValue(produto, Guid.NewGuid());
        produtoType.GetProperty(nameof(Produto.Code))?.SetValue(produto, createProdutoDTO.Code ?? throw new ArgumentNullException(nameof(createProdutoDTO.Code)));
        produtoType.GetProperty(nameof(Produto.Description))?.SetValue(produto, createProdutoDTO.Description ?? string.Empty);
        produtoType.GetProperty(nameof(Produto.Price))?.SetValue(produto, createProdutoDTO.Price ?? 0m);
        produtoType.GetProperty(nameof(Produto.Balance))?.SetValue(produto, createProdutoDTO.Balance);

        
        var createdProduto = await _produtoRepository.CreateAsync(produto);
        return new ProdutoDTO
        {
            Id = createdProduto.Id,
            Code = createdProduto.Code,
            Description = createdProduto.Description,
            Price = createdProduto.Price,
            Balance = createdProduto.Balance
        };
    }

    public async Task<ProdutoDTO> DeleteProdutoAsync(RemoveProdutoDTO removeProdutoDTO)
    {
        var produtoExcluido = await _produtoRepository.DeleteAsync(removeProdutoDTO.Id);
        if(produtoExcluido == null)
            return null;
        return new ProdutoDTO
        {
            Id =produtoExcluido.Id,
            Code = produtoExcluido.Code,
            Description = produtoExcluido.Description,
            Price = produtoExcluido.Price,
            Balance = produtoExcluido.Balance
        };
    }

    public async Task<ProdutoDTO> GetProdutoByIdAsync(Guid id)
    {
        var produtoId = await _produtoRepository.GetByIdAsync(id);
        if(produtoId == null)
            return null;
        return new ProdutoDTO
        {
            Code = produtoId.Code,
            Description = produtoId.Description,
            Price = produtoId.Price,
            Balance = produtoId.Balance
        };
    }

    public async Task<List<ProdutoDTO>> GetProdutosAsync()
    {
        var todosProdutos = await _produtoRepository.GetProdutosAsync();
        var produtoDTOs = new List<ProdutoDTO>();
        foreach (var produto in todosProdutos)
        {
            produtoDTOs.Add(new ProdutoDTO
            {
                Code = produto.Code,
                Description = produto.Description,
                Price = produto.Price,
                Balance = produto.Balance
            });
        }
        return produtoDTOs;
    }

    public async Task<ProdutoDTO> UpdateProdutoAsync(UpdateProdutoDTO updateProdutoDTO)
    {
        var atualizarProduto = await _produtoRepository.UpdateAsync(new Produto
        {
            Id = updateProdutoDTO.Id,
            Code = updateProdutoDTO.Code ?? throw new ArgumentNullException(nameof(updateProdutoDTO.Code)),
            Description = updateProdutoDTO.Description ?? string.Empty,
            Price = updateProdutoDTO.Price,
            Balance = updateProdutoDTO.Balance
        });
        return new ProdutoDTO
        {
            Code = atualizarProduto.Code,
            Description = atualizarProduto.Description,
            Price = atualizarProduto.Price,
            Balance = atualizarProduto.Balance
        };
        
    }

    public async Task BuscarNota(Guid id) 
    {
        var notaFiscal = await _notaFiscalApi.GetNotaFiscalByIdAsync(id);
        
    }
}
