using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionPPAI.Models
{
    public class TipoRT
    {
        public string Nombre { get; set; }
        private string descripcion;
        public TipoRT(string nombre, string descripcion)
        {
            this.Nombre = nombre;
            this.descripcion = descripcion;
        }
    }
}
