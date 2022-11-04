using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionPPAI.Models
{
    public class Mantenimiento
    {
        private DateTime? fechaInicioPrevista;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private string motivoMantenimiento;

        public DateTime GetFechaInicio() { return fechaInicio; }
        public DateTime GetFechaFin() { return fechaFin; }
        public string GetMotivo() { return motivoMantenimiento; }

        // CAMBIO aca se le pasaba la de inicio y la seteaba al de prevista xd
        public Mantenimiento(DateTime fechaInicio, DateTime fechaFin,  string motivoMantenimiento)
        {
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.motivoMantenimiento = motivoMantenimiento;
        }

    }
}
