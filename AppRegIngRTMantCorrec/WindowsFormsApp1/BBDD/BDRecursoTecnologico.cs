using AplicacionPPAI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.BBDD
{
    public class BDRecursoTecnologico
    {
        public static List<RecursoTecnologico> GetRecursosTecnologicos()
        {
            var rts = new List<RecursoTecnologico>();
            string sentenciaSql = $"SELECT * FROM RecursosTecnologicos";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                var man = MapearRecursoTecnologico(fila);
                rts.Add(man);
            }

            return rts;
        }

        public static List<RecursoTecnologico> GetRecursosTecnologicosResp(int leg, DateTime fecha)
        {
            var fechint = fecha.Year * 10000 + fecha.Month * 100 + fecha.Day;
            var rts = new List<RecursoTecnologico>();
            string sentenciaSql = $"SELECT * FROM RecursosTecnologicos WHERE LegajoCient = {leg} AND FechaDesdeAsign = {fechint}";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                var man = MapearRecursoTecnologico(fila);
                rts.Add(man);
            }

            return rts;
        }

        public static List<RecursoTecnologico> GetRecursosTecnologicosResp(int leg, int fechint)
        {
            var rts = new List<RecursoTecnologico>();
            string sentenciaSql = $"SELECT * FROM RecursosTecnologicos WHERE LegajoCient = {leg} AND FechaDesdeAsign = {fechint}";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                var man = MapearRecursoTecnologico(fila);
                rts.Add(man);
            }

            return rts;
        }

        public static List<RecursoTecnologico> GetRecursosTecnologicosResp(AsignacionResponsableTecnicoRT art)
        {
            var rts = new List<RecursoTecnologico>();
            string sentenciaSql = $"SELECT * FROM RecursosTecnologicos WHERE LegajoCient = {art.GetLegajo()} AND FechaDesdeAsign = {art.GetFechaHoraDesde()}";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                var man = MapearRecursoTecnologico(fila);
                rts.Add(man);
            }

            return rts;
        }


        private static RecursoTecnologico MapearRecursoTecnologico(DataRow fila)
        {
            int nroRT = Convert.ToInt32(fila["nroRT"].ToString());
            string imag = fila["imagenes"].ToString();
            int per = Convert.ToInt32(fila["periodicidadMantPrev"].ToString());
            int dur = Convert.ToInt32(fila["duracionMantPrev"].ToString());
            int frac = Convert.ToInt32(fila["fraccionHorarioTurno"].ToString());
            TipoRT trt = BDTipoRT.GetTipoRT(fila["nombreTipoRT"].ToString());
            DateTime falta = DateTime.ParseExact(fila["fechaAlta"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
            Modelo mod = BDModelo.GetModelo(fila["nombreModelo"].ToString(), fila["nombreMarca"].ToString());
            List<Mantenimiento> mants = BDMantenimiento.GetMantenimientosRT(nroRT);
            List<CambioEstadoRT> cest = BDCambioEstadoRT.GetCambiosEstadoRT(nroRT);
            List<Turno> listur = BDTurno.GetTurnosRT(nroRT);
            RecursoTecnologico mant = new RecursoTecnologico(nroRT, falta, imag, per, dur, frac, trt, mod, mants, cest, listur);

            return mant;
        }
    }
}
