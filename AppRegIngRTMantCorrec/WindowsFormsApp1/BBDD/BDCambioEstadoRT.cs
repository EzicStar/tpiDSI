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
    public class BDCambioEstadoRT
    {
        public static List<CambioEstadoRT> GetCambiosEstadoRT()
        {
            var cambest = new List<CambioEstadoRT>();
            string sentenciaSql = $"SELECT * FROM CambioEstadoRT";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                var tipo = MapearCambioEstadoRT(fila);
                cambest.Add(tipo);
            }

            return cambest;
        }
        public static List<CambioEstadoRT> GetCambiosEstadoRT(int nroRT)
        {
            var cambest = new List<CambioEstadoRT>();
            string sentenciaSql = $"SELECT * FROM CambioEstadoRT WHERE nroRT = \"{nroRT}\"";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                var tipo = MapearCambioEstadoRT(fila);
                cambest.Add(tipo);
            }

            return cambest;
        }
        public static List<CambioEstadoRT> GetCambioEstadoRT(int nroRT, DateTime fecha)
        {
            var fechint = fecha.Year * 10000 + fecha.Month * 100 + fecha.Day;
            var cambest = new List<CambioEstadoRT>();
            string sentenciaSql = $"SELECT * FROM CambioEstadoRT WHERE nroRT = \"{nroRT}\" AND ({fechint} BETWEEN fechaHoraDesde AND fechaHoraHasta OR (({fechint} > fechaHoraDesde) AND fechaHoraHasta IS NULL))";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                var tipo = MapearCambioEstadoRT(fila);
                cambest.Add(tipo);
            }

            return cambest;
        }
        public static List<CambioEstadoRT> GetCambioEstadoRT(DateTime fecha)
        {
            var fechint = fecha.Year * 10000 + fecha.Month * 100 + fecha.Day;
            var cambest = new List<CambioEstadoRT>();
            string sentenciaSql = $"SELECT * FROM CambioEstadoRT WHERE ({fechint} BETWEEN fechaHoraDesde AND fechaHoraHasta) OR (({fechint} > fechaHoraDesde) AND fechaHoraHasta IS NULL)";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                var tipo = MapearCambioEstadoRT(fila);
                cambest.Add(tipo);
            }

            return cambest;
        }

        public static CambioEstadoRT GetCambioEstadoRTActual(int nroRT)
        {
            var cambest = new CambioEstadoRT(new DateTime(0000,00,00), null, null);
            string sentenciaSql = $"SELECT * FROM CambioEstadoRT WHERE nroRT = \"{nroRT}\" AND fechaHoraHasta IS NULL";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                cambest = MapearCambioEstadoRT(fila);
            }

            return cambest;
        }

        private static CambioEstadoRT MapearCambioEstadoRT(DataRow fila)
        {
            DateTime fhd = DateTime.ParseExact(fila["fechaHoraDesde"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
            DateTime fhh = DateTime.ParseExact(fila["fechaHoraHasta"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
            Estado est = BDEstado.GetEstado(fila["nombreEstado"].ToString(), "RT");
            CambioEstadoRT cambest = new CambioEstadoRT(fhd, fhh, est);

            return cambest;
        }
    }
}
