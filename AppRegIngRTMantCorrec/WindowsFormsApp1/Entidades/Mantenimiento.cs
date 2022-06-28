using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionPPAI.Models
{
    public class Mantenimiento
    {
        private DateTime fechaInicioPrevista;
        private DateTime fechaInicio;
        private DateTime? fechaFin;
        private string motivoMantenimiento;
        public Mantenimiento(DateTime fechaInicio, DateTime? fechaFin,  string motivoMantenimiento)
        {
            this.fechaInicioPrevista = fechaInicio;
            this.fechaFin = fechaFin;
            this.motivoMantenimiento = motivoMantenimiento;
        }

    }
}
