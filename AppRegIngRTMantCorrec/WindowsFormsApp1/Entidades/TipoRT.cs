using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionPPAI.Models
{
    public class TipoRT
    {
        private string nombre;
        private string descripcion;
        public TipoRT(string nombre, string descripcion)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
        }

        public string GetNombre()
        {
            return nombre;  
        }
        
        public string GetDescripcion()
        {
            return descripcion; 
        }
    }
}
