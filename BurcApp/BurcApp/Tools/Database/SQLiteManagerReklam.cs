using BurcApp.Helper;
using BurcApp.Modals;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BurcApp.Tools.Database
{
    public class SQLiteManagerReklam
    {
        public SQLiteConnection sqliteConnectionReklam;

        public SQLiteManagerReklam()
        {
            sqliteConnectionReklam = DependencyService.Get<ISQLiteConnection>().GetConnectionReklam("Reklam.db3");
            sqliteConnectionReklam.CreateTable<GecisReklamiTiklama>();
            if (sqliteConnectionReklam.Table<GecisReklamiTiklama>().Count() <= 0)
            {
                GecisReklamiTiklama gecisReklamiTiklama = new GecisReklamiTiklama();
                gecisReklamiTiklama.TiklanmaSayisi = 0;
                sqliteConnectionReklam.Insert(gecisReklamiTiklama);
            }
        }

    }
}
