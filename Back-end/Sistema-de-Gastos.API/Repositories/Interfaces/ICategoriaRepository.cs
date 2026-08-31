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

        Task<IList<Categoria>> GetAllCategoriaAsync();

        Task<Categoria?> GetCategoriaByNameAsync(string name);

        Task<Categoria> UpdateCategoriaAsync(Categoria categoria);

        Task<bool> DeleteAsync(int id);

    }
}