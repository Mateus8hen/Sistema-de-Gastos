using Sistema_de_Gastos.API.Models;

namespace Sistema_de_Gastos.API.Repositories.Interfaces
{
    public interface IMetaFinanceiraRepository
    {
        Task<MetaFinanceira> CreateMetaFinanceiraAsync(MetaFinanceira metaFinanceira);
        Task<IList<MetaFinanceira>> GetAllMetaFinanceiraAsync();
        Task<MetaFinanceira?> GetMetaFinanceiraByIdAsync(int id);
        Task<MetaFinanceira?> GetMetaFinanceiraByNameAsync(string name);
        Task<MetaFinanceira> UpdateMetaFinanceiraAsync(MetaFinanceira metaFinanceira);
        Task<bool> DeleteAsync(int id);
    }
}