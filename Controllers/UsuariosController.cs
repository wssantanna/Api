using Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.HttpResponse;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly LojaDbContext _contexto;
        public UsuariosController(LojaDbContext contexto)
        {
            _contexto = contexto;
        }
        // GET: api/usuarios/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioResponse>> ObterPelaId(Guid id)
        {
            try
            {
                var usuarioQueEstaBuscando = await _contexto.Usuarios
                                                .Include(tabelaUsuario => tabelaUsuario.Endereco)
                                                .FirstOrDefaultAsync(tabelaUsuario => tabelaUsuario.Id == id);

                bool usuarioNaoEncontrado = usuarioQueEstaBuscando == null;
                
                if(usuarioNaoEncontrado)
                {
                    return NotFound();
                }

                return Ok(
                    new UsuarioResponse {
                        Id              = usuarioQueEstaBuscando.Id,
                        Nome            = usuarioQueEstaBuscando.Nome,
                        Sobrenome       = usuarioQueEstaBuscando.Sobrenome,
                        Endereco        = new EnderecoResponse
                        {
                            Logradouro  = usuarioQueEstaBuscando.Endereco.Logradouro,
                            Numero      = usuarioQueEstaBuscando.Endereco.Numero,
                            Complemento = usuarioQueEstaBuscando.Endereco.Complemento,
                            Bairro      = usuarioQueEstaBuscando.Endereco.Bairro,
                            Municipio   = usuarioQueEstaBuscando.Endereco.Municipio,
                            Estado      = usuarioQueEstaBuscando.Endereco.Estado,
                            Cep         = usuarioQueEstaBuscando.Endereco.Cep
                        }
                    }
                );
            }
            catch(Exception){
                return StatusCode(500, "Não foi possível realizar a consulta.");
            }

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
