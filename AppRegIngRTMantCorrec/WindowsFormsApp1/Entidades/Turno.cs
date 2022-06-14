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
        List<CambioEstadoTurno> cambioEstadoTurno { get; set; }
        public Turno(int idTurno, DateTime fechaGeneracion, int diaSemana, DateTime fechaHoraInicio, DateTime fechaHoraFin, List<CambioEstadoTurno> cambioEstadoTurno)
        {
            this.idTurno = idTurno;
            this.fechaGeneracion = fechaGeneracion;
            this.diaSemana = diaSemana;
            this.fechaHoraInicio = fechaHoraInicio;
            this.fechaHoraFin = fechaHoraFin;
            this.cambioEstadoTurno = cambioEstadoTurno;
        }
        public void CancelarPorMantenimientoCorrectivo(Estado estado)
        {
            var cambioTurnoNew = new CambioEstadoTurno(DateTime.Now, DateTime.MaxValue,estado);
            cambioEstadoTurno.Add(cambioTurnoNew);
            cambioTurnoNew.Finalizar();
        }
        public bool EsEnPeriodo(DateTime fechaHasta)
        {
            if (fechaHasta > this.fechaHoraInicio)
            {
                return true;
            }
            return false;
        }
    }
}
