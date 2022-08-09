using ManejadorCitasMedicas_MCM_.BLL;
using Microsoft.AspNetCore.Mvc;

namespace ManejadorCitasMedicas_MCM_.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioBLL usuarioBLL;

        public UsuarioController(UsuarioBLL usuarioBLL)
        {
            this.usuarioBLL = usuarioBLL;
        }

        [HttpGet("activar")]
        public async Task<ActionResult> Activar(int id)
        {
            return Ok(await usuarioBLL.ActivarUsuario(id));
        }
    }
}
