using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace EroDatabase
{
    class EroDatabaseAdapter
    {
        private SQLiteConnection connection;
        private SQLiteCommand command;
        private SQLiteDataReader dataReader;

        public EroDatabaseAdapter()
        {
            if (!File.Exists("MainDatabase.sqlite"))
            {
                SQLiteConnection.CreateFile("MainDatabase.sqlite");
            }

            connection = new SQLiteConnection("Data Source=MainDatabase.sqlite;Version=3;");
            try
            {
                connection.Open();
            }
            catch (Exception e)
            {
                Environment.Exit(0);
            }

            command = connection.CreateCommand();

            command.CommandText = "CREATE TABLE if not exists mainTable(ID INTEGER PRIMARY KEY, DBSite varchar(10) NULL, DBID int NULL, Circle varchar(50) NULL, Date text NULL, Title varchar(100) UNIQUE NOT NULL, TitleOther varchar(100) NULL, Language varchar(5) NULL, DataType varchar(10) NULL, TitlePath varchar(255) NULL);";
            command.ExecuteNonQuery();
        }

        public string printToConsole(SQLiteDataReader readerDB, int index)
        {
            if (readerDB.IsDBNull(index))
            {
                //return "NULL";
                return "";
            }
            else
            {
                String dataObject = readerDB.GetFieldType(index).ToString();
                switch (dataObject)
                {
                    case "System.Int32":
                        return readerDB.GetInt32(index).ToString();
                    case "System.DateTime":
                        DateTime date = readerDB.GetDateTime(index);
                        return Convert.ToString(date);
                    case "System.String":
                        return readerDB.GetString(index);
                    default:
                        return "Unknown";
                }
            }

        }

        public void selectData(List<String> where1, List<String> where2, String tableName, String[] orderBy)
        {
            command.CommandText = "SELECT * from ";
            command.CommandText += tableName;
            if (where1.Count > 0)
            {
                command.CommandText += " WHERE";
                for (int i = 0; i < where1.Count; i++)
                {
                    command.CommandText += " " + where1.ElementAt(i) + "=" + where2.ElementAt(i) + " AND";
                }
                command.CommandText = command.CommandText.Substring(0, command.CommandText.Length - 3);
                where1.RemoveRange(0, where1.Count);
                where2.RemoveRange(0, where2.Count);
            }
            command.CommandText += " ORDER BY ";
            command.CommandText += orderBy;
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Console.WriteLine("ID           : " + DB_PrintToConsole(dataReader, 0) + " ");
                Console.WriteLine("Source Site  : " + DB_PrintToConsole(dataReader, 1) + " ");
                Console.WriteLine("Source ID    : " + DB_PrintToConsole(dataReader, 2) + " ");
                Console.WriteLine("Circle Name  : " + DB_PrintToConsole(dataReader, 3) + " ");
                Console.WriteLine("Date         : " + DB_PrintToConsole(dataReader, 4) + " ");
                Console.WriteLine("Title        : " + DB_PrintToConsole(dataReader, 5) + " ");
                Console.WriteLine("Title Altern : " + DB_PrintToConsole(dataReader, 6) + " ");
                Console.WriteLine("Language     : " + DB_PrintToConsole(dataReader, 7) + " ");
                Console.WriteLine("Data Type    : " + DB_PrintToConsole(dataReader, 8));
                Console.WriteLine();
            }
        }
        public void addToDatabase(string DBSite, string DBID, string Circle, string Date, string Title, string TitleOther, string Language, string DataType, string TitlePath)
        {
            commandDB.CommandText = "INSERT INTO mainTable(DBSite, DBID, Circle, Date, Title, TitleOther, Language, DataType, TitlePath) VALUES(";
            commandDB.CommandText += SQLTestNull(DBSite, true) + ", ";
            commandDB.CommandText += SQLTestNull(DBID, false) + ", ";
            commandDB.CommandText += SQLTestNull(Circle, true) + ", ";
            commandDB.CommandText += SQLTestNull(Date, true) + ", ";
            commandDB.CommandText += SQLTestNull(Title, true) + ", ";
            commandDB.CommandText += SQLTestNull(TitleOther, true) + ", ";
            commandDB.CommandText += SQLTestNull(Language, true) + ", ";
            commandDB.CommandText += SQLTestNull(DataType, true) + ", ";
            commandDB.CommandText += SQLTestNull(TitlePath, true) + ");";

            try
            {
                commandDB.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                if (String.Equals(e.Message, "constraint failed\r\nUNIQUE constraint failed: mainTable.Title"))
                {
                    commandDB.CommandText = "UPDATE mainTable SET DBSite=";
                    commandDB.CommandText += SQLTestNull(DBSite, true);
                    commandDB.CommandText += ", DBID=" + SQLTestNull(DBID, false);
                    commandDB.CommandText += ", Circle=" + SQLTestNull(Circle, true);
                    commandDB.CommandText += ", Date=" + SQLTestNull(Date, true);
                    commandDB.CommandText += ", Title=" + SQLTestNull(Title, true);
                    commandDB.CommandText += ", TitleOther=" + SQLTestNull(TitleOther, true);
                    commandDB.CommandText += ", Language=" + SQLTestNull(Language, true);
                    commandDB.CommandText += ", DataType=" + SQLTestNull(DataType, true);
                    commandDB.CommandText += ", TitlePath=" + SQLTestNull(TitlePath, true);
                    commandDB.CommandText += " WHERE Title=" + SQLTestNull(Title, true);
                    try
                    {
                        commandDB.ExecuteNonQuery();
                    }
                    catch (Exception ee)
                    {
                        throw new NotImplementedException();
                    }
                }
            }
        }

        public string SQLTestNull(string input, Boolean returnWithQuote)
        {
            if (String.IsNullOrEmpty(input))
            {
                return "NULL";
            }
            else
            {
                if (returnWithQuote)
                {
                    return "'" + input + "'";
                }
                else
                {
                    return input;
                }
            }
        }

        public void formClosing()
        {
            connection.Close();
        }
    }
}
