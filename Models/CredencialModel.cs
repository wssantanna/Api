using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models 
{
    [Table("tb_credenciais")]
    public class Credencial 
    {
        [Key]
        [Column("id_credencial")]
        public Guid Id { get; set; }

        [Required]
        [Column("email")]
        public string Email { get; set; }
        
        [Required]
        [MaxLength(10)]
        [Column("senha")]
        public string Senha { get; set; }
        [ForeignKey("Usuario")]
        [Column("id_usuario")]
        public Guid UsuarioId { get; set; }
        
        public Usuario Usuario { get; set; }
    }
}