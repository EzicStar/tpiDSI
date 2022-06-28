﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionPPAI.Models
{
    public class CambioEstadoRT
    {
        private DateTime fechaHoraDesde;
        private DateTime? fechaHoraHasta;
        private Estado estado;

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
            if (fechaHoraHasta == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // verifica si el estado asignado a cambioEstado es disponible
        public bool EsDisponible() => estado.EsDisponible();

        public void Finalizar(Estado estado)
        {
            this.fechaHoraHasta = DateTime.Now;
            this.estado = estado;
        }
    }
}
