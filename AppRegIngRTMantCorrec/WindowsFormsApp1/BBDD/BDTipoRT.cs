using AplicacionPPAI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;


namespace WindowsFormsApp1.BBDD
{
    public class BDTipoRT
    {
        public static List<TipoRT> GetTiposRT()
        {
            var tiposRT = new List<TipoRT>();
            string sentenciaSql = $"SELECT * FROM TiposRT";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                var tipo = MapearTipoRT(fila);
                tiposRT.Add(tipo);
            }

            return tiposRT;
        }

        public static List<TipoRT> GetTiposRT(TipoRT t)
        {
            var tiposRT = new List<TipoRT>();
            string sentenciaSql = $"SELECT * FROM TiposRT";
            if (t.GetNombre() != null)
                sentenciaSql += $" WHERE Nombre={t.GetNombre()}";
            
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                var tipo = MapearTipoRT(fila);
                tiposRT.Add(tipo);
            }

            return tiposRT;
        }

        public static TipoRT GetTipoRT(string nombre)
        {
            var tipo = new TipoRT(null, null);
            string sentenciaSql = $"SELECT * FROM TiposRT WHERE nombre = \"{nombre}\"";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                tipo = MapearTipoRT(fila);
            }

            return tipo;
        }

        public static void RegistrarTipoRT(TipoRT t)
        {
            var sentenciaSql = $"INSERT INTO TiposRT (nombre, descripcion) VALUES  ( \"{t.GetNombre()}\", \"{t.GetDescripcion()}\")";
            try
            {
                BDConnection.InsertData(sentenciaSql);

                Console.WriteLine("TipoRT registrado con exito!");
            }
            catch
            {
                Console.WriteLine("Error! TipoRT no se pudo registrar...");
            }
        }

        private static TipoRT MapearTipoRT(DataRow fila)
        {
            string desc = fila["Descripcion"].ToString();
            string nom = fila["Nombre"].ToString();
            TipoRT tiport = new TipoRT(nom, desc);

            return tiport;
        }
    }
}
