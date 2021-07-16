using BurcApp.Modals;
using BurcApp.Tools.API;
using BurcApp.Tools.Database;
using BurcApp.ViewModals;
using Plugin.Share;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BurcApp.Views.Burçlar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HaftalikBurcYorumlariContentPage : ContentPage
    {
        NetworkAccess networkAccess;
        APIVeriCekme aPIVeriCekme = new APIVeriCekme();
        SQLiteManagerDB sQLiteManagerDB = new SQLiteManagerDB();

        BurcYorumlariViewModal burcYorumlariViewModal = new BurcYorumlariViewModal();
        Burclar burclar;

        public HaftalikBurcYorumlariContentPage(int i)
        {
            InitializeComponent();

            FormLoad(i);
        }

        private async void FormLoad(int id)
        {
            burclar = sQLiteManagerDB.sqliteConnectionDB.Table<Burclar>().FirstOrDefault(x => x.ID == id);
            //BurcAdLabel.Text = burclar.Ad;
            int genislik = Convert.ToInt32(Application.Current.MainPage.Width) - 25;
            HaftalikYorumLabel.WidthRequest = genislik;

            networkAccess = Connectivity.NetworkAccess;

            ReklamView.HeightRequest = 50;
            ReklamView.AdsId = "ca-app-pub-1213564589342198/2203645212";

            //test id
            //ReklamView.AdsId = "ca-app-pub-3940256099942544/6300978111";

            if (networkAccess == NetworkAccess.Internet)
            {
                ReklamView.PersonalizedAds = true;

                string parametre = "?BurcID=" + burclar.ID.ToString();
                burcYorumlariViewModal = await aPIVeriCekme.GetBurcYorumlari(parametre);

                if (!burcYorumlariViewModal.Hata)
                {
                    HaftalikYorumLabel.Text = burcYorumlariViewModal.gunlukBurcYorumu.HaftalikYorum;
                    yuklemeIndicator.IsRunning = false;
                    yuklemeIndicator.IsVisible = false;
                    yorumlarscrollview.IsVisible = true;
                    AltKisimStackLayout.IsVisible = true;
                }
                else
                {
                    DisplayAlert("UYARI", "Beklenmedik Bir Hata Oluştu! \nLüfen Daha Sonra Tekrar Deneyiniz.", "TAMAM");
                    Navigation.PopAsync();
                }
            }
            else
            {
                DisplayAlert("UYARI", "Lütfen İnternet Ayarlarınızı Kontrol Ediniz!", "TAMAM");
                Navigation.PopAsync();
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new KullaniciYorumlariContentPage(burclar.ID));
        }

        private void Paylas_Tapped(object sender, EventArgs e)
        {
            CrossShare.Current.Share(new Plugin.Share.Abstractions.ShareMessage
            {
                Text = burcYorumlariViewModal.gunlukBurcYorumu.GunlukYorum,
                Title = burclar.Ad + " Günlük Burç Yorumu",
                Url = "https://play.google.com/store/apps/details?id=com.yazilimdelisi.burclopedi"
            });
        }

    }
}