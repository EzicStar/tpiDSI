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
    public class BDAsignacionResponsableTecnicoRT
    {
        public static List<AsignacionResponsableTecnicoRT> GetAsignacionesResponsableTecnicoRT()
        {
            var asigs = new List<AsignacionResponsableTecnicoRT>();
            string sentenciaSql = $"SELECT * FROM AsignacionesResponsableTecnico";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                var man = MapearAsignacionResponsableTecnicoRT(fila);
                asigs.Add(man);
            }

            return asigs;
        }

        private static AsignacionResponsableTecnicoRT MapearAsignacionResponsableTecnicoRT(DataRow fila)
        {
            PersonalCientifico pers = BDPersonalCientifico.GetPersonalCientifico(Convert.ToInt32(fila["LegajoCientifico"].ToString()));
            DateTime fhd = DateTime.ParseExact(fila["fechaHoraDesde"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
            DateTime fhh = DateTime.ParseExact(fila["fechaHoraHasta"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
            List<RecursoTecnologico> recList = BDRecursoTecnologico.GetRecursosTecnologicosResp(pers.GetLegajo(), Convert.ToInt32(fhd));
            AsignacionResponsableTecnicoRT mant = new AsignacionResponsableTecnicoRT(fhd, fhh, pers, recList);

            return mant;
        }
    }
}
