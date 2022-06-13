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
         Mantenimiento[] mantenimientos { get; set; }
         CambioEstadoRT[] cambioEstadoRT { get; set; }
         Turno[] turnos { get; set; }
         public RecursoTecnologico(int nroRT, DateTime fechaAlta, string imagenes, int perioricidadMantPrev, int duracionMantPrev, string fraccionHorarioTurno, TipoRT tipoRT, Modelo modelo, Mantenimiento[] mantenimientos, CambioEstadoRT[] cambioEstadoRT, Turno[] turnos)
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
    }
}
