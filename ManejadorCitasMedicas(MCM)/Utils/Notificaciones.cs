using ManejadorCitasMedicas_MCM_.Models;
using System.Net.Mail;

namespace ManejadorCitasMedicas_MCM_.Utils
{
    public class Notificaciones
    {
        private readonly string Host = "https://localhost:7200/api/";

        public void ActivarUsuario(Usuarios usuario)
        {

            string html = "";

            html = "<!DOCTYPE html>" +
                "<html lang=\"en\">" +
                "<head>" +
                "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">" +
                "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">" +
                "</head>" +
                "<body>" +
                "<div style=\"padding: 2;\">" +
                 $"<p><b>Nombres:</b> {usuario.Nombre}<br><b>Apellidos:</b> {usuario.Apellido}<br><b>Usuario:</b> {usuario.NombreUsuario}<br><b>Fecha:</b> {usuario.FechaCreacion.ToString("dd/MM/yyyy hh:ss tt")}<br><br></p>" +
                $"<a href=\"{Host}usuario/activar?id={usuario.UsuarioId}\" target=\"_blank\" style=\"cursor: pointer; background-color: #199319;color: white; padding: 5px; text-decoration: none;\">Activar Usuario</a><br><br><br><br><br><br>" +
                "</div>" +
                "</body>" +
                "</html>";

            Enviar(html, $"Solicitud de Activación");
        }

        private void Enviar(string html, string asunto)
        {
            var email = new Email();
            email.Asunto = asunto;
            email.Mensaje = html;

            email.Destinos.Add(new MailAddress("johandev23@gmail.com"));

            new EmailSender().SendMail(email);
        }
    }
}
