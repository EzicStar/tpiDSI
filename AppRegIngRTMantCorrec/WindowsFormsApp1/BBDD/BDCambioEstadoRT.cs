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

        public static void NuevoCambioEstadoRTCorrectivo(CambioEstadoRT cam, int nroRT)
        {
            int fechint = cam.GetFechaDesde().Year * 10000 + cam.GetFechaDesde().Month * 100 + cam.GetFechaDesde().Day;
            string sentenciaSql = $"INSERT INTO CambioEstadoRT (nroRT, fechaHoraDesde, fechaHoraHasta, NombreEstado, AmbitoEstado) VALUES ({nroRT}, {fechint}, 20221231, \"Cancelado\", \"RT\")";
            BDConnection.InsertData(sentenciaSql);
        }

        public static void FinalizarCambioEstadoRT(CambioEstadoRT cam, int nroRT, DateTime fechaHasta)
        {
            int fechintHasta = fechaHasta.Year * 10000 + fechaHasta.Month * 100 + fechaHasta.Day;
            int fechintDesde = cam.GetFechaDesde().Year * 10000 + cam.GetFechaDesde().Month * 100 + cam.GetFechaDesde().Day;
            string sentenciaSql = $"UPDATE CambioEstadoRT SET FechaHoraHasta = {fechintHasta} WHERE nroRT = {nroRT} AND FechaHoraDesde = {fechintDesde}";
            BDConnection.UpdateData(sentenciaSql);
            Console.WriteLine("FECHA HASTA A LA TABLA: " + fechintHasta);
            Console.WriteLine("FECHA DESDE A LA TABLA: " + fechintDesde);

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
