using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionPPAI.Models
{
    public class PersonalCientifico
    {
        private int legajo;
        private string nombre;
        private string apellido;
        private int nroDocumento;
        private string correoInsti;
        private string correoPersonal;
        private int telefono;
        private string usuario;

        public int GetLegajo() { return legajo; }

        public string GetUsuario() { return usuario; }
        public PersonalCientifico(int legajo, string nombre, string apellido, int nroDocumento, string correoInsti, string correoPersonal, int telefono, string usuario)
        {
            this.legajo = legajo;
            this.nombre = nombre;
            this.apellido = apellido;
            this.nroDocumento = nroDocumento;
            this.correoInsti = correoInsti;
            this.correoPersonal = correoPersonal;
            this.telefono = telefono;
            this.usuario = usuario;
        }
        //public bool TengoUsuarioHabilitado() => usuario.EsHabilitado();

        public string[] MostrarCientifico()
        {
            string[] datos = { legajo.ToString(), nombre, apellido, nroDocumento.ToString(), correoInsti, correoPersonal, telefono.ToString() };
            return datos;
        }
    }
}
