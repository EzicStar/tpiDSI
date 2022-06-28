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
        public static PersonalCientifico Cientifico1 { get; set; } = new PersonalCientifico(738734, "Ernesto", "Ambrosini",
                                                43524643, "erniInst@gmail.com", "erni@gmail.com", 27842387, UserCientifico1);

        public static PersonalCientifico Cientifico2 { get; set; } = new PersonalCientifico(738147, "Pablo", "Rosas",
                                                43524643, "pabloInct@gmail.com", "rositas@gmail.com", 2894723, UserCientifico2);

        //USUARIOS
        public static Usuario UserCientifico1 { get; set; } = new Usuario("Gandalf", "asdfasdf", true, Cientifico1);
        public static Usuario UserCientifico2 { get; set; } = new Usuario("pablo1", "829dufhweiru", true, Cientifico2);

        //SESIONES
        public static Sesion SesionActual { get; set; } = new Sesion(new DateTime(), null, UserCientifico1);

        //MODELOS
        public static Modelo Modelo1 { get; set; } = new Modelo("Casio", new Marca("Kawai"));

        //TIPO RT
        public static TipoRT TipoRT1 { get; set; } = new TipoRT("Microscopio", "hace zoom");

        //MANTENIMIENTOS
        public static Mantenimiento Mant1 { get; set; } = new Mantenimiento(new DateTime(), new DateTime(), "me pinto");
        public static Mantenimiento Mant2 { get; set; } = new Mantenimiento(new DateTime(), new DateTime(), "lo rompi");
        
            //LISTA DE MANTENIMIENTOS
            static List<Mantenimiento> mantenimientosRec1 = new List<Mantenimiento> { Mant1, Mant2 };

        //ESTADOS
        public static Estado VigenteRT { get; set; } = new Estado("Vigente", "RT", false, false, "desc");
        public static Estado HabilitadoRT { get; set; } = new Estado("Habilitado", "RT", false, false, "desc");
        public static Estado DisponibleTurno { get; set; } = new Estado("Disponible", "Turno", true, true, "desc");
        public static Estado ReservadoTurno { get; set; } = new Estado("Disponible", "Turno", true, true, "desc");

        //CAMBIOS ESTADOS
        public static CambioEstadoRT CambioEstadoRT1 { get; set; } = new CambioEstadoRT(new DateTime(), new DateTime(), VigenteRT);
        public static CambioEstadoRT CambioEstadoRT2 { get; set; } = new CambioEstadoRT(new DateTime(), new DateTime(), HabilitadoRT);
        public static CambioEstadoTurno cambioEstadoT1 { get; set; } = new CambioEstadoTurno(new DateTime(), new DateTime(), 
            DisponibleTurno);
        public static CambioEstadoTurno cambioEstadoT2 { get; set; } = new CambioEstadoTurno(new DateTime(), new DateTime(), 
            ReservadoTurno);
       
            //LISTA DE CAMBIO ESTADO
            static List<CambioEstadoRT> cambioEstadoRTsRec1 = new List<CambioEstadoRT> { CambioEstadoRT1, CambioEstadoRT2};
            static List<CambioEstadoTurno> cambioEstadoTurno1 = new List<CambioEstadoTurno> {cambioEstadoT1, cambioEstadoT2};

        //TURNOS
        public static Turno Turno1 { get; set; } = new Turno(12, new DateTime(), 3, new DateTime(), new DateTime(), cambioEstadoTurno1);

            // LISTA DE TURNOS
            static List<Turno> TurnosRT1 = new List<Turno> { Turno1 };


        //RECURSOS TECNOLOGICOS
        public static RecursoTecnologico Rec1 { get; set; } = new RecursoTecnologico(12, new DateTime(), "hola.jpg", 12, 1, "nose",
        TipoRT1, Modelo1, mantenimientosRec1, cambioEstadoRTsRec1, TurnosRT1);

        public static RecursoTecnologico Rec2 { get; set; } = new RecursoTecnologico(32, new DateTime(), "pep.jpg", 32, 4, "nose",
            TipoRT1, Modelo1, mantenimientosRec1, cambioEstadoRTsRec1, TurnosRT1);

            // LISTA DE RECURSOS TECNOLOGICOS
            static List<RecursoTecnologico> ListaRec1 { get; set; } = new List<RecursoTecnologico> { Rec1 };
            static List<RecursoTecnologico> ListaRec2 { get; set; } = new List<RecursoTecnologico> { Rec2 };

        //ASIGNACIONES RESPONSABLES RT
        public static AsignacionResponsableTecnicoRT AsignacionRT1Cient1 { get; set; } = new AsignacionResponsableTecnicoRT(new DateTime(), 
            null, Cientifico1, ListaRec1);

        public static AsignacionResponsableTecnicoRT AsignacionRT1Cient2 { get; set; } = new AsignacionResponsableTecnicoRT(new DateTime(),
           null, Cientifico2, ListaRec2);

            // LISTA ASIGNACIONES
            public static List<AsignacionResponsableTecnicoRT> ListaAsignaciones { get; set; } = new List<AsignacionResponsableTecnicoRT>
             { AsignacionRT1Cient1, AsignacionRT1Cient2};
    }
}
