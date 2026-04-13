using Stock.Domain.Entities;
using Stock.Domain.Interface;
using Stock.Infraestructure.Data;

namespace Stock.Infraestructure.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly StockDbContext _context;

    public ProdutoRepository(StockDbContext context)
    {
        _context = context;
    }

    public Task<Produto> CreateAsync(Produto produto)
    {
        _context.Produtos.Add(produto);
        _context.SaveChanges();
        return Task.FromResult(produto);
    }

    public async Task<Produto> DeleteAsync(Guid id)
    {
        var produto = await _context.Produtos.FindAsync(id);

        if (produto == null)
            return null;

        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();

        return produto;
    }

    public Task<Produto> GetByIdAsync(Guid id)
    {
        _context.Produtos.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(_context.Produtos.FirstOrDefault(x => x.Id == id));
    }

    public Task<List<Produto>> GetProdutosAsync()
    {
        _context.Produtos.ToList();
        return Task.FromResult(_context.Produtos.ToList());
    }

    public Task<Produto> UpdateAsync(Produto produto)
    {
        _context.Produtos.Update(produto);
        _context.SaveChanges();
        return Task.FromResult(produto);
    }
}
