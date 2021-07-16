using Android.Content.Res;
using BurcApp.Droid.Helper;
using BurcApp.Helper;
using SQLite;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteConnectionAndroid))]
namespace BurcApp.Droid.Helper
{
    public class SQLiteConnectionAndroid: ISQLiteConnection
    {
        static bool acilis = false;

        public SQLiteConnection GetConnection(string DBName)
        {

            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath, DBName);

            // Check if your DB has already been extracted.
            if (File.Exists(path) && !acilis)
            {
                File.Delete(path);
                using (BinaryReader br = new BinaryReader(Android.App.Application.Context.Assets.Open("Burclopedi.db3")))
                {
                    using (BinaryWriter bw = new BinaryWriter(new FileStream(path, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int len = 0;
                        while ((len = br.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            bw.Write(buffer, 0, len);
                        }
                    }
                }
                acilis = true;
            }        

            var connection = new SQLiteConnection(path);
            return connection;
        }

        public SQLiteConnection GetConnectionReklam(string DBName)
        {
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath, DBName);

            var connection = new SQLiteConnection(path);
            return connection;
        }
    }
}