using Stock.Application.DTOs;

namespace Stock.Application.Interface;

public interface IProdutoService
{
    Task<ProdutoDTO> CreateProdutoAsync(CreateProdutoDTO createProdutoDTO);
    Task<ProdutoDTO> UpdateProdutoAsync(UpdateProdutoDTO updateProdutoDTO);
    Task<ProdutoDTO> GetProdutoByIdAsync(Guid id);
    Task<List<ProdutoDTO>> GetProdutosAsync();
    Task<ProdutoDTO> DeleteProdutoAsync(RemoveProdutoDTO removeProdutoDTO);
}
