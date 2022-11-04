using AplicacionPPAI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WindowsFormsApp1.BBDD
{
    public class BDCambioEstadoTurno
    {
        public static List<CambioEstadoTurno> GetCambiosEstadoTurno()
        {
            var camturs = new List<CambioEstadoTurno>();
            string sentenciaSql = $"SELECT * FROM CambioEstadoTurno";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                var ct = MapearCambioEstadoTurno(fila);
                camturs.Add(ct);
            }

            return camturs;
        }
        public static List<CambioEstadoTurno> GetCambiosEstadoTurno(int id)
        {
            var camturs = new List<CambioEstadoTurno>();
            string sentenciaSql = $"SELECT * FROM CambioEstadoTurno WHERE idTurno = \"{id}\"";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                var ct = MapearCambioEstadoTurno(fila);
                camturs.Add(ct);
            }

            return camturs;
        }
        public static List<CambioEstadoTurno> GetCambioEstadoTurno(int id, DateTime fecha)
        {
            var fechint = fecha.Year * 10000 + fecha.Month * 100 + fecha.Day;
            var camturs = new List<CambioEstadoTurno>();
            string sentenciaSql = $"SELECT * FROM CambioEstadoTurno WHERE idTurno = \"{id}\" AND ({fechint} BETWEEN fechaHoraDesde AND fechaHoraHasta OR (({fechint} > fechaHoraDesde) AND fechaHoraHasta IS NULL))";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                var ct = MapearCambioEstadoTurno(fila);
                camturs.Add(ct);
            }

            return camturs;
        }
        public static List<CambioEstadoTurno> GetCambioEstadoRT(DateTime fecha)
        {
            var fechint = fecha.Year * 10000 + fecha.Month * 100 + fecha.Day;
            var camturs = new List<CambioEstadoTurno>();
            string sentenciaSql = $"SELECT * FROM CambioEstadoTurno WHERE ({fechint} BETWEEN fechaHoraDesde AND fechaHoraHasta) OR (({fechint} > fechaHoraDesde) AND fechaHoraHasta IS NULL)";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                var ct = MapearCambioEstadoTurno(fila);
                camturs.Add(ct);
            }

            return camturs;
        }

        public static CambioEstadoTurno GetCambioEstadoRTActual(int id)
        {
            var camtur = new CambioEstadoTurno(new DateTime(0000, 00, 00), null, null);
            string sentenciaSql = $"SELECT * FROM CambioEstadoTurno WHERE idTurno = \"{id}\" AND fechaHoraHasta IS NULL";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                camtur = MapearCambioEstadoTurno(fila);
            }

            return camtur;
        }

        public static void NuevoCambioEstadoTurnoCancelado(CambioEstadoTurno cam, int idTurno)
        {
            int fechint = cam.GetFechaHoraDesde().Year * 10000 + cam.GetFechaHoraDesde().Month * 100 + cam.GetFechaHoraDesde().Day;
            string sentenciaSql = $"INSERT INTO CambioEstadoTurno (idTurno, fechaHoraDesde, fechaHoraHasta, NombreEstado, AmbitoEstado) VALUES ({idTurno}, {fechint}, 20221231, \"Cancelado\", \"Turno\")";
            BDConnection.InsertData(sentenciaSql);
        }

        public static void FinalizarCambioEstadoTurno(CambioEstadoTurno cam, int idTurno, DateTime fechaHasta)
        {
            int fechintHasta = fechaHasta.Year * 10000 + fechaHasta.Month * 100 + fechaHasta.Day;
            int fechintDesde = cam.GetFechaHoraDesde().Year * 10000 + cam.GetFechaHoraDesde().Month * 100 + cam.GetFechaHoraDesde().Day;
            string sentenciaSql = $"UPDATE CambioEstadoTurno SET FechaHoraHasta = {fechintHasta} WHERE idTurno = {idTurno} AND FechaHoraDesde = {fechintDesde}";
            BDConnection.UpdateData(sentenciaSql);
        }

        private static CambioEstadoTurno MapearCambioEstadoTurno(DataRow fila)
        {
            CambioEstadoTurno camtur;
            DateTime fhd = DateTime.ParseExact(fila["fechaHoraDesde"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
            try { 
                DateTime fhh = DateTime.ParseExact(fila["fechaHoraHasta"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
                Estado est = BDEstado.GetEstado(fila["nombreEstado"].ToString(), "Turno");
                camtur = new CambioEstadoTurno(fhd, fhh, est);
            }
            catch {
                Estado est = BDEstado.GetEstado(fila["nombreEstado"].ToString(), "Turno");
                camtur = new CambioEstadoTurno(fhd, new DateTime(0001, 01, 01), est);
            }
            

            return camtur;
        }
    }
}
