using PrismOwnedBluRays.API;
using PrismOwnedBluRays.Models;
using SQLite;
using System;
using System.IO;

namespace PrismOwnedBluRays.Database
{
    public class SqliteDataService : ILocalDataService
    {
        private SQLiteConnection _database;
        public void Initialize()
        {
            if (_database == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "OwnedBluRaysDb.db3");
                _database = new SQLiteConnection(dbPath);
            }
            _database.CreateTable<BluRay>();
        }
    }
}