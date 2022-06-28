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

        public AsignacionResponsableTecnicoRT ObtenerRespTecnico()
        {
            PersonalCientifico personalCientif = FakeData.SesionActual.GetPersonalCientif();

            int lenAsig = FakeData.ListaAsignaciones.Count;
            for (int i = 0; i < lenAsig; i++)
            {
                if (FakeData.ListaAsignaciones[i].EsUsuarioLogueadoYVigente(personalCientif) == true)
                {
                    return FakeData.ListaAsignaciones[i];
                }
            }
            return null;
        }

    }
}
