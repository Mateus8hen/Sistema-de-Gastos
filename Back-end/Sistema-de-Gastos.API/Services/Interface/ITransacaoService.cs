using Sistema_de_Gastos.API.Models;

namespace Sistema_de_Gastos.API.Services.Interface
{
    public interface ITransacaoService
    {
        Task<Transacao> CreateTransacaoAsync(Transacao transacao);
        Task<IList<Transacao>> GetAllTransacaoAsync();
        Task<Transacao?> GetTransacaoByIdAsync(int id);
        Task<Transacao?> GetTransacaoByNameAsync(string name);
        Task<Transacao> UpdateTransacaoAsync(Transacao transacao);
        Task<bool> DeleteTransacaoAsync(int id);
    }
}