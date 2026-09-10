using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_de_Gastos.API.Data;
using Sistema_de_Gastos.API.Interfaces;
using Sistema_de_Gastos.API.Models;
using Sistema_de_Gastos.API.Services.Interface;

namespace Sistema_de_Gastos.API.Services
{
    public class CategoriaService(ICategoriaRepository Repository) : ICategoriaService
    {
        private readonly ICategoriaRepository _context = Repository;

        public async Task<IList<Categoria>> GetAllCategoriaAsync()
        {
            return await _context.GetAllCategoriaAsync();
        }

        public async Task<Categoria?> GetCategoriaByIdAsync(int id)
        {
            return await _context.GetCategoriaByIdAsync(id);
        }

        public async Task<Categoria?> GetCategoriaByNameAsync(string name)
        {
            return await _context.GetCategoriaByNameAsync(name);
        }

        public async Task<Categoria> CreateCategoriaAsync(Categoria categoria)
        {
            if (categoria == null)
                throw new ArgumentNullException(nameof(categoria));

            if (await _context.GetCategoriaByNameAsync(categoria.Nome) != null)
                throw new ArgumentException("Categoria já existe.");

            return await _context.CreateAsync(categoria);
        }

    }
}