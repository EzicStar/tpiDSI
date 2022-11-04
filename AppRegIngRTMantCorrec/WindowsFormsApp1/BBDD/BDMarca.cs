using AplicacionPPAI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.BBDD
{
    public class BDMarca
    {
        public static List<Marca> GetMarcas()
        {
            var rts = new List<Marca>();
            string sentenciaSql = $"SELECT * FROM Marcas";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                var man = MapearMarca(fila);
                rts.Add(man);
            }

            return rts;
        }
        public static Marca GetMarca(string nom)
        {
            Marca marca = new Marca(null);
            string sentenciaSql = $"SELECT * FROM Marcas WHERE Nombre = \"{nom}\"";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                marca = MapearMarca(fila);
            }

            return marca;
        }

        private static Marca MapearMarca(DataRow fila)
        {
            string nom = fila["Nombre"].ToString();
            //List<Modelo> modList = BDModelo.GetModelosPorMarca(nom);
            Marca mant = new Marca(nom, null);

            return mant;
        }
    }
}
