using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_de_Gastos.API.Models;

namespace Sistema_de_Gastos.API.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetUsuarioByNameAsync(string nome);

        Task<Usuario?> GetUsuarioByEmailAsync(string email);

        Task<Usuario> CreateUsuarioAsync(Usuario usuario);

        Task<Usuario?> UpdateUsuarioAsync(Usuario usuario);
    }
}