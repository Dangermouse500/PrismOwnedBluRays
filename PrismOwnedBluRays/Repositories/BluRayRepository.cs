using PrismOwnedBluRays.Database;
using PrismOwnedBluRays.Models;
using SQLite;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PrismOwnedBluRays.Repositories
{
    public class BluRayRepository : IBluRayRepository
    {
        private SQLiteConnection _dbConnection;

        public BluRayRepository()
        {
            _dbConnection = DependencyService.Get<ILocalDataService>().SetupDatabaseAndGetConnection();
            _dbConnection.CreateTable<BluRay>();
        }

        public List<BluRay> GetOwnedBluRays()
        {
            return _dbConnection.Table<BluRay>().OrderBy(b => b.BluRayTitle).ToList();
        }

        public BluRay GetBluRayDetailsById(int bluRayId)
        {
            return _dbConnection.Table<BluRay>().Where(x => x.BluRayId == bluRayId).FirstOrDefault();
        }

        public void AddBluRay(BluRay bluRay)
        {
            _dbConnection.Insert(bluRay);
        }

        public void DeleteBluRay(BluRay bluRay)
        {
            _dbConnection.Delete(bluRay);
        }
    }
}