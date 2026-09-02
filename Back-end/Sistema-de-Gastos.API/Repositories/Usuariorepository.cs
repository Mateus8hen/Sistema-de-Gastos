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
    public class Usuariorepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public Usuariorepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> GetUsuarioByNameAsync(string nome)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Nome == nome);
        }

        public async Task<Usuario?> GetUsuarioByEmailAsync(string email)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Usuario> CreateUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario?> UpdateUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
}