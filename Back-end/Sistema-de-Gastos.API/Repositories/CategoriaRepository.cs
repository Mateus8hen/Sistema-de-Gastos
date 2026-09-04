using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Gastos.API.Data;
using Sistema_de_Gastos.API.Interfaces;
using Sistema_de_Gastos.API.Models;

namespace Sistema_de_Gastos.API.Repositories
{
    public class CategoriaRepository(AppDbContext context) : ICategoriaRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<IList<Categoria>> GetAllCategoriaAsync()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria?> GetCategoriaByIdAsync(int id)
        {
           return await _context.Categorias
           .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Categoria?> GetCategoriaByNameAsync(string name)
        {
            return await _context.Categorias
            .FirstOrDefaultAsync(c => c.Nome == name);
        }

        public async Task<Categoria> CreateAsync(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> UpdateCategoriaAsync(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }
        
        public async Task<bool> DeleteAsync(int id)
        {
            var categoria = await _context.Categorias
                .FirstOrDefaultAsync(c => c.Id == id);

            if (categoria == null)
                return false;

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}