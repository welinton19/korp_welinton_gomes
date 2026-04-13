using Stock.Domain.Entities;

namespace Stock.Domain.Interface;

public interface IProdutoRepository
{
    Task<Produto> GetByIdAsync(Guid id);
    Task<Produto> CreateAsync(Produto produto);
    Task<List<Produto>> GetProdutosAsync();
    Task<Produto> UpdateAsync(Produto produto);
    Task<Produto> DeleteAsync(Guid id);
}
