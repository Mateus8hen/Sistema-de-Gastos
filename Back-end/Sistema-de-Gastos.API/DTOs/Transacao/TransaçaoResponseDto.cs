using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Gastos.API.DTOs.Transacao
{
    public class TransacaoResponseDto
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public decimal Valor { get; set; }

        public DateTime Vencimento { get; set; }


        public int CategoriaId { get; set; }

        public string? CategoriaNome { get; set; }

    }
}