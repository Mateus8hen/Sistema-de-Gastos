using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Gastos.API.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public string Descricao { get; set; } = string.Empty;
        
        public DateTime Criacao { get; set; } = DateTime.Now;

        public bool IsAtivo { get; set; } = true;


        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; } = null!;


        public ICollection<Transacao> Transacoes { get; set; } = [];
    
    }
}