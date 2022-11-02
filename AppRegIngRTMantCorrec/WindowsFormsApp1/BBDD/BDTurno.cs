using AplicacionPPAI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.BBDD
{
    public class BDTurno
    {
        public static List<Turno> GetTurnos()
        {
            var turs = new List<Turno>();
            string sentenciaSql = $"SELECT * FROM Turnos";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                var tur = MapearTurno(fila);
                turs.Add(tur);
            }

            return turs;
        }
        public static List<Turno> GetTurnos(int leg, DateTime fecha)
        {
            var fechint = fecha.Year * 10000 + fecha.Month * 100 + fecha.Day;
            var turs = new List<Turno>();
            string sentenciaSql = $"SELECT * FROM Turnos WHERE legajoCientifico = {leg} AND fechaHoraDesdeAsign = {fechint}";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                var tur = MapearTurno(fila);
                turs.Add(tur);
            }

            return turs;
        }

        
        public static List<Turno> GetTurnosRT(int nroRT)
        {
            var mant = new List<Turno>();
            string sentenciaSql = $"SELECT * FROM Turnos WHERE nroRT = {nroRT}";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                var man = MapearTurno(fila);
                mant.Add(man);
            }

            return mant;
        }

        private static Turno MapearTurno(DataRow fila)
        {
            int id = Convert.ToInt32(fila["idTurno"].ToString());
            int dia = Convert.ToInt32(fila["diaSemana"].ToString());
            DateTime fgen = DateTime.ParseExact(fila["fechaGeneracion"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
            DateTime fhi = DateTime.ParseExact(fila["fechaHoraInicio"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
            DateTime fhf = DateTime.ParseExact(fila["fechaHoraFin"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
            List<CambioEstadoTurno> listur = BDCambioEstadoTurno.GetCambiosEstadoTurno(id);
            AsignacionCientificoDelCI asig = BDAsignacionCientificoDelCI.GetAsignacionCientificoDelCI(Convert.ToInt32(fila["legajoCientifico"].ToString()), DateTime.ParseExact(fila["fechaHoraDesdeAsign"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture));
            Turno mant = new Turno(id, fgen, dia, fhi, fhf, listur, asig);

            return mant;
        }
    }
}
