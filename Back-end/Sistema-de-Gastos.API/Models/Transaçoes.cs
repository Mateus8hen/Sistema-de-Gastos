using static Sistema_de_Gastos.API.Models.Enums;

namespace Sistema_de_Gastos.API.Models
{
    public class Transaçoes
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public TipoTransacao Tipo { get; set; }

        public decimal Valor { get; set; }


        public ICollection<Categoria> Categorias { get; set; } = [];
        
        public ICollection<Usuario> Usuarios { get; set; } = [];
 }       

}