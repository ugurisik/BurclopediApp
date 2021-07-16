using BurcApp.Modals;
using BurcApp.Tools.Database;
using BurcApp.Tools.Reklamlar;
using MarcTron.Plugin;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BurcApp.Views.YukselenBurcBulma
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class YukselenBurcContentPage : ContentPage
    {
        SQLiteManagerDB sQLiteManagerDB = new SQLiteManagerDB();
        SQLiteManagerReklam sQLiteManagerReklam = new SQLiteManagerReklam();
        GecisReklamiTiklama gecisReklamiTiklama;

        List<string> burclar = new List<string>() { "KOÇ", "BOĞA", "İKİZLER", "YENGEÇ", "ASLAN", "BAŞAK", "TERAZİ", "AKREP", "YAY", "OĞLAK", "KOVA", "BALIK" };
        List<string> saatler = new List<string>() { "05-07", "07-09", "09-11", "11-13", "13-15", "15-17", "17-19", "19-21", "21-23", "23-01", "01-03", "03-05" };

        public YukselenBurcContentPage()
        {
            InitializeComponent();
            CrossMTAdmob.Current.OnInterstitialClosed += Current_OnInterstitialClosed;
            gecisReklamiTiklama = sQLiteManagerReklam.sqliteConnectionReklam.Table<GecisReklamiTiklama>().FirstOrDefault();
            FillPicker();
        }

        private void FillPicker()
        {
            BurcPicker.ItemsSource = burclar;
            BurcPicker.SelectedIndex = 0;
            SaatPicker.ItemsSource = saatler;
            SaatPicker.SelectedIndex = 0;

            NetworkAccess networkAccess = Connectivity.NetworkAccess;
            if (networkAccess == NetworkAccess.Internet)
            {
                if (CrossMTAdmob.Current.IsInterstitialLoaded())
                {
                    if (GecisReklami._Durum && GecisReklami._TiklamaSayisi <= GecisReklami.KacKereTiklandi)
                    {
                        GecisReklami.KacKereTiklandi = 0;
                        gecisReklamiTiklama.TiklanmaSayisi = GecisReklami.KacKereTiklandi;
                        sQLiteManagerReklam.sqliteConnectionReklam.Update(gecisReklamiTiklama);
                        GecisReklami.ReklamGoster();
                    }
                }
                else
                {
                    GecisReklami.ReklamDoldur();
                }
            } 
        }

        string burc;
        string saat;
        private void HesaplaButton_Clicked(object sender, EventArgs e)
        {
            burc = BurcPicker.SelectedItem.ToString();
            saat = SaatPicker.SelectedItem.ToString();
            YukselenLabel.Text = sQLiteManagerDB.sqliteConnectionDB.Table<YukselenBurc>().FirstOrDefault(x => x.Burc == burc  && x.Saat == saat).Yukselen;
        }

        protected override bool OnBackButtonPressed()
        {
            AnaSayfa.AnaEkran.Detail = new NavigationPage(AnaSayfa.anasayfaDetail)
            {
                BarBackgroundColor = Color.WhiteSmoke,
                BarTextColor = Color.Black
            };
            return true;
        }

        private void Current_OnInterstitialClosed(object sender, EventArgs e)
        {
            GecisReklami.ReklamDoldur();
        }

    }
}