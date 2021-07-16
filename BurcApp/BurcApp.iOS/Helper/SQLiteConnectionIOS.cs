using BurcApp.Helper;
using BurcApp.iOS.Helper;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteConnectionIOS))]
namespace BurcApp.iOS.Helper
{
    public class SQLiteConnectionIOS: ISQLiteConnection
    {
        public SQLiteConnection GetConnection(string DBName)
        {
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = System.IO.Path.Combine(documentPath, DBName);
            // platform = new SQLitePlatformAndroid();
            var connection = new SQLiteConnection(path);
            return connection;
        }

        public SQLiteConnection GetConnectionReklam(string DBName)
        {
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = System.IO.Path.Combine(documentPath, DBName);
            // platform = new SQLitePlatformAndroid();
            var connection = new SQLiteConnection(path);
            return connection;
        }
    }
}