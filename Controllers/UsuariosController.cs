using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.HttpResponse;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        // GET: api/usuarios/{id}
        [HttpGet("{id}")]
        public UsuarioResponse ObterPelaId(Guid id)
        {
            // Implementação da consulta de um usuário.
            return new UsuarioResponse
            {
                Id = Guid.NewGuid(),
                Nome = "Willian",
                Sobrenome = "Sant Anna",
                Endereco = new EnderecoResponse
                {
                    Logradouro = "Rua Toriba",
                    Bairro = "Colégio",
                    Municipio = "Rio de Janeiro",
                    Estado = "Rio de Janeirio",
                    Cep = "21545260"
                }
            };
        }
        // PUT: api/usuarios/{id}
        [HttpPut("{id}")]
        public void AtualizarPelaId(Guid id)
        {

        }
        // DELETE: api/usuarios/{id}
        [HttpDelete("{id}")]
        public void DeletarPelaId(Guid id)
        {

        }
    }
}
