using AplicacionPPAI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using WindowsFormsApp1.BBDD;
using System.Globalization;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PantIngMantCorrec());
            SQLiteConnection conn = BDConnection.CreateConnection();
        }

        public static Sesion sesionActual = new Sesion(DateTime.ParseExact("20221102", "yyyyMMdd", CultureInfo.InvariantCulture), null, BDUsuario.GetUsuario("Gandalf"));

        //BDConnection.CreateTable(conn);
        //BDConnection.InsertData(conn);
        //BDConnection.ReadData();

        // primera prueba de materializar un tiport de la base
        //TipoRT x = BDTipoRT.GetTipoRT("balanza");
        //Console.WriteLine(x.GetNombre());

        // probando de registrar un nuevo tiport (esto creo que no hay que contemplarlo igual)
        //TipoRT y = new TipoRT("nuevo", "prueba");
        //BDTipoRT.RegistrarTipoRT(y);

        // probando si efectivamente devuelve una lista de personalcientifico y mostrando un legajo
        //List<PersonalCientifico> x = BDPersonalCientifico.GetPersonalCientifico();
        //Console.WriteLine(x[1].GetLegajo());

        // aca probaba la conversion de string a datetime para materializar las fechas de la base
        //string fec = "20221102";
        //DateTime x = DateTime.ParseExact(fec, "yyyyMMdd", CultureInfo.InvariantCulture);


        // esto probaba para ver si la sesion tomaba bien al usuario
        //Console.WriteLine(sesionActual.GetPersonalCientif().GetLegajo());


    }
}
