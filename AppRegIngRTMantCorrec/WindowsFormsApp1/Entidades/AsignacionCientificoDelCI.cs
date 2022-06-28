using AplicacionPPAI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionPPAI.Models
{
    public class AsignacionCientificoDelCI
    {
        private DateTime fechaHoraDesde;
        private DateTime? fechaHoraHasta;
        private PersonalCientifico personalCientifico;
        private List<Turno> turnos;

        public AsignacionCientificoDelCI(DateTime fechaHoraDesde, DateTime? fechaHoraHasta, PersonalCientifico personalCientifico, List<Turno> turnos)
        {
            this.fechaHoraDesde = fechaHoraDesde;
            this.fechaHoraHasta = fechaHoraHasta;
            this.personalCientifico = personalCientifico;
            this.turnos = turnos;
        }
    }
}
