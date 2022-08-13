using System.Net.Mail;

namespace ManejadorCitasMedicas_MCM_.Utils
{
    public class Email
    {
        public string Emisor { get; set; }
        public List<MailAddress> Destinos { get; set; } = new List<MailAddress>();
        public string Asunto { get; set; }
        public string Mensaje { get; set; }
        public List<Attachment> Adjunto { get; set; } = new List<Attachment>();
        public bool FormatoHTML { get; set; }
        public string Host { get; set; }
        public int Puerto { get; set; }
        public string EmailUser { get; set; }
        public string EmailPass { get; set; }
        public bool UsaCredencialesPorDefecto { get; set; }
        public bool UsaSSL { get; set; }

        public Email()
        {
            Emisor = "vicjohan23@outlook.com";
            Destinos = new List<MailAddress>();
            Asunto = "";
            Mensaje = "";
            Adjunto = new List<Attachment>();
            FormatoHTML = true;
            Host = "smtp-mail.outlook.com";
            Puerto = 587;
            EmailUser = "vicjohan23@outlook.com";
            EmailPass = "Ci:84568003";
            UsaCredencialesPorDefecto = false;
            UsaSSL = true;
        }
    }
}
