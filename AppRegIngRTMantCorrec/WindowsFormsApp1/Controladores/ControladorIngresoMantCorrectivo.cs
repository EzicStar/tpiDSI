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

        //loop buscar Asignacion Responsable Tecnico RT que sea del cientifico logueado y que sea vigente
        public AsignacionResponsableTecnicoRT esDeUsuarioLogueadoYVigente()
        {
            //int count = AsignacionResponsableTecnicoRT.
            int length = FakeData.ListaAsignaciones.Count;

            for (int i = 0; i < 2 ; i++)
            {
                if ()
                {

                }
            }
                
        }

    }
}
