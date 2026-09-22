using Microsoft.EntityFrameworkCore;
using Sistema_de_Gastos.API.Data;
using Sistema_de_Gastos.API.Models;
using Sistema_de_Gastos.API.Repositories.Interfaces;

namespace Sistema_de_Gastos.API.Repositories
{
    public class MetaFinanceiraRepository(AppDbContext context)
        : IMetaFinanceiraRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<MetaFinanceira> CreateMetaFinanceiraAsync(
            MetaFinanceira metaFinanceira)
        {
            _context.MetasFinanceiras.Add(metaFinanceira);
            await _context.SaveChangesAsync();

            return metaFinanceira;
        }

        public async Task<IList<MetaFinanceira>> GetAllMetaFinanceiraAsync()
        {
            return await _context.MetasFinanceiras
                .Include(m => m.Usuario)
                .ToListAsync();
        }

        public async Task<MetaFinanceira?> GetMetaFinanceiraByIdAsync(int id)
        {
            return await _context.MetasFinanceiras
                .Include(m => m.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<MetaFinanceira?> GetMetaFinanceiraByNameAsync(
            string name)
        {
            return await _context.MetasFinanceiras
                .FirstOrDefaultAsync(m => m.Nome == name);
        }

        public async Task<MetaFinanceira> UpdateMetaFinanceiraAsync(
            MetaFinanceira metaFinanceira)
        {
            _context.MetasFinanceiras.Update(metaFinanceira);
            await _context.SaveChangesAsync();

            return metaFinanceira;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var metaFinanceira = await _context.MetasFinanceiras
                .FirstOrDefaultAsync(m => m.Id == id);

            if (metaFinanceira == null)
                return false;

            _context.MetasFinanceiras.Remove(metaFinanceira);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}