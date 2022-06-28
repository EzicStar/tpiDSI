using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionPPAI.Models
{
    public class FakeData
    {
        // CIENTIFICOS
        public static PersonalCientifico Cientifico1 { get; set; } = new PersonalCientifico(738734, "ernesto", "Ambrosini",
                                                43524643, "erniInst@gmail.com", "erni@gmail.com", 27842387, UsuarioLogueado); 
        
        //USUARIOS
        public static Usuario UsuarioLogueado { get; set; } = new Usuario("Gandalf", "asdfasdf", true, Cientifico1);

        //SESIONES
        public static Sesion SesionActual { get; set; } = new Sesion(new DateTime(),
                                                                     null, UsuarioLogueado);

        //MODELOS
        public static Modelo Modelo1 { get; set; } = new Modelo("Casio");

        //TIPO RT
        public static TipoRT TipoRT1 { get; set; } = new TipoRT("Microscopio", "hace zoom");

        //MANTENIMIENTOS
        public static Mantenimiento Mant1 { get; set; } = new Mantenimiento(new DateTime(), new DateTime(), "me pinto");
        public static Mantenimiento Mant2 { get; set; } = new Mantenimiento(new DateTime(), new DateTime(), "lo rompi");
        List<Mantenimiento> mantenimientos = new List<Mantenimiento> { Mant1, Mant2 };

        //ESTADOS
        //public static Estado Estado1 { get; set; } = new Estado();



        //CAMBIOS ESTADOS
        //public static CambioEstadoRT CambioEstadoRT1 { get; set; } = new CambioEstadoRT(new DateTime(), new DateTime(), );
        //public static CambioEstadoRT CambioEstadoRT2 { get; set; } = new CambioEstadoRT();

        //RECURSOS TECNOLOGICOS
        //public static RecursoTecnologico Rec1 { get; set; } = new RecursoTecnologico(12, new DateTime(), "hola.jpg", 12, 1, "nose", 
        //  TipoRT1, Modelo1, null, null, null);

        //ASIGNACIONES RESPONSABLES RT
        //public static AsignacionResponsableTecnicoRT[] Asignaciones { get; set; } = new AsignacionResponsableTecnicoRT(new DateTime(),
        //                                                                      null, Cientifico1,  );
    }
}
