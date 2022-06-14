using AplicacionPPAI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Entidades
{
    public class AsignacionCientificoDelCI
    {
        DateTime fechaHoraDesde { get; set; }
        DateTime fechaHoraHasta { get; set; }
        PersonalCientifico personalCientifico { get; set; }
        List<Turno> turnos { get; set; }
        public AsignacionCientificoDelCI(DateTime fechaHoraDesde, DateTime fechaHoraHasta, PersonalCientifico personalCientifico, List<Turno> turnos)
        {
            this.fechaHoraDesde = fechaHoraDesde;
            this.fechaHoraHasta = fechaHoraHasta;
            this.personalCientifico = personalCientifico;
            this.turnos = turnos;
        }
    }
}
