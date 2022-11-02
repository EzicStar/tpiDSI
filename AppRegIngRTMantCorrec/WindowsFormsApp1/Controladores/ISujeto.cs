using AplicacionPPAI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Controladores
{
    public interface ISujeto
    {
        void Notificar();
        void Suscribir(IObservador observador);
        void Quitar(IObservador observador);
    }
}
