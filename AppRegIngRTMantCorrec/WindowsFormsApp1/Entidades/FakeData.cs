using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionPPAI.Models
{
    public class FakeData
    {

        public static Usuario UsuarioLogueado { get; set; } = new Usuario("Gandalf", "asdfasdf", true);

        public static Sesion SesionActual { get; set; } = new Sesion(new DateTime(), 
                                                                     null, UsuarioLogueado);
    }
}
