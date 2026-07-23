using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Gastos.API.DTOs.Categoria
{
    public class CategoriaResponseDto
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Descricao { get; set; } = string.Empty;

        public DateTime Criacao { get; set; }

        public bool IsAtivo { get; set; } = true;
    }
}