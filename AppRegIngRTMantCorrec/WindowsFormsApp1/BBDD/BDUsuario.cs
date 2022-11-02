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
    internal class BDUsuario
    {
        public static List<Usuario> GetUsuarios()
        {
            var usuarios = new List<Usuario>();
            string sentenciaSql = $"SELECT * FROM Usuarios";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                var tipo = MapearUsuario(fila);
                usuarios.Add(tipo);
            }

            return usuarios;
        }

        public static Usuario GetUsuario(string usr)
        {
            var usuario = new Usuario(null, null, false, null);
            string sentenciaSql = $"SELECT * FROM Usuarios WHERE Usuario = \"{usr}\"";
            var tablaResultado = BDConnection.ReadData(sentenciaSql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                usuario = MapearUsuario(fila);
            }

            return usuario;
        }

        private static Usuario MapearUsuario(DataRow fila)
        {
            string usr = fila["Usuario"].ToString();
            string clave = fila["Clave"].ToString();
            bool hab = Convert.ToBoolean(Convert.ToInt32(fila["Habilitado"].ToString()));
            PersonalCientifico pers = BDPersonalCientifico.GetPersonalCientifico(Convert.ToInt32(fila["LegajoCientifico"].ToString()));
            Usuario cambest = new Usuario(usr, clave, hab, pers);

            return cambest;
        }
    }
}
