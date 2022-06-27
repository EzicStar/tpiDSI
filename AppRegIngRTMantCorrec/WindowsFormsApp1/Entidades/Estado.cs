﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionPPAI.Models
{
    public class Estado
    {
        string nombre { get; set; }
        string ambito { get; set; }
        bool esReservable { get; set; }
        bool esCancelable { get; set; }
        public Estado(string nombre, string ambito, bool esReservable, bool esCancelable)
        {
            this.nombre = nombre;
            this.ambito = ambito;
            this.esReservable = esReservable;
            this.esCancelable = esCancelable;
        }
        public string MostrarEstado()
        {
            return this.nombre;
        }
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
            if (!this.esReservable)
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
            if (this.ambito == "RecursoTecnologico")
            {
                return true;
            }
            return false;
        }
        public bool EsConMantenimientoCorrectivo()
        {
            if (this.ambito == "EnMantenimientoCorrectivo")
            {
                return true;
            }
            return false;
        }
        public void Finalizar()
        {
            this.nombre = "Finalizado";
        }
    }
}