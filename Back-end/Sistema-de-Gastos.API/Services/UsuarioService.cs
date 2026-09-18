using Sistema_de_Gastos.API.Interfaces;
using Sistema_de_Gastos.API.Models;
using Sistema_de_Gastos.API.Repositories.Interfaces;
using Sistema_de_Gastos.API.Services.Interface;

namespace Sistema_de_Gastos.API.Services
{
    public class UsuarioService(IUsuarioRepository repository)  : IUsuarioService
    {
        private readonly IUsuarioRepository _repository = repository;

        public async Task<IList<Usuario>> GetAllUsuarioAsync()
            => await _repository.GetAllUsuariosAsync();

        public async Task<Usuario?> GetUsuarioByIdAsync(int id)
            => await _repository.GetUsuarioByIdAsync(id);

        public async Task<Usuario?> GetUsuarioByNameAsync(string name)
            => await _repository.GetUsuarioByNameAsync(name);

        public async Task<Usuario> CreateUsuarioAsync(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            if (await _repository.GetUsuarioByNameAsync(usuario.Nome) != null)
                throw new ArgumentException("Usuário já existe.");

            return await _repository.CreateUsuarioAsync(usuario);
        }

        public async Task<Usuario> UpdateUsuarioAsync(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            if (await _repository.GetUsuarioByIdAsync(usuario.Id) == null)
                throw new ArgumentException("Usuário não encontrado.");

            return await _repository.UpdateUsuarioAsync(usuario);
        }

        public async Task<bool> InativarUsuarioAsync(int id)
        {
            var usuario = await _repository.GetUsuarioByIdAsync(id);

            if (usuario == null)
                throw new ArgumentException("Usuário não encontrado.");

            await _repository.InativarUsuarioAsync(id);
            return true;
        }
    }
}