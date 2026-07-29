using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Gastos.API.DTOs.Usuario
{
    public class UsuarioResponseDto
    {
        public string? Nome { get; set; }

        public string? Email { get; set; }

        public int Id { get; set; }
    }
}