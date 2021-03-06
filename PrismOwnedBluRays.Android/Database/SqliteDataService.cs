using PrismOwnedBluRays.AndroidProject.Database;
using PrismOwnedBluRays.Database;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqliteDataService))]
namespace PrismOwnedBluRays.AndroidProject.Database
{
    public class SqliteDataService : ILocalDataService
    {
        private SQLiteConnection _database;
        public SQLiteConnection SetupDatabaseAndGetConnection()
        {
            if (_database == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "OwnedBluRaysDb.db3");
                _database = new SQLiteConnection(dbPath);
            }

            return _database;
        }
    }
}