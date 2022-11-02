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
    public class BDMantenimiento
    {
        public static List<Mantenimiento> GetMantenimientos()
        {
            var mants = new List<Mantenimiento>();
            string sentenciaSql = $"SELECT * FROM Mantenimientos";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                var man = MapearMantenimiento(fila);
                mants.Add(man);
            }

            return mants;
        }

        public static Mantenimiento GetMantenimientoPorDia(DateTime fecha)
        {
            var fechint = fecha.Year * 10000 + fecha.Month * 100 + fecha.Day;
            var mant = new Mantenimiento(new DateTime(0000, 00, 00), new DateTime(0000, 00, 00), null);
            string sentenciaSql = $"SELECT * FROM Mantenimientos WHERE fechaInicio = {fechint}";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                mant = MapearMantenimiento(fila);
            }

            return mant;
        }
        public static List<Mantenimiento> GetMantenimientosRT(int nroRT)
        {
            var mants = new List<Mantenimiento>();
            string sentenciaSql = $"SELECT * FROM Mantenimientos WHERE nroRT = {nroRT}";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                var man = MapearMantenimiento(fila);
                mants.Add(man);
            }

            return mants;
        }

        private static Mantenimiento MapearMantenimiento(DataRow fila)
        {
            DateTime fini = DateTime.ParseExact(fila["fechaInicio"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
            DateTime ffin = DateTime.ParseExact(fila["fechaFin"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
            string motivo = fila["motivoMantenimiento"].ToString();
            Mantenimiento mant = new Mantenimiento(fini, ffin, motivo);

            return mant;
        }
    }
}
