
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models 
{
    [Table("tb_usuarios")]
    public class Usuario 
    {
        [Key]
        [Column("id_usuario")]
        public Guid Id { get; set;}
        [Required]
        [MaxLength(50)]
        [Column("nome")]
        public string Nome { get; set;}
        [Required]
        [MaxLength(80)]
        [Column("sobrenome")]
        public string Sobrenome { get; set;}
        [ForeignKey("Endereco")]
        [Column("id_endereco")]
        public Guid EnderecoId { get; set;}
        public Credencial Credencial { get; set;}
        public Endereco Endereco { get; set;}
    }
}