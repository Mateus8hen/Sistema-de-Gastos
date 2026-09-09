using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_de_Gastos.API.Models;

namespace Sistema_de_Gastos.API.Services.Interface
{
    public interface ICategoriaService
    {
        Task<Categoria> CreateCategoriaAsync(Categoria categoria);

        Task<IList<Categoria>> GetAllCategoriaAsync();

        Task<Categoria?> GetCategoriaByIdAsync(int id);

        Task<Categoria?> GetCategoriaByNameAsync(string name);

        Task<Categoria> UpdateCategoriaAsync(Categoria categoria);

        Task<bool> DeleteCategoriaAsync(int id);
        
    }
}