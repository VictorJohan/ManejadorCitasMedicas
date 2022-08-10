using ManejadorCitasMedicas_MCM_.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace ManejadorCitasMedicas_MCM_.Authorization
{
    public class CustomAuth : AuthenticationStateProvider
    {
        public Usuarios User { get; set; } = new();

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            return Task.FromResult(new AuthenticationState(user));
        }


        public void IniciarUsuario(Usuarios _user)
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, _user.NombreUsuario),
                new Claim(ClaimTypes.Role, "Usuario")
            }, "Acceso");
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public void IniciarMedico(Medicos medico)
        {
            var identity = new ClaimsIdentity(new[]
            {
                 new Claim(ClaimTypes.Name, medico.Email),
                 new Claim(ClaimTypes.Role, "Medico")
            }, "Acceso");
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public void Salir()
        {
            User = new();
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}
