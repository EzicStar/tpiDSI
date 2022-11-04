using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionPPAI.Models
{
    public class CambioEstadoTurno
    {
        private DateTime fechaHoraDesde;
        private DateTime? fechaHoraHasta;
        private Estado estado;

        public string GetEstado() { return estado.MostrarEstado(); }
        public DateTime? GetFechaHasta() { return fechaHoraHasta; }

        public CambioEstadoTurno(DateTime fechaHoraDesde, DateTime? fechaHoraHasta, Estado estado)
        {
            this.fechaHoraDesde = fechaHoraDesde;
            this.fechaHoraHasta = fechaHoraHasta;
            this.estado = estado;
        }
        public void Finalizar(DateTime fechaActual)
        {
            fechaHoraHasta = fechaActual;
        }
        public bool EsVigente()
        {
            if (fechaHoraHasta > DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool EsReservadoOPteReserva()
        {
            if (estado != null)
                return estado.EsReservadoOPteReserva();
            return false;
        }
    }
}
