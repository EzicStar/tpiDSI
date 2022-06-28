using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionPPAI.Models
{
    public class Modelo 
    {
        private string nombre;

       public Modelo(string nombre)
        {
            this.nombre = nombre;
        }
        public (string, string) MostrarModeloYMarca(Marca marca)
        {
            string nombreMarca = marca.MostrarMarca();
            return (this.nombre, nombreMarca);
        }
    }
}
