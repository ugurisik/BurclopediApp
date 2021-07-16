using BurcApp.Modals;
using BurcApp.Tools.Database;
using BurcApp.Tools.Reklamlar;
using MarcTron.Plugin;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BurcApp.Views.Burçlar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class YukselenOzelliklerContentPage : ContentPage
    {
        SQLiteManagerReklam sQLiteManagerReklam = new SQLiteManagerReklam();
        GecisReklamiTiklama gecisReklamiTiklama;
        NetworkAccess networkAccess = Connectivity.NetworkAccess;

        public YukselenOzelliklerContentPage(Burclar bb)
        {
            InitializeComponent();
            CrossMTAdmob.Current.OnInterstitialClosed += Current_OnInterstitialClosed;
            gecisReklamiTiklama = sQLiteManagerReklam.sqliteConnectionReklam.Table<GecisReklamiTiklama>().FirstOrDefault();
            FormLoad(bb);
        }

        private void FormLoad(Burclar b)
        {
            ReklamView.AdsId = "ca-app-pub-1213564589342198/9392225318";

            switch (b.ID)
            {
                case 1:
                    LogoImage.Source = "logo_koc_ozellik.png";
                    break;
                case 2:
                    LogoImage.Source = "logo_boga_ozellik.png";
                    break;
                case 3:
                    LogoImage.Source = "logo_ikizler_ozellik.png";
                    break;
                case 4:
                    LogoImage.Source = "logo_yengec_ozellik.png";
                    break;
                case 5:
                    LogoImage.Source = "logo_aslan_ozellik.png";
                    break;
                case 6:
                    LogoImage.Source = "logo_basak_ozellik.png";
                    break;
                case 7:
                    LogoImage.Source = "logo_terazi_ozellik.png";
                    break;
                case 8:
                    LogoImage.Source = "logo_akrep_ozellik.png";
                    break;
                case 9:
                    LogoImage.Source = "logo_yay_ozellik.png";
                    break;
                case 10:
                    LogoImage.Source = "logo_oglak_ozellik.png";
                    break;
                case 11:
                    LogoImage.Source = "logo_kova_ozellik.png";
                    break;
                case 12:
                    LogoImage.Source = "logo_balik_ozellik.png";
                    break;
            }
            //BurcAdLabel.Text = b.Ad;
            BaslikLabel.Text = "YÜKSELEN " + b.Ad + " ÖZELLİĞİ";
            YukselenOzellikLabel.Text = b.Yukselen;
           
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

        private void Current_OnInterstitialClosed(object sender, EventArgs e)
        {
            GecisReklami.ReklamDoldur();
        }
    
    }
}