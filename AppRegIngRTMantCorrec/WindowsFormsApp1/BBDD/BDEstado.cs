using AplicacionPPAI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.BBDD
{
    public class BDEstado
    {
        public static List<Estado> GetEstados()
        {
            var estados = new List<Estado>();
            string sentenciaSql = $"SELECT * FROM Estados";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                var tipo = MapearEstado(fila);
                estados.Add(tipo);
            }

            return estados;
        }

        public static List<Estado> GetEstados(Estado t)
        {
            var estados = new List<Estado>();
            string sentenciaSql = $"SELECT * FROM Estados";
            if (t.MostrarEstado() != null)
                sentenciaSql += $" WHERE Nombre={t.MostrarEstado()} AND Ambito={t.GetAmbito()}";

            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                var estado = MapearEstado(fila);
                estados.Add(estado);
            }

            return estados;
        }

        public static Estado GetEstado(string nombre, string ambito)
        {
            var estado = new Estado(null, null, false, false, null);
            string sentenciaSql = $"SELECT * FROM Estados WHERE Nombre = \"{nombre}\" AND Ambito= \"{ambito}\"";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                estado = MapearEstado(fila);
            }

            return estado;
        }

        private static Estado MapearEstado(DataRow fila)
        {
            string amb = fila["Ambito"].ToString();
            string nom = fila["Nombre"].ToString();
            bool esRes = Convert.ToBoolean(Convert.ToInt32(fila["esReservable"].ToString()));
            bool esCan = Convert.ToBoolean(Convert.ToInt32(fila["esCancelable"].ToString()));
            string des = fila["Descripcion"].ToString();
            Estado est = new Estado(nom, amb, esRes, esCan, des);

            return est;
        }
    }
}
