namespace Models.HttpRequests
{
    public class EnderecoRequest 
    {
        public Guid Id { get; set; }
        public required string Logradouro { get; set; }
        public string? Numero {  get; set; }
        public string? Complemento { get; set; }
        public required string Bairro { get; set; }
        public required string Municipio { get; set; }
        public required string Estado {  get; set; }
        public required string Cep { get; set; }
    }
    public class UsuarioRequest
    {
        public Guid Id { get; set;}
        public required string Nome { get; set; }
        public required string Sobrenome { get; set; }
        public required CredencialRequest Credencial { get; set; }
        public required EnderecoRequest Endereco { get; set; }
    }
}