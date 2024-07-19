using System.Net;
using Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.HttpRequests;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        private readonly LojaDbContext _contexto;
        public ContasController(LojaDbContext contexto)
        {
            _contexto = contexto;
        }
        // POST: api/contas/autenticar
        [HttpPost("autenticar")]
        public void Autenticar(CredencialRequest credencial)
        {

        }
        // Para acessar o recurso a partir do Postman, Insomnia e/ou curl:
        // POST: api/contas/registrar
        [HttpPost("registrar")]
        public async Task<ActionResult> Registrar(
            // Esse parâmetro representa a ficha de cadastro do usuário que 
            // será enviada no corpo da requisição [FromBody].
            //
            // Nota: É recomendável enviar os dados no corpo da requisição 
            // sempre que desejar utilizar do recurso de criptografia do protocolo HTTP.
            [FromBody] UsuarioRequest registroUsuario
        )
        {  
            // Esse techo de código representa o monitoramento do cadastro.
            // Nesse exemplo, precisamos interagir com três tabelas (endereço, usuário e credencial).
            // Se alguma operação gerar erro, podemos desfazer as operações.
            var transacaoDeCadastro = await _contexto.Database.BeginTransactionAsync();

            try 
            {

                // Nesse trecho do código é realizado o cadastro o endereço no banco de dados.
                // Nota: A ficha de cadastro do usuário possui o endereço, porém os dados capturado
                // são estão organizados de uma maneira diferente do tipo utilizado para modelagem no banco de dados.
                // Por este motivo, precisamos realizar uma normalização dos dados.

                // Exemplo Logradouro (banco de dados) = registroUsuario.Endereco.Logradouro (dados da requisição)
                _contexto.Enderecos.Add(new Endereco
                {
                    Logradouro      = registroUsuario.Endereco.Logradouro,
                    Numero          = registroUsuario.Endereco.Numero,
                    Complemento     = registroUsuario.Endereco.Complemento,
                    Bairro          = registroUsuario.Endereco.Bairro,
                    Municipio       = registroUsuario.Endereco.Municipio,
                    Estado          = registroUsuario.Endereco.Estado,
                    Cep             = registroUsuario.Endereco.Cep
                });
                // Após realizar o cadastro do endereço no banco de dados é necessário confirmar
                // a operação para que a operação seja finalizada e os dados registrados.
                await _contexto.SaveChangesAsync();

                _contexto.Usuarios.Add(new Usuario
                {
                    Nome            = registroUsuario.Nome,
                    Sobrenome       = registroUsuario.Sobrenome,
                    EnderecoId      = registroUsuario.Endereco.Id
                });

                await _contexto.SaveChangesAsync();

                _contexto.Credenciais.Add(new Credencial
                {
                    Email           = registroUsuario.Credencial.Email,
                    Senha           = registroUsuario.Credencial.Senha,
                    UsuarioId       = registroUsuario.Id
                });

                await _contexto.SaveChangesAsync();
                // Nesse trecho de código deixamos explícito
                // que estamos finalizando a operação de cadastro do usuário.
                // Obs.: Vale ressaltar que esse comando foi adicionado em trecho
                // deste escopo, em que os dados já foram registrados em todas as tabelas
                // relacionadas - Endereço e Credencial.
                await transacaoDeCadastro.CommitAsync();

                // Após a última operação de registro retornamos
                // o status 200 - Ok, sem mais nenhuma informação no corpo da resposta.
                return Ok();
            }
            catch(Exception)
            {
                // Caso aconteça algum erro, em alguma etapa do cadastro, 
                // os dados cadastrados em alguma entidade serão descartados 
                // permanentemente, e os dados não serão registrados nas tabelas
                // em que não houve um erro durante o processo de registro.
                transacaoDeCadastro.Rollback();
                return StatusCode(500, "Não foi possível realizar o cadastro!");
            }

        }
    }
}
