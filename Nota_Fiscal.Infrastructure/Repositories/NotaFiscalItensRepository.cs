using Microsoft.EntityFrameworkCore;
using Nota_Fiscal.Domain.Entities;
using Nota_Fiscal.Domain.Interface;
using Nota_Fiscal.Infrastructure.Data;

namespace Nota_Fiscal.Infrastructure.Repositories;

public class NotaFiscalItensRepository : INotaFiscalItemRepository
{
    private readonly NotaFiscalDbContext _context;

    public NotaFiscalItensRepository(NotaFiscalDbContext context)
    {
        _context = context;
    }

    public async Task<NotaFiscalItem> AddAsync(NotaFiscalItem notaFiscalItem)
    {
        _context.Add(notaFiscalItem);
        await _context.SaveChangesAsync();
        return notaFiscalItem;
    }

    public async Task DeleteAsync(Guid id)
    {
        var notaFiscalItem = await _context.NotaFiscalItens.FindAsync(id);
        if (notaFiscalItem != null)
        {
            _context.NotaFiscalItens.Remove(notaFiscalItem);
            await _context.SaveChangesAsync();
        }
        
    }

    public async Task<IEnumerable<NotaFiscalItem>> GetAllAsync()
    {
        await _context.NotaFiscalItens.LoadAsync();
        return _context.NotaFiscalItens;
    }

    public async Task<NotaFiscalItem> GetByIdAsync(Guid id)
    {
        return await _context.NotaFiscalItens.FindAsync(id);
    }

    public async Task<NotaFiscalItem> UpdateAsync(NotaFiscalItem notaFiscalItem)
    {
        _context.Update(notaFiscalItem);
        await _context.SaveChangesAsync();
        return notaFiscalItem;
    }
}
