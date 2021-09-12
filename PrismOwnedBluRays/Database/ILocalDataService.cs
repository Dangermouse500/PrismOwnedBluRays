using SQLite;

namespace PrismOwnedBluRays.Database
{
    public interface ILocalDataService
    {
        SQLiteConnection GetConnection();
    }
}