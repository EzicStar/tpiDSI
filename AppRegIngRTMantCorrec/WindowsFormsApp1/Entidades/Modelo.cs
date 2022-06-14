using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Entidades
{
    public class Modelo 
    {
        string nombre { get; set; }

        public Modelo()
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
