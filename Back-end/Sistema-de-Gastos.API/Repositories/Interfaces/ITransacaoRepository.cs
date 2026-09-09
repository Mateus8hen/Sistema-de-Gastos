using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_de_Gastos.API.Models;

namespace Sistema_de_Gastos.API.Repositories.Interfaces
{
    public interface ITransacaoRepository
    {
        Task<Transacao> CreateTransacaoAsync(Transacao transacao);

        Task<IList<Transacao>> GetAllTransacaoAsync();

        Task<Transacao?> GetTransacaoByIdAsync(int id);

        Task<Transacao?> GetTransacaoByNameAsync(string name);

        Task<Transacao> UpdateTransacaoAsync(Transacao transacao);

        Task<bool> DeleteAsync(int id);
    }
}