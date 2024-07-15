using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        // api/contas/autenticar
        [HttpPost("autenticar")]
        public void Autenticar(Credencial credencial) {
            
        }
    }
}
