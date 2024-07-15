using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("tb_enderecos")]
public class Endereco 
{
    [Key]
    [Column("id_endereco")]
    public Guid Id { get; set; }
    [Required]
    [MaxLength(100)]
    [Column("logradouro")]
    public string Logradouro { get; set; }
    [MaxLength(10)]
    [Column("numero")]
    public string? Numero {  get; set; }
    [MaxLength(50)]
    [Column("complemento")]
    public string? Complemento { get; set; }
    [Required]
    [MaxLength(100)]
    [Column("bairro")]
    public string Bairro { get; set; }
    [Required]
    [MaxLength(100)]
    [Column("municipio")]
    public string Municipio { get; set; }
    [Required]
    [MaxLength(100)]
    [Column("estado")]
    public string Estado {  get; set; }
    [Required]
    [MaxLength(8)]
    [Column("cep")]
    public string Cep { get; set; }
    public Usuario Usuario { get; set; }
}