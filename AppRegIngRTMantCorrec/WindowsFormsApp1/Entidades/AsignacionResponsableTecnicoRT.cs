using AplicacionPPAI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionPPAI.Models
{
    public class AsignacionResponsableTecnicoRT
    {
        private DateTime fechaHoraDesde;
        private DateTime? fechaHoraHasta;
        private PersonalCientifico personalCientifico;
        private List<RecursoTecnologico> recursosTecnologicos;

        public DateTime GetFechaHoraDesde() { return fechaHoraDesde; }
        public int GetLegajo() { return personalCientifico.GetLegajo(); }

        public AsignacionResponsableTecnicoRT(DateTime fechaHoraDesde, DateTime? fechaHoraHasta, PersonalCientifico personalCientifico, List<RecursoTecnologico> recursosTecnologicos)
        {
            this.fechaHoraDesde = fechaHoraDesde;
            this.fechaHoraHasta = fechaHoraHasta;
            this.personalCientifico = personalCientifico;
            this.recursosTecnologicos = recursosTecnologicos;
        }

        // verifica si la asignacion es la mas reciente, es decir no tiene fecha hasta
        public bool EsVigente()
        {
            if (fechaHoraHasta == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // devuelve true si el cientifico es el mismo que el pasado por parametro y la asignacion
        // sigue vigente
        public bool EsUsuarioLogueadoYVigente(PersonalCientifico cientifAComparar)
        {
            if (personalCientifico.Equals(cientifAComparar) && EsVigente() == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // lista los recursos tecnologicos que tiene a cargo el responsable tecnico
        // a diferencia del diagrama de secuencia, aca retornamos los objetos tipo RT en vez
        // de una cadena de strings para que el rt pueda manipular despues el seleccionado
        public List<RecursoTecnologico> MisRTDisponibles()
        {
            List<RecursoTecnologico> recursosDisponibles = new List<RecursoTecnologico>();
            foreach (RecursoTecnologico recurso in recursosTecnologicos)
            {
                if (recurso.EstaDisponible())
                {
                    recursosDisponibles.Add(recurso);
                }
            }
            return recursosDisponibles;
        }
    }
}
