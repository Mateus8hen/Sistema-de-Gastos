
using Sistema_de_Gastos.API.Interfaces;
using Sistema_de_Gastos.API.Models;
using Sistema_de_Gastos.API.Services.Interface;

namespace Sistema_de_Gastos.API.Services
{
    public class CategoriaService(ICategoriaRepository repository)
        : ICategoriaService
    {
        private readonly ICategoriaRepository _repository = repository;

        public async Task<IList<Categoria>> GetAllCategoriaAsync()
            => await _repository.GetAllCategoriaAsync();

        public async Task<Categoria?> GetCategoriaByIdAsync(int id)
            => await _repository.GetCategoriaByIdAsync(id);

        public async Task<Categoria?> GetCategoriaByNameAsync(string name)
            => await _repository.GetCategoriaByNameAsync(name);

        public async Task<Categoria> CreateCategoriaAsync(Categoria categoria)
        {
            if (categoria == null)
                throw new ArgumentNullException(nameof(categoria));

            if (await _repository.GetCategoriaByNameAsync(categoria.Nome) != null)
                throw new ArgumentException("Categoria já existe.");

            return await _repository.CreateAsync(categoria);
        }

        public async Task<Categoria> UpdateCategoriaAsync(Categoria categoria)
        {
            if (categoria == null)
                throw new ArgumentNullException(nameof(categoria));

            if (await _repository.GetCategoriaByIdAsync(categoria.Id) == null)
                throw new ArgumentException("Categoria não encontrada.");

            return await _repository.UpdateCategoriaAsync(categoria);
        }

        public async Task<bool> DeleteCategoriaAsync(int id)
        {
            if (await _repository.GetCategoriaByIdAsync(id) == null)
                throw new ArgumentException("Categoria não encontrada.");

            return await _repository.DeleteAsync(id);
        }
    }
}