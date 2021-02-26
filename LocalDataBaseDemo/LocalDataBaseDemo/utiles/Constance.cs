using System;
using System.IO;

namespace LocalDataBaseDemo.utiles
{
    public static class Constance
    {
        static string databasename = "student.db3";
        static SQLite.SQLiteOpenFlags flags = SQLite.SQLiteOpenFlags.Create | SQLite.SQLiteOpenFlags.ReadWrite | SQLite.SQLiteOpenFlags.SharedCache;

       public static string DatabaseFilePathe
        {
            get
            {
                var basepath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basepath, databasename);
            }

        }
    }
}
