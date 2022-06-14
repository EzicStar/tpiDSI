using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WindowsFormsApp1.Entidades;

namespace AplicacionPPAI.Models
{
    public class RecursoTecnologico
    {
         int nroRT { get; set; }
         DateTime fechaAlta { get; set; }          
         string imagenes { get; set; }
         int perioricidadMantPrev { get; set; }
         int duracionMantPrev { get; set; }
         string fraccionHorarioTurno { get; set; }
         TipoRT tipoRT { get; set; }
         Modelo modelo { get; set; }
         List<Mantenimiento> mantenimientos { get; set; }
         List<CambioEstadoRT> cambioEstadoRT { get; set; }
         List<Turno> turnos { get; set; }
         public RecursoTecnologico(int nroRT, DateTime fechaAlta, string imagenes, int perioricidadMantPrev, int duracionMantPrev, string fraccionHorarioTurno, TipoRT tipoRT, Modelo modelo, List<Mantenimiento> mantenimientos, List<CambioEstadoRT> cambioEstadoRT, List<Turno> turnos)
        {
            this.nroRT = nroRT;
            this.fechaAlta = fechaAlta;
            this.imagenes = imagenes;
            this.perioricidadMantPrev = perioricidadMantPrev;
            this.duracionMantPrev = duracionMantPrev;
            this.fraccionHorarioTurno = fraccionHorarioTurno;
            this.tipoRT = tipoRT;
            this.modelo = modelo;
            this.mantenimientos = mantenimientos;
            this.cambioEstadoRT = cambioEstadoRT;
            this.turnos = turnos;
        }
        public bool esDisponible()
        {
            foreach (CambioEstadoRT cambioestado in cambioEstadoRT)
            {
                if (cambioestado.EsVigente())
                {
                    return cambioestado.EsDisponible();
                }
            }
            return false;
        } 
        public void EnMantenimientoCorrectivo(Estado estado, DateTime fechaInicio, DateTime fechaHasta, string motivo)
        {
            foreach(Turno turno in turnos)
            {
                if (turno.EsEnPeriodo(fechaHasta))
                {
                    turno.CancelarPorMantenimientoCorrectivo(estado);
                }
            }
            var mantenimientoNew = new Mantenimiento(fechaInicio, fechaHasta, motivo);
            mantenimientos.Add(mantenimientoNew);
        }
    }
}
