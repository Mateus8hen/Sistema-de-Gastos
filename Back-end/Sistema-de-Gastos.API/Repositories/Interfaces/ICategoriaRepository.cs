using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_de_Gastos.API.Models;

namespace Sistema_de_Gastos.API.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<Categoria> CreateAsync(Categoria categoria);

        Task<IList<Categoria>> GetAllAsync();

        Task<Categoria?> GetByIdAsync(int id);

        Task<Categoria> GetbyNameAsync(string nome);

        Task<Categoria> UpdateAsync();

        Task<bool> DeleteAsync(int id);

    }
}