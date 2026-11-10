using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_de_Gastos.API.Models;

namespace Sistema_de_Gastos.API.Services.Interface
{
    public interface IMetaFinanceiraService
    {
        Task<IEnumerable<MetaFinanceira>> GetAllMetaFinanceiraAsync();

        Task<MetaFinanceira> GetMetaFinanceiraByIdAsync(int id);

        Task<MetaFinanceira> CreateMetaFinanceiraAsync(MetaFinanceira meta);

        Task<MetaFinanceira> UpdateMetaFinanceiraAsync(int id, MetaFinanceira meta);

        Task<bool> DeleteMetaFinanceiraAsync(int id);
    }
}