using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        


    }
}
