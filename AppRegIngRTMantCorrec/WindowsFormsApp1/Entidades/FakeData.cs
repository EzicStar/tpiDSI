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

        public static PersonalCientifico Cientifico2 { get; set; } = new PersonalCientifico(738147, "Germán", "Vélez",
                                                43524643, "assadsaasd@hotmail.com", "germanevelez@hotmail.com", 2894723, UserCientifico2);

        public static PersonalCientifico Cientifico3 { get; set; } = new PersonalCientifico(80903, "Juan", "Perez",
                                                717812, "juanInst@gmail.com", "pablo@gmail.com", 32534, UserCientifico3);
        public static PersonalCientifico Cientifico4 { get; set; } = new PersonalCientifico(738734, "Ernesto", "Ambrosini",
                                                43524643, "erniInst@gmail.com", "erni@gmail.com", 27842387, UserCientifico4);

        // ASIGNACION CIENTIFICO DEL CI
        public static AsignacionCientificoDelCI AsignacionC1 { get; set; } = new AsignacionCientificoDelCI(new DateTime(), null, Cientifico1, TurnosRT1);
        public static AsignacionCientificoDelCI AsignacionC2 { get; set; } = new AsignacionCientificoDelCI(new DateTime(), null, Cientifico2, TurnosRT2);
        public static AsignacionCientificoDelCI AsignacionC3 { get; set; } = new AsignacionCientificoDelCI(new DateTime(), null, Cientifico3, TurnosRT2);
        public static AsignacionCientificoDelCI AsignacionC4 { get; set; } = new AsignacionCientificoDelCI(new DateTime(), null, Cientifico4, TurnosRT2);

        //USUARIOS
        public static Usuario UserCientifico1 { get; set; } = new Usuario("Gandalf", "asdfasdf", true, Cientifico1); //----------------------------------
        public static Usuario UserCientifico2 { get; set; } = new Usuario("pablo1", "829dufhweiru", true, Cientifico2);
        public static Usuario UserCientifico3 { get; set; } = new Usuario("Juancho", "8rwr4u", true, Cientifico3);
        public static Usuario UserCientifico4 { get; set; } = new Usuario("PANA", "ROCHA", true, Cientifico4);

        //SESIONES
        public static Sesion SesionActual { get; set; } = new Sesion(new DateTime(), null, UserCientifico1);

        //MARCA
        public static Marca Marca1 { get; set; } = new Marca("gucci", ListaModelos1);
        public static Marca Marca2 { get; set; } = new Marca("Polo");

        //MODELOS
        public static Modelo Modelo1 { get; set; } = new Modelo("Casio", Marca1);
        public static Modelo Modelo2 { get; set; } = new Modelo("HyperX", Marca1);
        public static Modelo Modelo3 { get; set; } = new Modelo("Logitech", Marca2);

        //LISTA DE MODELOS
        static List<Modelo> ListaModelos1 = new List<Modelo> { Modelo1, Modelo2 };
        static List<Modelo> ListaModelos2 = new List<Modelo> { Modelo3, Modelo2 };

        //TIPO RT
        public static TipoRT TipoRT1 { get; set; } = new TipoRT("Microscopio", "hace zoom");
        public static TipoRT TipoRT2 { get; set; } = new TipoRT("balanza", "pesa");
        public static TipoRT TipoRT3 { get; set; } = new TipoRT("medidor", "mide");

        //MANTENIMIENTOS
        public static Mantenimiento Mant1 { get; set; } = new Mantenimiento(new DateTime(), new DateTime(), "me pinto");
        public static Mantenimiento Mant2 { get; set; } = new Mantenimiento(new DateTime(), new DateTime(), "lo rompi");
        public static Mantenimiento Mant3 { get; set; } = new Mantenimiento(new DateTime(), new DateTime(), "repestos");
        public static Mantenimiento Mant4 { get; set; } = new Mantenimiento(new DateTime(), new DateTime(), "cambiar baterias");

        //LISTA DE MANTENIMIENTOS
        static List<Mantenimiento> mantenimientosRec1 = new List<Mantenimiento> { Mant1, Mant2 };
        static List<Mantenimiento> mantenimientosRec2 = new List<Mantenimiento> { Mant1, Mant3 };
        static List<Mantenimiento> mantenimientosRec3 = new List<Mantenimiento> { Mant4, Mant1 };

        //ESTADOS

        //ESTADOS RT
        public static Estado DisponibleRT { get; set; } = new Estado("Disponible", "RT", false, false, "desc");
        public static Estado HabilitadoRT { get; set; } = new Estado("Habilitado", "RT", false, false, "desc");
        public static Estado DeBajaRT { get; set; } = new Estado("Dado de Baja", "RT", false, false, "desc");
        public static Estado EnMantPreventivoRT { get; set; } = new Estado("En mantenimiento preventivo", "RT", false, false, "desc");
        public static Estado EnMantCorrectivoRT { get; set; } = new Estado("En mantenimiento correctivo", "RT", false, false, "desc");

        //ESTADOS TURNO
        public static Estado DisponibleTurno { get; set; } = new Estado("Disponible", "Turno", true, true, "desc"); // todo: modificar es reservable,
        public static Estado ReservadoTurno { get; set; } = new Estado("Reservado", "Turno", true, true, "desc");
        public static Estado GeneradoTurno { get; set; } = new Estado("Generado", "Turno", true, true, "desc");
        public static Estado CanceladoTurno { get; set; } = new Estado("Cancelado", "Turno", true, true, "desc");
        public static Estado EnAnalisisTurno { get; set; } = new Estado("En analisis", "Turno", true, true, "desc");
        public static Estado FinSinUsoTurno { get; set; } = new Estado("Fin sin Uso", "Turno", true, true, "desc");
        public static Estado AnuladoTurno { get; set; } = new Estado("Anulado", "Turno", true, true, "desc");
        public static Estado FinalizadoTurno { get; set; } = new Estado("Finalizado", "Turno", true, true, "desc");

        //LISTA DE TODOS LOS ESTADOS 
        public static Estado[] Listaestados = { DisponibleTurno, HabilitadoRT, DeBajaRT, EnMantPreventivoRT, EnMantCorrectivoRT, DisponibleTurno, ReservadoTurno, GeneradoTurno, CanceladoTurno, EnAnalisisTurno, FinSinUsoTurno, AnuladoTurno, FinalizadoTurno };

        //CAMBIOS ESTADOS
        //CAMBIO ESTADO RT
        public static CambioEstadoRT CambioEstadoRT1 { get; set; } = new CambioEstadoRT(new DateTime(2022, 6, 27), null, DisponibleRT);
        public static CambioEstadoRT CambioEstadoRT2 { get; set; } = new CambioEstadoRT(new DateTime(2022, 6, 27), new DateTime(2022, 6, 27), HabilitadoRT);
        public static CambioEstadoRT CambioEstadoRT4 { get; set; } = new CambioEstadoRT(new DateTime(2022, 6, 27), new DateTime(2022, 6, 27), EnMantCorrectivoRT);
        public static CambioEstadoRT CambioEstadoRT5 { get; set; } = new CambioEstadoRT(new DateTime(2022, 6, 29), new DateTime(2022, 6, 27), EnMantPreventivoRT);
        //CAMBIO ESTADO TURNO
        public static CambioEstadoTurno cambioEstadoT1 { get; set; } = new CambioEstadoTurno(new DateTime(2022, 6, 29),
            new DateTime(2022, 6, 27), DisponibleTurno);
        public static CambioEstadoTurno cambioEstadoT2 { get; set; } = new CambioEstadoTurno(new DateTime(2022, 6, 29), null,
            ReservadoTurno);
        public static CambioEstadoTurno cambioEstadoT3 { get; set; } = new CambioEstadoTurno(new DateTime(2022, 6, 29), new DateTime(2022, 6, 27),
            GeneradoTurno);
        public static CambioEstadoTurno cambioEstadoT4 { get; set; } = new CambioEstadoTurno(new DateTime(2022, 6, 29), new DateTime(2022, 6, 27),
            CanceladoTurno);
        public static CambioEstadoTurno cambioEstadoT5 { get; set; } = new CambioEstadoTurno(new DateTime(2022, 6, 29), new DateTime(),
          EnAnalisisTurno);
        public static CambioEstadoTurno cambioEstadoT6 { get; set; } = new CambioEstadoTurno(new DateTime(2022, 6, 29), new DateTime(),
        FinSinUsoTurno);
        public static CambioEstadoTurno cambioEstadoT7 { get; set; } = new CambioEstadoTurno(new DateTime(2022, 6, 29), new DateTime(),
        AnuladoTurno);
        public static CambioEstadoTurno cambioEstadoT8 { get; set; } = new CambioEstadoTurno(new DateTime(2022, 6, 29), new DateTime(),
        FinalizadoTurno);
        public static CambioEstadoTurno cambioEstadoT9 { get; set; } = new CambioEstadoTurno(new DateTime(2022, 6, 29), null,
        EnAnalisisTurno);
        public static CambioEstadoTurno cambioEstadoT10 { get; set; } = new CambioEstadoTurno(new DateTime(2022, 6, 29), null,
        ReservadoTurno);


        //LISTA DE CAMBIO ESTADO RT
        static List<CambioEstadoRT> cambioEstadoRTsRec1 = new List<CambioEstadoRT> { CambioEstadoRT1, CambioEstadoRT2, CambioEstadoRT4 };
        static List<CambioEstadoRT> cambioEstadoRTsRec2 = new List<CambioEstadoRT> { CambioEstadoRT1, CambioEstadoRT4 };
        static List<CambioEstadoRT> cambioEstadoRTsRec3 = new List<CambioEstadoRT> { CambioEstadoRT1, CambioEstadoRT4, CambioEstadoRT5 };

        //CAMBIO ESTADO TURNO
        static List<CambioEstadoTurno> cambioEstadoTurno1 = new List<CambioEstadoTurno> { cambioEstadoT1, cambioEstadoT2 };
        static List<CambioEstadoTurno> cambioEstadoTurno2 = new List<CambioEstadoTurno> { cambioEstadoT3, cambioEstadoT2, cambioEstadoT4 };
        static List<CambioEstadoTurno> cambioEstadoTurno3 = new List<CambioEstadoTurno> { cambioEstadoT1, cambioEstadoT7, cambioEstadoT2 };
        static List<CambioEstadoTurno> cambioEstadoTurno4 = new List<CambioEstadoTurno> { cambioEstadoT1, cambioEstadoT6, cambioEstadoT7, cambioEstadoT9 };
        static List<CambioEstadoTurno> cambioEstadoTurno5 = new List<CambioEstadoTurno> { cambioEstadoT1, cambioEstadoT6, cambioEstadoT7, cambioEstadoT2 };
        static List<CambioEstadoTurno> cambioEstadoTurno6 = new List<CambioEstadoTurno> { cambioEstadoT10, cambioEstadoT6, cambioEstadoT7 };
        //TURNOS  
        public static Turno Turno1 { get; set; } = new Turno(12, new DateTime(2022, 6, 29), 3, new DateTime(2022, 6, 29), new DateTime(2022, 6, 29), cambioEstadoTurno1, AsignacionC1);
        public static Turno Turno2 { get; set; } = new Turno(22, new DateTime(2022, 6, 29), 4, new DateTime(2022, 6, 29), new DateTime(2022, 6, 29), cambioEstadoTurno2, AsignacionC3);
        public static Turno Turno3 { get; set; } = new Turno(4, new DateTime(2022, 6, 30), 3, new DateTime(2022, 6, 30), new DateTime(2022, 6, 30), cambioEstadoTurno3, AsignacionC2);
        public static Turno Turno4 { get; set; } = new Turno(4, new DateTime(2022, 6, 30), 3, new DateTime(2022, 6, 30), new DateTime(2022, 6, 30), cambioEstadoTurno4, AsignacionC3);
        public static Turno Turno5 { get; set; } = new Turno(4, new DateTime(2022, 7, 5), 3, new DateTime(2022, 6, 10), new DateTime(2022, 6, 10), cambioEstadoTurno5, AsignacionC1);
        public static Turno Turno6 { get; set; } = new Turno(4, new DateTime(2022, 7, 15), 3, new DateTime(2022, 7, 5), new DateTime(2022, 7, 5), cambioEstadoTurno6, AsignacionC2);
        public static Turno Turno7 { get; set; } = new Turno(4, new DateTime(2022, 7, 15), 3, new DateTime(2022, 7, 10), new DateTime(2022, 7, 10), cambioEstadoTurno2, AsignacionC4);
        public static Turno Turno8 { get; set; } = new Turno(4, new DateTime(2022, 7, 15), 3, new DateTime(2022, 7, 15), new DateTime(2022, 7, 15), cambioEstadoTurno3, AsignacionC4);

        // LISTA DE TURNOS
        static List<Turno> TurnosRT1 = new List<Turno> { Turno3, Turno5, Turno6 };
        static List<Turno> TurnosRT2 = new List<Turno> { Turno1, Turno2, Turno3, Turno4, Turno5, Turno6, Turno7, Turno8 };


        //RECURSOS TECNOLOGICOS
        public static RecursoTecnologico Rec1 { get; set; } = new RecursoTecnologico(12, new DateTime(2019, 5, 11), "hola.jpg", 12, 1, "nose",
        TipoRT1, Modelo1, mantenimientosRec1, cambioEstadoRTsRec1, TurnosRT1);
        public static RecursoTecnologico Rec2 { get; set; } = new RecursoTecnologico(32, new DateTime(2019, 5, 11), "pep.jpg", 32, 4, "nose",
            TipoRT2, Modelo3, mantenimientosRec2, cambioEstadoRTsRec2, TurnosRT2);
        public static RecursoTecnologico Rec3 { get; set; } = new RecursoTecnologico(22, new DateTime(2019, 5, 11), "pep.jpg", 32, 4, "nose",
            TipoRT3, Modelo2, mantenimientosRec2, cambioEstadoRTsRec2, TurnosRT2);
        public static RecursoTecnologico Rec4 { get; set; } = new RecursoTecnologico(40, new DateTime(2019, 5, 11), "pep.jpg", 32, 4, "nose",
            TipoRT3, Modelo1, mantenimientosRec2, cambioEstadoRTsRec2, TurnosRT2);

        // LISTA DE RECURSOS TECNOLOGICOS
        static List<RecursoTecnologico> ListaRec1 { get; set; } = new List<RecursoTecnologico> { Rec1, Rec2, Rec3, Rec4 };
        static List<RecursoTecnologico> ListaRec2 { get; set; } = new List<RecursoTecnologico> { Rec2 };

        //ASIGNACIONES RESPONSABLES RT
        public static AsignacionResponsableTecnicoRT AsignacionRT1Cient1 { get; set; } = new AsignacionResponsableTecnicoRT(new DateTime(2021, 7, 5),
            null, Cientifico1, ListaRec1);

        public static AsignacionResponsableTecnicoRT AsignacionRT1Cient2 { get; set; } = new AsignacionResponsableTecnicoRT(new DateTime(2020, 4, 10),
           null, Cientifico2, ListaRec2);

        // LISTA ASIGNACIONES
        public static List<AsignacionResponsableTecnicoRT> ListaAsignaciones { get; set; } = new List<AsignacionResponsableTecnicoRT>
             { AsignacionRT1Cient1, AsignacionRT1Cient2};
    }
}