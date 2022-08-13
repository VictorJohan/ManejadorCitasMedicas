using Newtonsoft.Json;
using Serilog;

namespace ManejadorCitasMedicas_MCM_.Utils
{
    public class EmailSender
    {

        public string SendMail(Email email)
        {
            System.Net.Mail.MailMessage NetMail = new System.Net.Mail.MailMessage();
            System.Net.Mail.SmtpClient MailClient = new System.Net.Mail.SmtpClient();
            string a = "";
            try
            {
                NetMail.From = new System.Net.Mail.MailAddress(email.Emisor);
                foreach (var item in email.Destinos)
                {
                    NetMail.To.Add(item);
                }
                NetMail.IsBodyHtml = true;
                NetMail.Subject = email.Asunto;
                NetMail.Body = email.Mensaje;
                foreach (var item in email.Adjunto)
                {
                    NetMail.Attachments.Add(item);
                }

                MailClient.Host = email.Host;
                MailClient.Port = email.Puerto;
                MailClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                MailClient.UseDefaultCredentials = email.UsaCredencialesPorDefecto;
                MailClient.EnableSsl = email.UsaSSL;
                MailClient.Credentials = new System.Net.NetworkCredential(email.EmailUser, email.EmailPass);
                MailClient.Send(NetMail);

            }
            catch (Exception ex)
            {
                a = ex.Message;
                Log.Fatal(ex, typeof(EmailSender).Name + "-SendMail\nEmail:" + JsonConvert.SerializeObject(email));
            }
            finally
            {
                NetMail.Dispose();
                MailClient.Dispose();
            }

            return a;
        }

    }
}
