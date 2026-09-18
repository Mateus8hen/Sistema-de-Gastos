using Sistema_de_Gastos.API.Models;

namespace Sistema_de_Gastos.API.Services.Interface
{
    public interface IUsuarioService
    {
        Task<Usuario> CreateUsuarioAsync(Usuario usuario);
        Task<IList<Usuario>> GetAllUsuarioAsync();
        Task<Usuario?> GetUsuarioByIdAsync(int id);
        Task<Usuario?> GetUsuarioByNameAsync(string name);
        Task<Usuario> UpdateUsuarioAsync(Usuario usuario);
        Task<bool> InativarUsuarioAsync(int id);
    }
}