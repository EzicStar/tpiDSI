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
        private Marca marca;

       public Modelo(string nombre, Marca marca)
        {
            this.nombre = nombre;
            this.marca = marca;
        }
        public string[] MostrarModeloYMarca()
        {
            string[] modeloYMarca = { nombre, marca.MostrarMarca() };
            return modeloYMarca;
        }
    }
}
