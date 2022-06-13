using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionPPAI.Models
{
    public class Turno
    {
         int idTurno { get; set; }
         DateTime fechaGeneracion { get; set; }
         int diaSemana { get; set; }
         DateTime fechaHoraInicio { get; set; }
         DateTime fechaHoraFin { get; set; }
         CambioEstadoTurno[] cambioEstadoTurno { get; set; }
    }
}
