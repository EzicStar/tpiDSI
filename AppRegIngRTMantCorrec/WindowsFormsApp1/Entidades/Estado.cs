using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionPPAI.Models
{
    public class Estado
    {
        private string nombre;
        private string ambito;
        private bool esReservable;
        private bool esCancelable;
        private string descripcion;

        public Estado(string nombre, string ambito, bool esReservable, bool esCancelable, string descripcion)
        {
            this.nombre = nombre;
            this.ambito = ambito;
            this.esReservable = esReservable;
            this.esCancelable = esCancelable;
            this.descripcion = descripcion;
        }
        public string MostrarEstado()
        {
            return this.nombre;
        }

        public string GetAmbito() { return this.ambito; }   
        public bool EsDisponible()
        {
            if (this.nombre == "Disponible")
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
            if (nombre=="Reservado" || nombre == "En analisis")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool EsAmbitoTurno()
        {
            if(this.ambito == "Turno")
            {
                return true;
            }
            return false;
        }
        public bool EsCancelado()
        {
            if (this.nombre == "Cancelado")
            {
                return true;
            }
            return false;
        }
        public bool EsAmbitoRT()
        {
            if (this.ambito == "RT")
            {
                return true;
            }
            return false;
        }
        public bool EsConMantenimientoCorrectivo()
        {
            if (this.nombre == "EnMantenimientoCorrectivo")
            {
                return true;
            }
            return false;
        }
    }
}
