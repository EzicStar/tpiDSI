using AplicacionPPAI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

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
            //BDConnection.CreateTable(conn);
            //BDConnection.InsertData(conn);
            BDConnection.ReadData(conn);
        }
    }
}
