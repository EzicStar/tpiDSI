using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionPPAI.Models
{
    public class Mantenimiento
    {
        DateTime fechaFin { get; set; }
        DateTime fechaInicio { get; set; }
        DateTime fechaInicioPrevista { get; set; }
        string motivoMantenimiento { get; set; }
        public Mantenimiento(DateTime fechaFin, DateTime fechaInicio, DateTime fechaInicioPrevista, string motivoMantenimiento)
        {
            this.fechaFin = fechaFin;
            this.fechaInicio = fechaInicio;
            this.fechaInicioPrevista = fechaInicioPrevista;
            this.motivoMantenimiento = motivoMantenimiento;
        }
    }
}
