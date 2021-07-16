using BurcApp.Modals;
using BurcApp.Tools.API;
using BurcApp.Tools.Database;
using BurcApp.Tools.Reklamlar;
using BurcApp.ViewModals;
using MarcTron.Plugin;
using Plugin.Share;
using System;
using System.Threading;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BurcApp.Views.Burçlar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BurcYorumlarıContentPage : ContentPage
    {
        NetworkAccess networkAccess = Connectivity.NetworkAccess;
        APIVeriCekme aPIVeriCekme = new APIVeriCekme();
        SQLiteManagerDB sQLiteManagerDB = new SQLiteManagerDB();
        BurcYorumlariViewModal burcYorumlariViewModal = new BurcYorumlariViewModal();
        Burclar burclar;

        string[] yorumlar;
        bool haftalikmi;

        public BurcYorumlarıContentPage(int i)
        {
            InitializeComponent();
            CrossMTAdmob.Current.OnInterstitialClosed += Current_OnInterstitialClosed;
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
            FormLoad(i);
        }

        private void FormLoad(int id)
        {
            burclar = sQLiteManagerDB.sqliteConnectionDB.Table<Burclar>().FirstOrDefault(x => x.ID == id);

            switch (burclar.ID)
            {
                case 1:
                    LogoImage.Source = "logo_koc_yorum.png";
                    break;
                case 2:
                    LogoImage.Source = "logo_boga_yorum.png";
                    break;
                case 3:
                    LogoImage.Source = "logo_ikizler_yorum.png";
                    break;
                case 4:
                    LogoImage.Source = "logo_yengec_yorum.png";
                    break;
                case 5:
                    LogoImage.Source = "logo_aslan_yorum.png";
                    break;
                case 6:
                    LogoImage.Source = "logo_basak_yorum.png";
                    break;
                case 7:
                    LogoImage.Source = "logo_terazi_yorum.png";
                    break;
                case 8:
                    LogoImage.Source = "logo_akrep_yorum.png";
                    break;
                case 9:
                    LogoImage.Source = "logo_yay_yorum.png";
                    break;
                case 10:
                    LogoImage.Source = "logo_oglak_yorum.png";
                    break;
                case 11:
                    LogoImage.Source = "logo_kova_yorum.png";
                    break;
                case 12:
                    LogoImage.Source = "logo_balik_yorum.png";
                    break;
            }
            
            //BurcAdLabel.Text = burclar.Ad;
            int genislik = Convert.ToInt32(Application.Current.MainPage.Width) - 25;
            YorumHaftalikLabel.WidthRequest = genislik;
            GenelYorumLabel.WidthRequest = genislik;
            AskYorumLabel.WidthRequest = genislik;
            ParaYorumLabel.WidthRequest = genislik;
            IsYorumLabel.WidthRequest = genislik;
            YasamYorumLabel.WidthRequest = genislik;
            //HaftalikYorumLabel.WidthRequest = genislik;
            //GunlukYorumLabel.WidthRequest = genislik;

            ReklamView.AdsId = "ca-app-pub-1213564589342198/2203645212";

            //test id
            //ReklamView.AdsId = "ca-app-pub-3940256099942544/6300978111";

            if (networkAccess == NetworkAccess.Internet)
            {
                //if (CrossMTAdmob.Current.IsInterstitialLoaded())
                //{
                //    if (GecisReklami._Durum && GecisReklami._TiklamaSayisi <= GecisReklami.KacKereTiklandi)
                //    {
                //        GecisReklami.KacKereTiklandi = 0;
                //        gecisReklamiTiklama.TiklanmaSayisi = GecisReklami.KacKereTiklandi;
                //        sQLiteManagerReklam.sqliteConnectionReklam.Update(gecisReklamiTiklama);
                //        GecisReklami.ReklamGoster();
                //    }
                //}
                //else
                //{
                //    GecisReklami.ReklamDoldur();
                //}
                ReklamView.PersonalizedAds = true;

                YorumlariCek();
            }
            else
            {
                DisplayAlert("UYARI", "Lütfen İnternet Ayarlarınızı Kontrol Ediniz!", "TAMAM");
                Navigation.PopAsync();
            }
        }

        private async void YorumlariCek()
        {
            try
            {
                string parametre = "?BurcID=" + burclar.ID.ToString();
                burcYorumlariViewModal = await aPIVeriCekme.GetBurcYorumlari(parametre);

                if (!burcYorumlariViewModal.Hata)
                {
                    yorumlar = burcYorumlariViewModal.gunlukBurcYorumu.GunlukYorum.Split(new[] { ";-;" }, StringSplitOptions.None);
                    //HaftalikYorumLabel.Text = burcYorumlariViewModal.gunlukBurcYorumu.HaftalikYorum;
                    //GunlukYorumLabel.Text = burcYorumlariViewModal.gunlukBurcYorumu.GunlukYorum;
                    //BaslikLabel.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
                    BaslikLabel.Text = burcYorumlariViewModal.gunlukBurcYorumu.Tarih;
                    YorumHaftalikLabel.Text = burcYorumlariViewModal.gunlukBurcYorumu.HaftalikYorum;
                    MottoSpan.Text = yorumlar[0];
                    GenelYorumSpan.Text = yorumlar[1];
                    AskYorumSpan.Text = yorumlar[2];
                    IsYorumSpan.Text = yorumlar[3];
                    ParaYorumSpan.Text = yorumlar[4];
                    YasamYorumSpan.Text = yorumlar[5];
                    AskLabel.Text = yorumlar[6] + "%";
                    ParaLabel.Text = yorumlar[7] + "%";
                    SaglikLabel.Text = yorumlar[8] + "%";
                    AskProgressRing.Progress = Convert.ToSingle(yorumlar[6]) / 100;
                    ParaProgressRing.Progress = Convert.ToSingle(yorumlar[7]) / 100;
                    SaglikProgressRing.Progress = Convert.ToSingle(yorumlar[8]) / 100;
                    yuklemeIndicator.IsRunning = false;
                    yuklemeIndicator.IsVisible = false;
                    yorumlargrid.IsVisible = true;
                    AltKisimStackLayout.IsVisible = true;
                    BugunButton.IsVisible = true;
                    BuHaftaButton.IsVisible = true;
                }
                else
                {
                    DisplayAlert("UYARI", "Beklenmedik Bir Hata Oluştu! \nLüfen Daha Sonra Tekrar Deneyiniz.", "TAMAM");
                    Navigation.PopAsync();
                }
            }
            catch
            {
                DisplayAlert("UYARI", "Beklenmedik Bir Hata Oluştu! \nLüfen Daha Sonra Tekrar Deneyiniz.", "TAMAM");
                Navigation.PopAsync();
            }
            
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new KullaniciYorumlariContentPage(burclar.ID));
        }

        private void Paylas_Tapped(object sender, EventArgs e)
        {
            if (haftalikmi)
            {
                CrossShare.Current.Share(new Plugin.Share.Abstractions.ShareMessage
                {
                    Text = burcYorumlariViewModal.gunlukBurcYorumu.HaftalikYorum,
                    Title = burclar.Ad + " Haftalık Burç Yorumu",
                    Url = "https://play.google.com/store/apps/details?id=com.yazilimdelisi.burclopedi"
                });
            }
            else
            {
                CrossShare.Current.Share(new Plugin.Share.Abstractions.ShareMessage
                {
                    Text = "Genel Yorum: " + yorumlar[1] + " Aşk Yorumu: " + yorumlar[2] + " İş Yorumu: " + yorumlar[3] + " Para Yorumu: " + yorumlar[4] + " Yaşam Yorumu: " + yorumlar[5],
                    Title = burclar.Ad + " Günlük Burç Yorumu",
                    Url = "https://play.google.com/store/apps/details?id=com.yazilimdelisi.burclopedi"
                });
            }
            
        }

        private void Current_OnInterstitialClosed(object sender, EventArgs e)
        {
            GecisReklami.KacKereTiklandi = 0;
            GecisReklami.ReklamDoldur();
        }

        private void BugunButton_Clicked(object sender, EventArgs e)
        {
            //Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
            //BaslikLabel.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            BaslikLabel.Text = burcYorumlariViewModal.gunlukBurcYorumu.Tarih;
            BugunButton.BackgroundColor = Color.FromHex("#34a8ba");
            BuHaftaButton.BackgroundColor = Color.FromHex("#223965");
            YorumGunlukStackLayout.IsVisible = true;
            YorumHaftalikStackLayout.IsVisible = false;
            haftalikmi = false;
        }

        private void BuHaftaButton_Clicked(object sender, EventArgs e)
        {
            BaslikLabel.Text = burcYorumlariViewModal.gunlukBurcYorumu.Hafta;
            BugunButton.BackgroundColor = Color.FromHex("#223965");
            BuHaftaButton.BackgroundColor = Color.FromHex("#34a8ba");
            YorumGunlukStackLayout.IsVisible = false;
            YorumHaftalikStackLayout.IsVisible = true;
            haftalikmi = true;
        }

    }
}