using AplicacionPPAI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Entidades
{
    public class AsignacionResponsableTecnicoRT
    {
        DateTime fechaHoraDesde { get; set; }
        DateTime fechaHoraHasta { get; set; }
        PersonalCientifico personalCientifico { get; set; }
        List<RecursoTecnologico> recursosTecnologicos { get; set; }
        public AsignacionResponsableTecnicoRT(DateTime fechaHoraDesde, DateTime fechaHoraHasta, PersonalCientifico personalCientifico, List<RecursoTecnologico> recursosTecnologicos)
        {
            this.fechaHoraDesde = fechaHoraDesde;
            this.fechaHoraHasta = fechaHoraHasta;
            this.personalCientifico = personalCientifico;
            this.recursosTecnologicos = recursosTecnologicos;
        }

        public bool esVigente()
        {
            DateTime fechaActual = DateTime.Now;
            if ((fechaActual >= fechaHoraDesde) && (fechaActual <= fechaHoraHasta))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool EsUsuarioLogueadoYVigente()
        {
            return personalCientifico.TengoUsuarioHabilitado();
        }
        public List<RecursoTecnologico> misRTDisponibles()
        {
            List<RecursoTecnologico> recursosDisponibles = new List<RecursoTecnologico>();
            foreach (RecursoTecnologico recurso in recursosTecnologicos)
            {
                if (recurso.esDisponible())
                {
                    recursosDisponibles.Add(recurso);
                }
            }
            return recursosDisponibles;
        }
    }
}
