using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_de_Gastos.API.Models;
using Sistema_de_Gastos.API.Services.Interface;

namespace Sistema_de_Gastos.API.Services
{
    public class MetaFinanceiraService(IMetaFinanceiraService Repository) : IMetaFinanceiraService
    {
        private readonly IMetaFinanceiraService _repository = Repository;

        public async Task<IEnumerable<MetaFinanceira>> GetAllMetaFinanceiraAsync()
            => await _repository.GetAllMetaFinanceiraAsync();

        public async Task<MetaFinanceira> GetMetaFinanceiraByIdAsync(int id)
            => await _repository.GetMetaFinanceiraByIdAsync(id);

        public async Task<MetaFinanceira> CreateMetaFinanceiraAsync(MetaFinanceira meta)
        {
            if (meta == null)
                throw new ArgumentNullException(nameof(meta));

            return await _repository.CreateMetaFinanceiraAsync(meta);
        }

        public async Task<MetaFinanceira> UpdateMetaFinanceiraAsync(int id, MetaFinanceira meta)
        {
            if (meta == null)
                throw new ArgumentNullException(nameof(meta));

            if (await _repository.GetMetaFinanceiraByIdAsync(id) == null)
                throw new ArgumentException("Meta Financeira não encontrada.");

            return await _repository.UpdateMetaFinanceiraAsync(id, meta);
        }

        public async Task<bool> DeleteMetaFinanceiraAsync(int id)
        {
            var meta = await _repository.GetMetaFinanceiraByIdAsync(id);

            if (meta == null)
                throw new ArgumentException("Meta Financeira não encontrada.");

            await _repository.DeleteMetaFinanceiraAsync(id);
            return true;
        }

    }
}