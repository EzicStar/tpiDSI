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
    public class BDAsignacionCientificoDelCI
    {
        public static List<AsignacionCientificoDelCI> GetAsignacionesCientificoDelCI()
        {
            var asigs = new List<AsignacionCientificoDelCI>();
            string sentenciaSql = $"SELECT * FROM AsignacionesCientificoDelCI";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                var man = MapearAsignacionCientificoDelCI(fila);
                asigs.Add(man);
            }

            return asigs;
        }

        public static AsignacionCientificoDelCI GetAsignacionCientificoDelCIActual(int leg)
        {
            var asig = new AsignacionCientificoDelCI(new DateTime(0000, 00, 00), new DateTime(0000, 00, 00), null, null);
            string sentenciaSql = $"SELECT * FROM AsignacionesCientificoDelCI WHERE LegajoCientifico = {leg} AND fechaHoraHasta IS NULL";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                asig = MapearAsignacionCientificoDelCI(fila);
            }

            return asig;
        }

        public static AsignacionCientificoDelCI GetAsignacionCientificoDelCI(int leg, DateTime fecha)
        {
            var fechint = fecha.Year * 10000 + fecha.Month * 100 + fecha.Day;
            var asig = new AsignacionCientificoDelCI(new DateTime(0000, 00, 00), new DateTime(0000, 00, 00), null, null);
            string sentenciaSql = $"SELECT * FROM AsignacionesCientificoDelCI WHERE LegajoCientifico = {leg} AND fechaHoraDesde = {fechint}";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                asig = MapearAsignacionCientificoDelCI(fila);
            }

            return asig;
        }

        private static AsignacionCientificoDelCI MapearAsignacionCientificoDelCI(DataRow fila)
        {
            PersonalCientifico pers = BDPersonalCientifico.GetPersonalCientifico(Convert.ToInt32(fila["LegajoCientifico"].ToString()));
            DateTime fhd = DateTime.ParseExact(fila["fechaHoraDesde"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
            DateTime fhh = DateTime.ParseExact(fila["fechaHoraHasta"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
            List<Turno> listur = BDTurno.GetTurnos(pers.GetLegajo(), fhd);
            AsignacionCientificoDelCI mant = new AsignacionCientificoDelCI(fhd, fhh, pers, listur);

            return mant;
        }
    }
}
