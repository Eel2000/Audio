using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LiteDB;

namespace Audio.Context
{
    public static class LiteDbContext
    {
        private static LiteDatabase database;

        public static LiteDatabase Database
        {
            get
            {
                if(database is null)
                {
                    var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BrigePlayer-data.db");
                    database = new LiteDatabase(new LiteDB.ConnectionString
                    {
                        Filename = databasePath,
                        Password = "@Brige0000"
                    });
                }

                return database;
            }
        }

        public static void ClearDatabase()
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BrigePlayer-data.db");
            if (database != null)
            {
                database.Dispose();
                database = null;
                if (File.Exists(databasePath))
                    File.Delete(databasePath);
                else
                    throw new ApplicationException("Database not found");
            }
        }
    }
}
