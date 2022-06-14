using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionPPAI.Models
{
    public class PersonalCientifico
    {
        int legajo { get; set; }
        string nombre { get; set; }
        string apellido { get; set; }
        int nroDocumento { get; set; }
        string correoInsti { get; set; }
        string correoPersonal { get; set; }
        int telefono { get; set; }
        Usuario usuario { get; set; }
        public PersonalCientifico(int legajo, string nombre, string apellido, int nroDocumento, string correoInsti, string correoPersonal, int telefono, Usuario usuario)
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
        public bool TengoUsuarioHabilitado() => usuario.EsHabilitado();
    }
}
