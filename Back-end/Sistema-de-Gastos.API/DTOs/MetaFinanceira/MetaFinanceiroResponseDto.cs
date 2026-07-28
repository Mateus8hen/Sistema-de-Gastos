using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Gastos.API.DTOs.MetaFinanceira
{
    public class MetaFinanceiroResponseDto
    {
        public string? Nome { get; set; }

        public decimal ValorObjetivo { get; set; }

        public int ValorAtual { get; set; }


        public int UsuarioId { get; set; }
    }
}