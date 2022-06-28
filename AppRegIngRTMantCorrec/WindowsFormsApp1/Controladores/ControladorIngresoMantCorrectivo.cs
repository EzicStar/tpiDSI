using AplicacionPPAI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionPPAI.Controladores
{
    public class ControladorIngresoMantCorrectivo
    {
         // registrar ingreso de rt en mantenimiento correctivo
        public void RegIngRTMantCorrec()
        {
            ObtenerRespTecnico();
        }

        public PersonalCientifico ObtenerRespTecnico()
        {
            return FakeData.SesionActual.GetPersonalCientif();
        }
    }
}
