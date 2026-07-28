using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Gastos.API.DTOs.Transaçao
{
    public class TransaçaoResponseDto
    {
        public string? Nome { get; set; }

        public decimal Valor { get; set; }

        public DateTime Fechamento { get; set; }


        public int CategoriaId { get; set; }

        public string? CategoriaNome { get; set; }

    }
}