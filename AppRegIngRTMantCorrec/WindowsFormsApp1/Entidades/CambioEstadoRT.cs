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
        public CambioEstadoRT(DateTime fechaHoraDesde, DateTime fechaHoraHasta, Estado estado)
        {
            this.fechaHoraDesde = fechaHoraDesde;
            this.fechaHoraHasta = fechaHoraHasta;
            this.estado = estado;
        }
        public string MostrarCambioEstadoRT()
        {
            return estado.MostrarEstado();
        }
        public bool EsVigente()
        {
            DateTime fechaActual = DateTime.Now;
            if ((fechaActual >= fechaHoraDesde) && (fechaActual <= fechaHoraHasta))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool EsDisponible() => estado.EsDisponible();

        public void Finalizar(Estado estado)
        {
            this.fechaHoraHasta = DateTime.Now;
            this.estado = estado;
        }
    }
}
