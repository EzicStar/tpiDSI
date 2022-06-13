using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionPPAI.Models
{
    public class CambioEstadoRT
    {
        DateTime fechaHoraDesde { get; set; }
        DateTime fechaHoraHasta { get; set; }
        Estado estado { get; set; }
    }
}
