using BurcApp.Modals;
using BurcApp.Tools.Database;
using BurcApp.Tools.Reklamlar;
using MarcTron.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BurcApp.Views.BurcBulma
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BurcBulmaContentPage : ContentPage
    {
        SQLiteManagerReklam sQLiteManagerReklam = new SQLiteManagerReklam();
        GecisReklamiTiklama gecisReklamiTiklama;

        List<string> tarihler = new List<string>() { "21 Mart - 20 Nisan Arasında", "21 Nisan - 20 Mayıs Arasında", "21 Mayıs - 21 Haziran Arasında", "22 Haziran - 22 Temmuz Arasında", "23 Temmuz - 22 Ağustos Arasında", "23 Ağustos - 22 Eylül Arasında", "23  Eylül - 23 Ekim Arasında", "24 Ekim - 22 Kasım Arasında", "23 Kasım - 21 Aralık Arasında", "22 Aralık - 20 Ocak Arasında", "21 Ocak - 18 Şubat Arasında", "19 Şubat - 20 Mart Arasında" };

        public BurcBulmaContentPage()
        {
            InitializeComponent();
            CrossMTAdmob.Current.OnInterstitialClosed += Current_OnInterstitialClosed;
            gecisReklamiTiklama = sQLiteManagerReklam.sqliteConnectionReklam.Table<GecisReklamiTiklama>().FirstOrDefault();
            FillPicker();
        }

        private void FillPicker()
        {
            TarihPicker.ItemsSource = tarihler;
            TarihPicker.SelectedIndex = -1;

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

        private void HesaplaButton_Clicked(object sender, EventArgs e)
        {
            switch (TarihPicker.SelectedIndex)
            {
                case -1:
                    BurcLabel.Text = "Önce Tarih Seçiniz!";
                    break;
                case 0:
                    BurcLabel.Text = "KOÇ BURCU";
                    break;
                case 1:
                    BurcLabel.Text = "BOĞA BURCU";
                    break;
                case 2:
                    BurcLabel.Text = "İKİZLER BURCU";
                    break;
                case 3:
                    BurcLabel.Text = "YENGEÇ BURCU";
                    break;
                case 4:
                    BurcLabel.Text = "ASLAN BURCU";
                    break;
                case 5:
                    BurcLabel.Text = "BAŞAK BURCU";
                    break;
                case 6:
                    BurcLabel.Text = "TERAZİ BURCU";
                    break;
                case 7:
                    BurcLabel.Text = "AKREP BURCU";
                    break;
                case 8:
                    BurcLabel.Text = "YAY BURCU";
                    break;
                case 9:
                    BurcLabel.Text = "OĞLAK BURCU";
                    break;
                case 10:
                    BurcLabel.Text = "KOVA BURCU";
                    break;
                case 11:
                    BurcLabel.Text = "BALIK BURCU";
                    break;
            }
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