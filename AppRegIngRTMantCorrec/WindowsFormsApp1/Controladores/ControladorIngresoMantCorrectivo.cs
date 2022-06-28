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
            // el objeto asignacion responsable tecnico del correspondiente usuario
            var miAsigRespTec = ObtenerRespTecnico();
            // lista de los recursos tecnologicos disponibles del resp tecnico
            List<RecursoTecnologico> rtsASeleccionar =  miAsigRespTec.MisRTDisponibles();
            List<RecursoTecnologico> rtsOrdenados = OrdenarRTsPorTipo(rtsASeleccionar);
            List<string[]> infoRts = new List<string[]>();
            foreach (RecursoTecnologico rt in rtsOrdenados)
            {
                infoRts.Add(rt.MostrarRT());
            }
            PantIngMantCorrec.MostrarRTASeleccionar(infoRts);
            
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

        //funcion que 
        public List<RecursoTecnologico> OrdenarRTsPorTipo(List<RecursoTecnologico> listaAOrdenar)
        {
            for (int i = 0; i < (listaAOrdenar.Count - 1); i++)
            {
                for (int j = i + 1; j < listaAOrdenar.Count; j++)
                {
                    if (String.Compare(listaAOrdenar[i].MostrarTipoRT(), listaAOrdenar[j].MostrarTipoRT()) >= 1)
                    {
                        RecursoTecnologico temp = listaAOrdenar[i];
                        listaAOrdenar[i] = listaAOrdenar[j];
                        listaAOrdenar[j] = temp;
                    }

                }
            }
            return listaAOrdenar;
        }

    }
}
