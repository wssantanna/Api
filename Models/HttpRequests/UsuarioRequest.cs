namespace Models.HttpRequests
{
    public class Endereco 
    {
        public required string Logradouro { get; set; }
        public string? Numero {  get; set; }
        public string? Complemento { get; set; }
        public required string Bairro { get; set; }
        public required string Municipio { get; set; }
        public required string Estado {  get; set; }
        public required string Cep { get; set; }
    }
    public class Credencial
    {
        public required string Email { get; set; }
        public required string Senha { get; set; }
    }
    public class UsuarioRequest
    {
        public required string Nome { get; set; }
        public required string Sobrenome { get; set; }
        public required Credencial Credencial { get; set; }
        public required Endereco Endereco { get; set; }
    }
}