using ManejadorCitasMedicas_MCM_.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace ManejadorCitasMedicas_MCM_.BLL
{
    public class UsuarioBLL
    {
        private SanVicentePaulDBContext _contexto { get; set; }

        public UsuarioBLL(SanVicentePaulDBContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<Usuarios> GetUsuario(string usuario, string contraseña)
        {
            try
            {
                var user = await _contexto.Usuarios.Where(u => u.NombreUsuario == usuario && u.Contrasena == contraseña).SingleOrDefaultAsync();

                return user;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"{typeof(UsuarioBLL).Name}-CredencialesValidas");
                return null;
            }
        }
    }
}
