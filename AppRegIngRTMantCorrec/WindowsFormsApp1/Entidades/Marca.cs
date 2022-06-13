using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Entidades
{
    class Marca
    {
        string nombre { get; set; }
        Modelo[] modelos { get; set; }

        public Marca(string nombre, Modelo[] modelos)
        {
            this.nombre = nombre;
            this.modelos = modelos;
        }
    }
}
