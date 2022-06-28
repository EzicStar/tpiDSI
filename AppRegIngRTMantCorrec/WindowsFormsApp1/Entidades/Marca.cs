using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionPPAI.Models
{
    public class Marca
    {
        private string nombre;
        private List<Modelo> modelos;

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
