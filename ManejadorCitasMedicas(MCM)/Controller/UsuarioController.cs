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
        public async Task Activar(int id)
        {
            var res = await usuarioBLL.ActivarUsuario(id);

            if (res)
                Response.Redirect("/listo");


        }
    }
}
