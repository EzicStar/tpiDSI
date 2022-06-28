using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionPPAI.Models
{
    public class Turno
    {
        private int idTurno;
        private DateTime fechaGeneracion;
        private int diaSemana;
        private DateTime fechaHoraInicio;
        private DateTime fechaHoraFin;
        private List<CambioEstadoTurno> cambioEstadoTurno;
        private AsignacionCientificoDelCI asigCientifico;
        public Turno(int idTurno, DateTime fechaGeneracion, int diaSemana, DateTime fechaHoraInicio, DateTime fechaHoraFin, List<CambioEstadoTurno> cambioEstadoTurno, AsignacionCientificoDelCI asigCientifico)
        {
            this.idTurno = idTurno;
            this.fechaGeneracion = fechaGeneracion;
            this.diaSemana = diaSemana;
            this.fechaHoraInicio = fechaHoraInicio;
            this.fechaHoraFin = fechaHoraFin;
            this.cambioEstadoTurno = cambioEstadoTurno;
            this.asigCientifico = asigCientifico;
        }
        public void CancelarPorMantenimientoCorrectivo(Estado estado, DateTime fechaActual)
        {
            foreach (CambioEstadoTurno cambioEstado in cambioEstadoTurno)
            {
                if (cambioEstado.EsVigente() && cambioEstado.EsReservadoOPteReserva())
                {
                    cambioEstado.Finalizar(fechaActual);
                }
            }
            var cambioTurnoNew = new CambioEstadoTurno(fechaActual, null, estado);
            cambioEstadoTurno.Add(cambioTurnoNew);
        }
        public bool EsEnPeriodo(DateTime fechaHasta)
        {
            if (fechaHasta > this.fechaHoraInicio)
            {
                return true;
            }
            return false;
        }
        public bool EsReservadoOPendienteDeReserva()
        {
            foreach (CambioEstadoTurno cambioEstado in cambioEstadoTurno)
            {
                if (cambioEstado.EsVigente() && cambioEstado.EsReservadoOPteReserva())
                {
                    return true;
                }
            }
            return false;
        }
        public string[] MostrarCientifico()
        {
            return asigCientifico.MostrarCientifico();
        }

        public string[] MostrarTurno()
        {
            string[] datos = { fechaHoraInicio.ToString(), fechaHoraFin.ToString() };
            return datos.Concat(MostrarCientifico()).ToArray();
        }
    }
}
