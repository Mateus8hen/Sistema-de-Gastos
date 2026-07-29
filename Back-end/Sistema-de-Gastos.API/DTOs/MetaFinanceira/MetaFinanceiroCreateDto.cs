using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Gastos.API.DTOs.MetaFinanceira
{
    public class MetaFinanceiroCreateDto
    {
        public string Nome { get; set; } = string.Empty;

        public decimal ValorObjetivo { get; set; }
        

    }
}