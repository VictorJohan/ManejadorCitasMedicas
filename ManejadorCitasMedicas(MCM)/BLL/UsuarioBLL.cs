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
                var user = await _contexto.Usuarios
                    .Where(u => u.NombreUsuario == usuario && u.Contrasena == contraseña && u.Activo == true)
                    .SingleOrDefaultAsync();

                return user;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"{typeof(UsuarioBLL).Name}-CredencialesValidas");
                return null;
            }
        }

        public async Task<bool> Registrar(Usuarios usuario)
        {
            try
            {
                usuario.FechaCreacion = DateTime.Now;
                usuario.FechaModificacion = DateTime.Now;
                await _contexto.Usuarios.AddAsync(usuario);

                return await _contexto.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {

                Log.Fatal(ex, $"{typeof(UsuarioBLL).Name}-Registrar");
                return false;
            }
        }

        public async Task<bool> NombreUsuarioDisponible(string nombre)
        {
            try
            {
                return await _contexto.Usuarios.AnyAsync(u => u.NombreUsuario == nombre);
            }
            catch (Exception ex)
            {

                Log.Fatal(ex, $"{typeof(UsuarioBLL).Name}-NombreUsuarioDisponible");
                return true;
            }
        }

        public async Task<bool> ActivarUsuario(int id)
        {
            try
            {
                var usuario = _contexto.Usuarios.Find(id);
                usuario!.Activo = true;
                _contexto.Entry(usuario).State = EntityState.Modified;
                return await _contexto.SaveChangesAsync() > 0; 
            }
            catch (Exception ex)
            { 
                Log.Fatal(ex, $"{typeof(UsuarioBLL).Name}-ActivarUsuario");
                return true;
            }
        }
    }
}
