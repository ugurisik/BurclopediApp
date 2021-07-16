using BurcApp.Modals;
using BurcApp.Tools.Database;
using BurcApp.Tools.Reklamlar;
using BurcApp.Views.BurcBulma;
using BurcApp.Views.BurclarinUyumu;
using BurcApp.Views.Elementler;
using BurcApp.Views.Yildizlar;
using BurcApp.Views.YukselenBurcBulma;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BurcApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnaSayfaMaster : ContentPage
    {
        SQLiteManagerDB sQLiteManagerDB = new SQLiteManagerDB();
        SQLiteManagerReklam sQLiteManagerReklam = new SQLiteManagerReklam();
        NetworkAccess networkAccess;
        GecisReklamiTiklama gecisReklamiTiklama;

        public AnaSayfaMaster()
        {
            InitializeComponent();
            networkAccess = Connectivity.NetworkAccess;
            gecisReklamiTiklama = sQLiteManagerReklam.sqliteConnectionReklam.Table<GecisReklamiTiklama>().FirstOrDefault();
        }

        private void MenuBurclarImgBtn_Clicked(object sender, EventArgs e)
        {
            AnaSayfa.AnaEkran.Detail = new NavigationPage(new AnaSayfaDetail())
            {
                BarBackgroundColor = Color.WhiteSmoke,
                BarTextColor = Color.Black
            };
            AnaSayfa.AnaEkran.IsPresented = false;
        }

        private async void MenuBurcUyumuImgBtn_Clicked(object sender, EventArgs e)
        {
            if (GecisReklami._Durum && GecisReklami.KacKereTiklandi == 0 && networkAccess == NetworkAccess.Internet)
            {
                await GecisReklami.ReklamDoldur();
            }
            GecisReklami.KacKereTiklandi++;
            gecisReklamiTiklama.TiklanmaSayisi = GecisReklami.KacKereTiklandi;
            sQLiteManagerReklam.sqliteConnectionReklam.Update(gecisReklamiTiklama);
            AnaSayfa.AnaEkran.Detail = new NavigationPage(new BurclarinUyumuContentPage())
            {
                BarBackgroundColor = Color.WhiteSmoke,
                BarTextColor = Color.Black
            };
            AnaSayfa.AnaEkran.IsPresented = false;
        }

        private async void MenuYukselenBurcImgBtn_Clicked_1(object sender, EventArgs e)
        {
            if (GecisReklami._Durum && GecisReklami.KacKereTiklandi == 0 && networkAccess == NetworkAccess.Internet)
            {
                await GecisReklami.ReklamDoldur();
            }
            GecisReklami.KacKereTiklandi++;
            gecisReklamiTiklama.TiklanmaSayisi = GecisReklami.KacKereTiklandi;
            sQLiteManagerReklam.sqliteConnectionReklam.Update(gecisReklamiTiklama);
            AnaSayfa.AnaEkran.Detail = new NavigationPage(new YukselenBurcContentPage())
            {
                BarBackgroundColor = Color.WhiteSmoke,
                BarTextColor = Color.Black
            };
            AnaSayfa.AnaEkran.IsPresented = false;
        }

        private void MenuElementlerImgBtn_Clicked(object sender, EventArgs e)
        {
            AnaSayfa.AnaEkran.Detail = new NavigationPage(new ElementlerContentPage())
            {
                BarBackgroundColor = Color.WhiteSmoke,
                BarTextColor = Color.Black
            };
            AnaSayfa.AnaEkran.IsPresented = false;
        }

        private void MenuYildizlarImgBtn_Clicked(object sender, EventArgs e)
        {
            AnaSayfa.AnaEkran.Detail = new NavigationPage(new YildizlarContentPage())
            {
                BarBackgroundColor = Color.WhiteSmoke,
                BarTextColor = Color.Black
            };
            AnaSayfa.AnaEkran.IsPresented = false;
        }

        private async void MenuBurcOgrenImgBtn_Clicked(object sender, EventArgs e)
        {
            if (GecisReklami._Durum && GecisReklami.KacKereTiklandi == 0 && networkAccess == NetworkAccess.Internet)
            {
                await GecisReklami.ReklamDoldur();
            }
            GecisReklami.KacKereTiklandi++;
            gecisReklamiTiklama.TiklanmaSayisi = GecisReklami.KacKereTiklandi;
            sQLiteManagerReklam.sqliteConnectionReklam.Update(gecisReklamiTiklama);
            AnaSayfa.AnaEkran.Detail = new NavigationPage(new BurcBulmaContentPage())
            {
                BarBackgroundColor = Color.WhiteSmoke,
                BarTextColor = Color.Black
            };
            AnaSayfa.AnaEkran.IsPresented = false;
        }
    }
}