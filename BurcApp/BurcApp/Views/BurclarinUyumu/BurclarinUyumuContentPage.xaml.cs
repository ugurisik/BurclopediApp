using BurcApp.Modals;
using BurcApp.Tools.Database;
using BurcApp.Tools.Reklamlar;
using MarcTron.Plugin;
using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BurcApp.Views.BurclarinUyumu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BurclarinUyumuContentPage : ContentPage
    {
        SQLiteManagerDB sQLiteManagerDB = new SQLiteManagerDB();
        SQLiteManagerReklam sQLiteManagerReklam = new SQLiteManagerReklam();
        GecisReklamiTiklama gecisReklamiTiklama;
        NetworkAccess networkAccess = Connectivity.NetworkAccess;

        string erkek = "", kadin = "";
        int id = 0;
        ImageButton btn;

        public BurclarinUyumuContentPage()
        {
            InitializeComponent();
            CrossMTAdmob.Current.OnInterstitialClosed += Current_OnInterstitialClosed;

            gecisReklamiTiklama = sQLiteManagerReklam.sqliteConnectionReklam.Table<GecisReklamiTiklama>().FirstOrDefault();

            ReklamView.AdsId = "ca-app-pub-1213564589342198/1924798837";

            if (networkAccess == NetworkAccess.Internet)
            {
                ReklamView.PersonalizedAds = true;

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
            else
            {
                ReklamView.HeightRequest = 1;
            }
        }

        private void ErkekButton_Clicked(object sender, EventArgs e)
        {
            btn = (ImageButton)sender;
            id = Convert.ToInt32(btn.CommandParameter);
            erkek = sQLiteManagerDB.sqliteConnectionDB.Table<Burclar>().FirstOrDefault(x => x.ID == id).Ad;
            ErkekKocButton.BorderColor = Color.Transparent;
            ErkekBogaButton.BorderColor = Color.Transparent;
            ErkekIkizlerButton.BorderColor = Color.Transparent;
            ErkekYengecButton.BorderColor = Color.Transparent;
            ErkekAslanButton.BorderColor = Color.Transparent;
            ErkekBasakButton.BorderColor = Color.Transparent;
            ErkekTeraziButton.BorderColor = Color.Transparent;
            ErkekAkrepButton.BorderColor = Color.Transparent;
            ErkekYayButton.BorderColor = Color.Transparent;
            ErkekOglakButton.BorderColor = Color.Transparent;
            ErkekKovaButton.BorderColor = Color.Transparent;
            ErkekBalikButton.BorderColor = Color.Transparent;
            btn.BorderColor = Color.FromHex("#C10000");
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!erkekRadioButton.IsChecked && !kadinRadioButton.IsChecked)
            {
                DisplayAlert("UYARI", "Lütfen Cinsiyetinizi Seçiniz!", "TAMAM");
            }
            else if (string.IsNullOrEmpty(erkek) || string.IsNullOrEmpty(kadin))
            {
                DisplayAlert("UYARI", "Lütfen Burçları Seçiniz!", "TAMAM");
            }
            else
            {
                bool b = false;
                if (kadinRadioButton.IsChecked)
                {
                    b = true;
                }
                BurcUyumu burcUyumu = sQLiteManagerDB.sqliteConnectionDB.Table<BurcUyumu>().FirstOrDefault(x => x.Cinsiyet == b && x.Erkek == erkek && x.Kadin == kadin);
                await PopupNavigation.Instance.PushAsync(new BurclarinUyumuPopupPage(burcUyumu));
            }
        }

        private void KadinButton_Clicked(object sender, EventArgs e)
        {
            btn = (ImageButton)sender;
            id = Convert.ToInt32(btn.CommandParameter);
            kadin = sQLiteManagerDB.sqliteConnectionDB.Table<Burclar>().FirstOrDefault(x => x.ID == id).Ad;
            KadinKocButton.BorderColor = Color.Transparent;
            KadinBogaButton.BorderColor = Color.Transparent;
            KadinIkizlerButton.BorderColor = Color.Transparent;
            KadinYengecButton.BorderColor = Color.Transparent;
            KadinAslanButton.BorderColor = Color.Transparent;
            KadinBasakButton.BorderColor = Color.Transparent;
            KadinTeraziButton.BorderColor = Color.Transparent;
            KadinAkrepButton.BorderColor = Color.Transparent;
            KadinYayButton.BorderColor = Color.Transparent;
            KadinOglakButton.BorderColor = Color.Transparent;
            KadinKovaButton.BorderColor = Color.Transparent;
            KadinBalikButton.BorderColor = Color.Transparent;
            btn.BorderColor = Color.FromHex("#C10000");
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