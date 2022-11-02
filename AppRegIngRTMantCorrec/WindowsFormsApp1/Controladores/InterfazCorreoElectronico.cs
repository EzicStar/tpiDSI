using AplicacionPPAI.Models;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Controladores;

namespace AplicacionPPAI.Models
{
    public class InterfazCorreoElectronico : IObservador
    {
        public void Notificar(int[] telefonos, string[] mails, string asunto, string mensaje)
        {
            //concatenamos el array de mails en un string separado por coma, que es como lo requiere la api que se encarga
            string strMails = String.Join(",", mails);
            GenerarMailPorMantenimientoCorrectivo(strMails, mensaje, asunto);
        }

        private void GenerarMailPorMantenimientoCorrectivo(string mails, string mensaje, string asunto)
        {
            Console.WriteLine("Enviando Mail");
            using (MailMessage msgMail = new MailMessage())
            {
                msgMail.From = new MailAddress("francoambrosini1470@gmail.com");
                msgMail.To.Add(mails); //ACA MAIL DESTINO
                msgMail.Subject = "Cancelacion turno"; //ASUNTO
                msgMail.Body = "<h1>" + mensaje + "</h1>"; //TEXTO
                msgMail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("C:\\file.zip")); //esto para adjuntar un archivo

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("francoambrosini1470@gmail.com", "iiejvrwqqxvhfxja");
                    smtp.EnableSsl = true;
                    smtp.Send(msgMail);
                }
                
            }
            return;
        }
    }
}