using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Entidades
{
    public class Modelo
    {
        private string nombre;

        public Modelo(string nombre)
        {
            this.nombre = nombre;
        }

        public string MostrarModelo()
        {
            return nombre;
        }

        public string MostrarMisModelos()
        {
            //TODO: hacer MostrarMisModelos
            return null;
        }
    }
}
