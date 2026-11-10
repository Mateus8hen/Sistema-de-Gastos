using Sistema_de_Gastos.API.Models;
using Sistema_de_Gastos.API.Repositories.Interfaces;
using Sistema_de_Gastos.API.Services.Interface;

namespace Sistema_de_Gastos.API.Services
{
    public class TransacaoService(ITransacaoRepository repository)
        : ITransacaoService
    {
        private readonly ITransacaoRepository _repository = repository;

        public async Task<IList<Transacao>> GetAllTransacaoAsync()
            => await _repository.GetAllTransacaoAsync();

        public async Task<Transacao?> GetTransacaoByIdAsync(int id)
            => await _repository.GetTransacaoByIdAsync(id);

        public async Task<Transacao?> GetTransacaoByNameAsync(string name)
            => await _repository.GetTransacaoByNameAsync(name);

        public async Task<Transacao> CreateTransacaoAsync(Transacao transacao)
        {
            if (transacao == null)
                throw new ArgumentNullException(nameof(transacao));

            if (await _repository.GetTransacaoByNameAsync(transacao.Nome) != null)
                throw new ArgumentException("Transação já existe.");

            return await _repository.CreateTransacaoAsync(transacao);
        }

        public async Task<Transacao> UpdateTransacaoAsync(Transacao transacao)
        {
            if (transacao == null)
                throw new ArgumentNullException(nameof(transacao));

            if (await _repository.GetTransacaoByIdAsync(transacao.Id) == null)
                throw new ArgumentException("Transação não encontrada.");

            return await _repository.UpdateTransacaoAsync(transacao);
        }

        public async Task<Transacao> UpdateTransacaoAsync(int id, Transacao transacao)
        {
            if (transacao == null)
                throw new ArgumentNullException(nameof(transacao));

            var existingTransacao = await _repository.GetTransacaoByIdAsync(id);
            if (existingTransacao == null)
                throw new ArgumentException("Transação não encontrada.");

            existingTransacao.Nome = transacao.Nome;
            existingTransacao.Valor = transacao.Valor;
            existingTransacao.Vencimento = transacao.Vencimento;
            existingTransacao.CategoriaID = transacao.CategoriaID;
            existingTransacao.UsuarioId = transacao.UsuarioId;

            return await _repository.UpdateTransacaoAsync(existingTransacao);
        }

        public async Task<bool> DeleteTransacaoAsync(int id)
        {
            if (await _repository.GetTransacaoByIdAsync(id) == null)
                throw new ArgumentException("Transação não encontrada.");

            return await _repository.DeleteAsync(id);
        }
    }
}