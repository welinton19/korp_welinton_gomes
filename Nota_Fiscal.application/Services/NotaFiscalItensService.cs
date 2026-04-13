using Nota_Fiscal.application.DTO.NotaFiscalItensDTOs;
using Nota_Fiscal.application.Interfaces;
using Nota_Fiscal.Domain.Entities;
using Nota_Fiscal.Domain.Interface;

namespace Nota_Fiscal.application.Services;

public class NotaFiscalItensService : INotaFiscalItensService
{
    private readonly INotaFiscalItemRepository _repository;
    public NotaFiscalItensService(INotaFiscalItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<NotaFiscalItensDTO> CreateAsync(NotaFiscalItensDTO item)
    {
        var notaFiscalItem = new NotaFiscalItem
        {
            Id = Guid.NewGuid(),
            CodeProduto = item.CodeProduto,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice
            
        };
        await _repository.AddAsync(notaFiscalItem);
        
        return new NotaFiscalItensDTO
        {
            Id = notaFiscalItem.Id,
            CodeProduto = notaFiscalItem.CodeProduto,
            Quantity = notaFiscalItem.Quantity,
            UnitPrice = notaFiscalItem.UnitPrice
            
        };
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<NotaFiscalItensDTO>> GetAllAsync()
    {
        var items = await _repository.GetAllAsync();
        return items.Select(item => new NotaFiscalItensDTO
        {
            Id = item.Id,
            CodeProduto = item.CodeProduto,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice
        }).ToList();
    }

    public async Task<NotaFiscalItensDTO> GetByIdAsync(Guid id)
    {
        var item = await _repository.GetByIdAsync(id);
        if (item == null)
        {
            return null;
        }
        return new NotaFiscalItensDTO
        {
            Id = item.Id,
            CodeProduto = item.CodeProduto,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice
        };
    }
    

    public async Task UpdateAsync(Guid id, NotaFiscalItensDTO item)
    {
        var notaFiscalItem = await _repository.GetByIdAsync(id);
        if (notaFiscalItem == null)
        {
            throw new Exception("Nota Fiscal Item not found");
        }

        notaFiscalItem.CodeProduto = item.CodeProduto;
        notaFiscalItem.Quantity = item.Quantity;
        notaFiscalItem.UnitPrice = item.UnitPrice;

        await _repository.UpdateAsync(notaFiscalItem);
    }
}
