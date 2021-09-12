using PrismOwnedBluRays.Database;
using SQLite;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqliteDataService))]
namespace PrismOwnedBluRays.Database
{
    public class SqliteDataService : ILocalDataService
    {
        public SQLiteConnection GetConnection()
        {
            var dbase = "OwnedBluRaysDb";
            var dbpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(dbpath, dbase);
            var connection = new SQLiteConnection(path);
            return connection;
        }
    }
}