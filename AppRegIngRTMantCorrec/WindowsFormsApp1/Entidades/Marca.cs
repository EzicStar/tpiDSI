using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Entidades
{
    public class Marca
    {
        string nombre { get; set; }
        List<Modelo> modelos { get; set; }

        public Marca(string nombre, List<Modelo> modelos)
        {
            this.nombre = nombre;
            this.modelos = modelos;
        }
        public string MostrarMarca()
        {
            return this.nombre;
        }
    }
}
