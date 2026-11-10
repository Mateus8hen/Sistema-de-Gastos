using static Sistema_de_Gastos.API.Models.Enums;

namespace Sistema_de_Gastos.API.Models
{
    public class Transacao
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public TipoTransacao Tipo { get; set; }

        public decimal Valor { get; set; }

        public DateTime Vencimento { get; set; }
    
        public DateTime Criacao { get; set; } = DateTime.Now;


        public int CategoriaID { get; set; }

        public Categoria Categoria {get; set;} = null!;


        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; } = null!;

        
}       

}