using AplicacionPPAI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AplicacionPPAI.Models
{
    public class InterfazCorreoElectronico
    {
        public void GenerarMailPorMantenimientoCorrectivo(List<string> mail, string mensaje)
        {
            Console.WriteLine("Enviando Mail");
        }
    }
}