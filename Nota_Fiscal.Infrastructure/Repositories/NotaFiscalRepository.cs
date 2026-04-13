using Microsoft.EntityFrameworkCore;
using Nota_Fiscal.Domain.Entities;
using Nota_Fiscal.Domain.Interface;
using Nota_Fiscal.Infrastructure.Data;

namespace Nota_Fiscal.Infrastructure.Repositories;

public class NotaFiscalRepository : INotaFiscalRepository
{
    private readonly NotaFiscalDbContext _context;

    public NotaFiscalRepository(NotaFiscalDbContext context)
    {
        _context = context;
    }

    public async Task<NotaFiscal> AddAsync(NotaFiscal notaFiscal)
    {
        _context.Add(notaFiscal);
        await _context.SaveChangesAsync();
        return notaFiscal;
    }

    public async Task DeduzirEstoque(Guid produtoId, int quantity)
    {
        
        await _context.Produtos
            .Where(p => p.Id == produtoId)
            .ExecuteUpdateAsync(p => p.SetProperty(p => p.Balance, p => p.Balance - quantity));
    }

    public async Task DeleteAsync(Guid id)
    {
        await _context.NotasFiscais.Where(n => n.Id == id).ExecuteDeleteAsync();
    }

    public async Task<IEnumerable<NotaFiscal>> GetAllAsync()
    {
        await _context.NotasFiscais.Include(n => n.Items).LoadAsync();
        return _context.NotasFiscais;
    }

    public async Task<NotaFiscal> GetByIdAsync(Guid id)
    {
        return await _context.NotasFiscais.Include(n => n.Items).FirstOrDefaultAsync(n => n.Id == id);
    }

    public async Task<NotaFiscal> UpdateAsync(NotaFiscal notaFiscal)
    {
        _context.NotasFiscais.Update(notaFiscal);
        await _context.SaveChangesAsync();
        return notaFiscal;
    }
}
