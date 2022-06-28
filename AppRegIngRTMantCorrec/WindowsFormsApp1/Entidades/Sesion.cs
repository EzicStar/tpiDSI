using AplicacionPPAI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionPPAI.Models
{
    public class Sesion
    {
        DateTime fechaHoraInicio { get; set; }
        DateTime? fechaHoraFin { get; set; }
        Usuario usuario { get; set; }
        public Sesion(DateTime fechaHoraInicio, DateTime? fechaHoraFin, Usuario usuario)
        {
            this.fechaHoraInicio = fechaHoraInicio;
            this.fechaHoraFin = fechaHoraFin;
            this.usuario = usuario;
        }

        public PersonalCientifico GetPersonalCientif()
        {
            return usuario.GetPersonalCientifico();
        }

    }
}
