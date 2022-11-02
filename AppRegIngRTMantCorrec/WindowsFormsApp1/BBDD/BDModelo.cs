using AplicacionPPAI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.BBDD
{
    public class BDModelo
    {
        public static List<Modelo> GetModelos()
        {
            var rts = new List<Modelo>();
            string sentenciaSql = $"SELECT * FROM Modelos";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                var man = MapearModelo(fila);
                rts.Add(man);
            }

            return rts;
        }

        public static List<Modelo> GetModelosPorMarca(string mar)
        {
            var rts = new List<Modelo>();
            string sentenciaSql = $"SELECT * FROM Modelos WHERE Marca = \"{mar}\"";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                var man = MapearModelo(fila);
                rts.Add(man);
            }

            return rts;
        }
        public static List<Modelo> GetModelosPorMarca(Marca m)
        {
            string mar = m.MostrarMarca();
            var rts = new List<Modelo>();
            string sentenciaSql = $"SELECT * FROM Modelos WHERE Marca = \"{mar}\"";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                var man = MapearModelo(fila);
                rts.Add(man);
            }

            return rts;
        }

        public static Modelo GetModelo(string nom, string mar)
        {
            Modelo marca = new Modelo(null, null);
            string sentenciaSql = $"SELECT * FROM Modelos WHERE Nombre = \"{nom}\" AND Marca = \"{mar}\"";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                marca = MapearModelo(fila);
            }

            return marca;
        }
        public static Modelo GetModelo(string nom, Marca m)
        {
            string mar = m.MostrarMarca();
            Modelo marca = new Modelo(null, null);
            string sentenciaSql = $"SELECT * FROM Modelos WHERE Nombre = \"{nom}\" AND Marca = \"{mar}\"";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                marca = MapearModelo(fila);
            }

            return marca;
        }

        private static Modelo MapearModelo(DataRow fila)
        {
            string nom = fila["Nombre"].ToString();
            Marca mar = BDMarca.GetMarca(fila["Marca"].ToString());
            Modelo mant = new Modelo(nom, mar);

            return mant;
        }
    }
}
