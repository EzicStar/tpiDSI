using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace AplicacionPPAI.Models
{
    public class BDConnection
    {
        public static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqliteConn;
            // PONER EL PATH ABSOLUTO HACIA DONDE ESTA LA DB EN TU PC
            String path = "D:\\Github\\tpiDSI\\AppRegIngRTMantCorrec\\WindowsFormsApp1\\BBDD\\PPAIDB.db";
            sqliteConn = new SQLiteConnection("Datasource=" + path + ";Version=3;New=True;Compress=True;");

            try
            {
                sqliteConn.Open();
                Console.WriteLine("HOLAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            }
            catch
            {
                Console.WriteLine("NO ENTROOO");
            }
            return sqliteConn;
        }
        public static void CreateTable(SQLiteConnection conn)
        {
            SQLiteCommand sQLiteCommand;
            String createSQL = "CREATE TABLE SAMPLETABLE(COL1 VARCHAR(28), COL2 INT)";
            sQLiteCommand = conn.CreateCommand();
            sQLiteCommand.CommandText = createSQL;
            sQLiteCommand.ExecuteNonQuery();
        }

        public static void InsertData(SQLiteConnection conn)
        {
            SQLiteCommand sQLiteCommand;
            sQLiteCommand = conn.CreateCommand();
            sQLiteCommand.CommandText = "INSERT INTO SAMPLETABLE(COL1, COL2) VALUES ('Homero', 148);";
            sQLiteCommand.ExecuteNonQuery();
        }

        public static void ReadData(SQLiteConnection conn)
        {
            SQLiteDataReader sqliteReader;
            SQLiteCommand sqliteCommand;
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = "SELECT * FROM SampleTable";
            sqliteReader = sqliteCommand.ExecuteReader();
            while (sqliteReader.Read())
            {
                string readerString = sqliteReader.GetString(0);
                int readerInt = sqliteReader.GetInt32(1);
                Console.WriteLine(readerString);
                Console.WriteLine(readerInt);
            }
            conn.Close();
        }
    }
}
