using System;
using System.Data.SQLite;

namespace SQLiteLoggin
{
    public class SqliteInterface
    {
        SQLiteConnection dbConnection;
        Boolean bolDebug = true;
        public string DBError;

        public SqliteInterface()
        {
            try
            {
                if (System.IO.File.Exists("DMS.sqlite"))
                    System.IO.File.Delete("DMS.sqlite");
            }
            catch (System.IO.IOException e)
            {
                DBError = e.Message;
            }

            GenerateDatabase();
            dbConnection = OpenDataBase();
        }



        public void GenerateDatabase()
        {
            if (!System.IO.File.Exists("DMS.sqlite"))
            {
                SQLiteConnection.CreateFile("DMS.sqlite");
            }
        }

        public SQLiteConnection OpenDataBase()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=DMS.sqlite;Version=3;");
            m_dbConnection.Open();

            // Table
            string sql = "CREATE TABLE IF NOT EXISTS  " +
                                "  ActiveKey ( " +
                                "  ID       INTEGER         PRIMARY KEY AUTOINCREMENT, " +
                                "  KeyName  VARCHAR(20) , " +
                                "  Value    INT ," +
                                "  Active   INT             DEFAULT (-1), " +
                                "  RowTime  TIMESTAMP       DEFAULT (datetime('now','localtime')) " +
                                ")";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "CREATE TABLE IF NOT EXISTS  " +
                  "  Debug ( " +
                  "  ID       INTEGER         PRIMARY KEY AUTOINCREMENT, " +
                  "  Modul    VARCHAR(100)   , " +
                  "  KeyName  VARCHAR(500) , " +
                  "  Value    VARCHAR(500)    DEFAULT ('---')  ," +
                  "  Active   INT             DEFAULT(-1)  ," +
                  "  RowTime  TIMESTAMP       DEFAULT (datetime('now','localtime')) " +
                  " )";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "CREATE TABLE IF NOT EXISTS  " +
                  "  Error ( " +
                  "  ID       INTEGER         PRIMARY KEY AUTOINCREMENT, " +
                  "  Modul    VARCHAR(100)   , " +
                  "  KeyName  VARCHAR(500) , " +
                  "  Value    VARCHAR(500)    DEFAULT ('---')  ," +
                  "  Active   INT             DEFAULT(-1)  ," +
                  "  RowTime  TIMESTAMP       DEFAULT (datetime('now','localtime')) " +
                  " )";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();


            return m_dbConnection;
        }

        public void ActiveKey(string Name, string Value)
        {
            Execute("INSERT INTO ActiveKey (  KeyName , Value ) values ('" + Name + "', '" + Value + "')");
        }

        public void Debug(string Name, string Value)
        {
            if (bolDebug == true)
                Execute("INSERT INTO DEBUG ( Modul , KeyName) values ('" + Name + "', '" + Value + "')");
        }

        public void Debug(string Modul, string KeyName, string Value)
        {
            if (bolDebug == true)
                Execute("INSERT INTO DEBUG ( Modul , KeyName, Value) " +
                        "       values ('" + Modul + "','" + KeyName + "', '" + Value + "')");
        }

        public void Error(string Modul, string KeyName, string Value)
        {
            if (bolDebug == true)
                Execute("INSERT INTO Error ( Modul , KeyName, Value) " +
                        "       values ('" + Modul + "','" + KeyName + "', '" + Value + "')");
        }

        public void SetKey(string KeyName, string Value)
        {
            Execute("UPDATE ActiveKey SET Active = 0 WHERE KeyName = '" + KeyName + "'");
            ActiveKey(KeyName, Value);
        }

        public string GetKey(string KeyName)
        {
            string strReturn = "";
            string strSQL = "SELECT  Value FROM ActiveKey WHERE Active = -1 AND KeyName = '" + KeyName + "'";
            SQLiteCommand command = new SQLiteCommand(strSQL, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
                strReturn = reader["Value"].ToString();

            return strReturn;
        }


        public void Execute(string strSQL)
        {
            SQLiteCommand command = new SQLiteCommand(strSQL, dbConnection);
            command.ExecuteNonQuery();
        }

        public void Read(string strSQL = "SELECT * FROM DEBUG")
        {
            SQLiteCommand command = new SQLiteCommand(strSQL, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
                System.Diagnostics.Debug.WriteLine("KeyName: " + reader["KeyName"] +
                                                    "\t Value: " + reader["Value"]);
        }


    }
}
