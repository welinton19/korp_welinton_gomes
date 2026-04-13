using Stock_API.ServicesHtttp;

namespace Stock.Infraestructure.HttpService;

public class NotaFiscalServiceHttp : INotaFiscalApi
{
    private readonly INotaFiscalApi _notaFiscalApi;
    public NotaFiscalServiceHttp(INotaFiscalApi notaFiscalApi)
    {
        _notaFiscalApi = notaFiscalApi;
    }
    public Task<NotaFiscalResponse> GetNotaFiscalByIdAsync(Guid id)
    {
        return _notaFiscalApi.GetNotaFiscalByIdAsync(id);
    }
}
