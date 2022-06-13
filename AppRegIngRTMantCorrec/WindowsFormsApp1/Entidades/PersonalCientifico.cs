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

    }
}
