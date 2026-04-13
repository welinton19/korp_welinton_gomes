using Nota_Fiscal.application.DTO.NotaFiscalDTO.NotaFiscalDTO;
using Nota_Fiscal.application.DTO.NotaFiscalDTOs;
using Nota_Fiscal.application.Interfaces;
using Nota_Fiscal.Domain.Entities;
using Nota_Fiscal.Domain.Enum;
using Nota_Fiscal.Domain.Interface;

namespace Nota_Fiscal.application.Services;

public class NotaFiscalService : INotaFiscalService
{
    private readonly INotaFiscalRepository _repository;
    private readonly IStockApi _stockApi;

    public NotaFiscalService(INotaFiscalRepository repository, IStockApi stockApi)
    {
        _repository = repository;
        _stockApi = stockApi;
    }

    public async Task<NotaFiscalDTO> CreateNotaFiscalAsync(CreateNotaFiscalDTO createNotaFiscalDTO)
    {
        var notaFiscal = new NotaFiscal
        {
            Id = Guid.NewGuid(),
            Number = createNotaFiscalDTO.Number,
            ClientName = createNotaFiscalDTO.ClientName,
            IssueDate = createNotaFiscalDTO.IssueDate,
            TotalValue = createNotaFiscalDTO.TotalValue,
            IssuerCnpj = createNotaFiscalDTO.IssuerCnpj,
            RecipientCnpj = createNotaFiscalDTO.RecipientCnpj,
            Status = createNotaFiscalDTO.Status
        };

        await _repository.AddAsync(notaFiscal);

        return new NotaFiscalDTO
        {
            Id = notaFiscal.Id,
            Number = notaFiscal.Number,
            ClientName = notaFiscal.ClientName,
            IssueDate = notaFiscal.IssueDate,
            TotalValue = notaFiscal.TotalValue,
            IssuerCnpj = notaFiscal.IssuerCnpj,
            RecipientCnpj = notaFiscal.RecipientCnpj,
            Status = notaFiscal.Status
        };
    }

    public async Task<NotaFiscalDTO> DeleteNotaFiscalAsync(DeleteNotaFiscalDTO deleteNotaFiscalDTO)
    {
        await _repository.DeleteAsync(deleteNotaFiscalDTO.Id);
        return new NotaFiscalDTO
        {
            Id = deleteNotaFiscalDTO.Id
        };

    }

    public async Task<NotaFiscalDTO> GetNotaFiscalByIdAsync(Guid id)
    {
        var notaFiscal = await _repository.GetByIdAsync(id);
        return new NotaFiscalDTO
        {
            Id = notaFiscal.Id,
            Number = notaFiscal.Number,
            IssueDate = notaFiscal.IssueDate,
            TotalValue = notaFiscal.TotalValue
        };
    }

    public async Task<List<NotaFiscalDTO>> GetNotasFiscaisAsync()
    {
        var notasFiscais = await _repository.GetAllAsync();
        return notasFiscais.Select(notaFiscal => new NotaFiscalDTO
        {
            Id = notaFiscal.Id,
            Number = notaFiscal.Number,
            IssueDate = notaFiscal.IssueDate,
            TotalValue = notaFiscal.TotalValue,
            ClientName = notaFiscal.ClientName,
            IssuerCnpj = notaFiscal.IssuerCnpj,
            RecipientCnpj = notaFiscal.RecipientCnpj,
            Status = notaFiscal.Status,        
            Items = notaFiscal.Items           
        }).ToList();
    }



    public async Task<NotaFiscalDTO> UpdateNotaFiscalAsync(UpdateNotaFiscalDTO updateNotaFiscalDTO)
    {
        var notaFiscal = await _repository.GetByIdAsync(updateNotaFiscalDTO.Id);
        if (notaFiscal == null)
        {
            throw new Exception("Nota Fiscal not found");
        }
        
        notaFiscal.Number = updateNotaFiscalDTO.Number;
        notaFiscal.IssueDate = updateNotaFiscalDTO.IssueDate;
        notaFiscal.TotalValue = updateNotaFiscalDTO.TotalValue;

        await _repository.UpdateAsync(notaFiscal);

        return new NotaFiscalDTO
        {
            Id = notaFiscal.Id,
            Number = notaFiscal.Number,
            IssueDate = notaFiscal.IssueDate,
            TotalValue = notaFiscal.TotalValue
        };
    }

    public async Task<NotaFiscalDTO> ImprimirNotaFiscalAsync(Guid id)
    {
        var notaFiscal = await _repository.GetByIdAsync(id);

        if (notaFiscal == null)
            throw new Exception("Nota Fiscal não encontrada");

        if (notaFiscal.Status != StatusNota.Aberta)
            throw new Exception("Nota Fiscal não está Aberta");


        foreach (var item in notaFiscal.Items)
        {
            try
            {
                
                var stockResponse = await _stockApi.GetById(item.ProdutoId, item.Quantity);

                if (stockResponse == null)
                    throw new Exception("Resposta do serviço de estoque nula");

                
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao deduzir estoque: {ex.Message}");
            }
        }

       
        notaFiscal.Status = StatusNota.Fechada;
        await _repository.UpdateAsync(notaFiscal);

        return new NotaFiscalDTO
        {
            Id = notaFiscal.Id,
            Number = notaFiscal.Number,
            Status = notaFiscal.Status,
            IssueDate = notaFiscal.IssueDate,
            TotalValue = notaFiscal.TotalValue
        };
    }
}
