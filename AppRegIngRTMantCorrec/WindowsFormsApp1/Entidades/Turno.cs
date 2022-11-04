using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WindowsFormsApp1.BBDD;

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

        public int GetId() { return idTurno; }
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
                // TODO ponerle fecha al cambio estado actual y agregar el nuevo cambio estado
                if (cambioEstado.EsVigente() && cambioEstado.EsReservadoOPteReserva())
                {
                    cambioEstado.Finalizar(fechaActual);
                    BDCambioEstadoTurno.FinalizarCambioEstadoTurno(cambioEstado, idTurno, fechaActual);
                }
            }
            var cambioTurnoNew = new CambioEstadoTurno(fechaActual, null, estado);
            cambioEstadoTurno.Add(cambioTurnoNew);
            BDCambioEstadoTurno.NuevoCambioEstadoTurnoCancelado(cambioTurnoNew, idTurno);
        }
        public bool EsEnPeriodo(DateTime fechaHasta) //acassaa
        {
            //if (this.fechaHoraInicio.Year > 2018)
            if (DateTime.Compare(fechaHasta, this.fechaHoraInicio) > 0 && DateTime.Compare(fechaHoraInicio, DateTime.Now) > 0)//(fechaHasta > this.fechaHoraInicio)
            {
                return true;
            }
            return false;
        }
        public bool EsReservadoOPendienteDeReserva()
        {
            
            foreach (CambioEstadoTurno cambioEstado in cambioEstadoTurno)
            {
                Console.WriteLine("Turno nro: " + idTurno + " y es hasta: " +cambioEstado.GetFechaHasta());
                Console.WriteLine("ES VIGENTE?????? " + cambioEstado.EsVigente());
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
