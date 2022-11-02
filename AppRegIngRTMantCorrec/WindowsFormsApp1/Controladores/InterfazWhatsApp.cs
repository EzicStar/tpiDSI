using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Controladores
{
    public class InterfazWhatsApp : IObservador
    {
        public void Notificar(int[] telefonos, string[] mails, string asunto, string mensaje)
        {
            GenerarMsjPorMantenimientoCorrectivo(telefonos, mensaje);
        }

        private void GenerarMsjPorMantenimientoCorrectivo(int[] telefonos, string mensaje)
        {
            Process myProcess = new Process();

            try
            {
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.FileName = "https://wa.me/3513901979"; // aca irian todos los telefonos
                myProcess.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
