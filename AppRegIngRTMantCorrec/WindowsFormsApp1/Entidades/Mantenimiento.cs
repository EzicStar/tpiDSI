using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionPPAI.Models
{
    public class Mantenimiento
    {
        DateTime fechaInicio { get; set; }
        DateTime fechaFin { get; set; }
        string motivoMantenimiento { get; set; }
        public Mantenimiento(DateTime fechaInicio, DateTime fechaFin,  string motivoMantenimiento)
        {
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.motivoMantenimiento = motivoMantenimiento;
        }

    }
}
