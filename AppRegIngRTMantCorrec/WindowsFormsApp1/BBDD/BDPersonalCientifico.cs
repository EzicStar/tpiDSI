using AplicacionPPAI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.BBDD
{
    public class BDPersonalCientifico
    {
        public static List<PersonalCientifico> GetPersonalCientifico()
        {
            var personalCientifico = new List<PersonalCientifico>();
            string sentenciaSql = $"SELECT * FROM PersonalCientifico";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                var pers = MapearPersonalCientifico(fila);
                personalCientifico.Add(pers);
            }

            return personalCientifico;
        }

        public static List<PersonalCientifico> GetTiposRT(PersonalCientifico t)
        {
            var personales = new List<PersonalCientifico>();
            string sentenciaSql = $"SELECT * FROM TiposRT";
            if (t.GetLegajo() != null)
                sentenciaSql += $" WHERE Nombre={t.GetLegajo()}";

            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                var per = MapearPersonalCientifico(fila);
                personales.Add(per);
            }

            return personales;
        }

        public static PersonalCientifico GetPersonalCientifico(int legajo)
        {
            var per = new PersonalCientifico(-1, null, null, -1, null, null, -1, null);
            string sentenciaSql = $"SELECT * FROM PersonalCientifico WHERE Legajo = \"{legajo}\"";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                per = MapearPersonalCientifico(fila);
            }

            return per;
        }

        private static PersonalCientifico MapearPersonalCientifico(DataRow fila)
        {
            int legajo = Convert.ToInt32(fila["Legajo"].ToString());
            string nom = fila["Nombre"].ToString();
            string ape = fila["Apellido"].ToString();
            int ndoc = Convert.ToInt32(fila["nroDocumento"]);
            string corIns = fila["correoInsti"].ToString();
            string corPer = fila["correoPersonal"].ToString();
            int tel = Convert.ToInt32(fila["telefono"].ToString());
            string usr = fila["Usuario"].ToString();
            PersonalCientifico perscie = new PersonalCientifico(legajo, nom, ape, ndoc, corIns, corPer, tel, usr);

            return perscie;
        }
    }
}
