using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WindowsFormsApp1.BBDD;

namespace AplicacionPPAI.Models
{
    public class RecursoTecnologico
    {
        // CAMBIO fraccionHorarioTurno era un string

        private int nroRT;
        private DateTime fechaAlta;
        private string imagenes;
        private int perioricidadMantPrev;
        private int duracionMantPrev;
        private int fraccionHorarioTurno;
        private TipoRT tipoRT;
        private Modelo modelo;
        private List<Mantenimiento> mantenimientos;
        private List<CambioEstadoRT> cambioEstadoRT;
        private List<Turno> turnos;

        public RecursoTecnologico(int nroRT, DateTime fechaAlta, string imagenes, int perioricidadMantPrev, int duracionMantPrev, int fraccionHorarioTurno, TipoRT tipoRT, Modelo modelo, List<Mantenimiento> mantenimientos, List<CambioEstadoRT> cambioEstadoRT, List<Turno> turnos)
        {
            this.nroRT = nroRT;
            this.fechaAlta = fechaAlta;
            this.imagenes = imagenes;
            this.perioricidadMantPrev = perioricidadMantPrev;
            this.duracionMantPrev = duracionMantPrev;
            this.fraccionHorarioTurno = fraccionHorarioTurno;
            this.tipoRT = tipoRT;
            this.modelo = modelo;
            this.mantenimientos = mantenimientos;
            this.cambioEstadoRT = cambioEstadoRT;
            this.turnos = turnos;
        }

        public bool EstaDisponible()
        {
            foreach (CambioEstadoRT cambioestado in cambioEstadoRT)
            {
                if (cambioestado.EsVigente())
                {
                    return cambioestado.EsDisponible();
                }
            }
            return false;
        }

        public void EnMantenimientoCorrectivo(Estado estadoCancelado, Estado enMantCorrec, DateTime fechaInicio, DateTime fechaHasta, string motivo)
        {
            foreach (Turno turno in turnos)
            {
                if (turno.EsEnPeriodo(fechaHasta))
                {
                    turno.CancelarPorMantenimientoCorrectivo(estadoCancelado, fechaInicio);
                }
            }
            // TODO aca desmaterializar el mantenimiento
            var mantenimientoNew = new Mantenimiento(fechaInicio, fechaHasta, motivo);
            mantenimientos.Add(mantenimientoNew);

           foreach (CambioEstadoRT cambioEstado in cambioEstadoRT)
            {
                // TODO setea feche de inicio al cambio
                if (cambioEstado.EsVigente())
                {
                    cambioEstado.Finalizar(fechaInicio);
                }
            }

            cambioEstadoRT.Add(new CambioEstadoRT(fechaInicio, null, enMantCorrec));
        }

        public string MostrarTipoRT()
        {
            return tipoRT.GetNombre();
        }

        // devuelve un array con los datos del recurso tecnologico
        public string[] MostrarRT()
        {
            string[] datos = { MostrarTipoRT(),
                               nroRT.ToString(),
                               modelo.MostrarModeloYMarca()[0],
                               modelo.MostrarModeloYMarca()[1] };
            // mostrar modelo y marca retorna un array, por lo que usamos indices para obtener cada uno
            return datos;
        }

        public bool EsMiNum(int num)
        {
            if (num == nroRT)
            {
                return true;
            }
            return false;
        }

        public List<Turno> MostrarTurnosReservadosPorMC(DateTime fechaFinPrevista)
        {
            /*
            List<Turno> ReservadosOPendReserv = new List<Turno>();
            foreach (Turno turno in turnos)
            {
                if (turno.EsEnPeriodo(fechaFinPrevista) && turno.EsReservadoOPendienteDeReserva())
                {
                    ReservadosOPendReserv.Add(turno);
                }
            }
            return ReservadosOPendReserv;
            */

            List<Turno> turnos = BDTurno.GetTurnosRT(nroRT);
            Console.WriteLine("CANTIDAD DE TURNOS DEL RT: " + turnos.Count);
            //List<Turno> turnos = FakeData.TurnosRT1;
            List<Turno> turnosAfectados = new List<Turno>();
            foreach (Turno turno in turnos)
            {
                if (turno.EsReservadoOPendienteDeReserva() && turno.EsEnPeriodo(fechaFinPrevista))
                {
                    turnosAfectados.Add(turno);
                }
            }
            Console.WriteLine("CANTIDAD DE TURNOS AFECTADOS: " + turnosAfectados.Count);
            return turnosAfectados;
        }
    }
}