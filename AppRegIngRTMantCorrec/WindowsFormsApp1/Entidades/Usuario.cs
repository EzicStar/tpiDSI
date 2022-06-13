using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionPPAI.Models
{
    public class Usuario
    {
        string usuario { get; set; }
        int clave { get; set; }
        bool habilitado { get; set; }
        public Usuario(string usuario, int clave, bool habilitado)
        {
            this.usuario = usuario;
            this.clave = clave;
            this.habilitado = habilitado;
        }
    }
}
