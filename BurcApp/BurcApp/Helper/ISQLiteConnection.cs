using SQLite;

namespace BurcApp.Helper
{
    public interface ISQLiteConnection
    {
        SQLiteConnection GetConnection(string DBname);

        SQLiteConnection GetConnectionReklam(string DBname);
    }
}
