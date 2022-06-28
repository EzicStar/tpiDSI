using AplicacionPPAI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace AplicacionPPAI.Models
{
    public class InterfazCorreoElectronico
    {
        public void GenerarMailPorMantenimientoCorrectivo(List<string> mails, string mensaje)
        {
            Console.WriteLine("Enviando Mail");
            using (MailMessage msgMail = new MailMessage())
            {
                foreach (string mail in mails)
                {
                    msgMail.From = new MailAddress("francoambrosini1470@gmail.com");
                    msgMail.To.Add(mail); //ACA MAIL DESTINO
                    msgMail.Subject = "Cancelacion turno"; //ASUNTO
                    msgMail.Body = "<h1>" + mensaje + "</h1>"; //TEXTO
                    msgMail.IsBodyHtml = true;
                    //mail.Attachments.Add(new Attachment("C:\\file.zip")); //esto para adjuntar un archivo

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("francoambrosini1470@gmail.com", "dhwcjxwsowqbxach");
                        smtp.EnableSsl = true;
                        smtp.Send(msgMail);
                    }
                }
            }
            return;
        }
    }
}