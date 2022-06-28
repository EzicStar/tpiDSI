using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionPPAI.Models
{
    public class Usuario
    {
        private string usuario;
        private string clave;
        private bool habilitado;
        private PersonalCientifico personal;
        
        public Usuario(string usuario, string clave, bool habilitado, PersonalCientifico personal)
        {
            this.usuario = usuario;
            this.clave = clave;
            this.habilitado = habilitado;
            this.personal = personal;
        }
        public bool EsHabilitado()
        {
            if (this.habilitado)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public PersonalCientifico GetPersonalCientifico()
        {
            return personal;
        }
    }
}
