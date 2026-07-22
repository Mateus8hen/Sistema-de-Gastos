using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Gastos.API.Models
{
    public class MetaFinanceira
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public decimal ValorObejtivo { get; set; }

        public int ValorAtual { get; set; }


        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; } = null!;
        
        }
}