using BurcApp.Modals;
using BurcApp.Tools.Database;
using BurcApp.Tools.Reklamlar;
using BurcApp.Views.Burçlar;
using MarcTron.Plugin;
using Plugin.LocalNotification;
using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BurcApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnaSayfaDetail : ContentPage
    {
        SQLiteManagerDB sQLiteManagerDB;
        SQLiteManagerReklam sQLiteManagerReklam;
        NetworkAccess networkAccess;
        GecisReklamiTiklama gecisReklamiTiklama;

        public AnaSayfaDetail()
        {
            InitializeComponent();
            Yukle();
        }

        private async void Yukle()
        {
            sQLiteManagerDB = new SQLiteManagerDB();
            sQLiteManagerReklam = new SQLiteManagerReklam();

            networkAccess = Connectivity.NetworkAccess;

            gecisReklamiTiklama = sQLiteManagerReklam.sqliteConnectionReklam.Table<GecisReklamiTiklama>().FirstOrDefault();

            NotificationCenter.Current.CancelAll();

            var notification1 = new NotificationRequest
            {
                BadgeNumber = 1,
                Title = "BURÇLOPEDİ",
                Description = "Bugünkü Günlük Burç Yorumunuzu Okumak İçin Tıklayınız!",
                NotificationId = 1337,
                NotifyTime = DateTime.Now.AddDays(2)
            };

            var notification2 = new NotificationRequest
            {
                BadgeNumber = 1,
                Title = "BURÇLOPEDİ",
                Description = "Bugünkü Günlük Burç Yorumunuzu Okumak İçin Tıklayınız!",
                NotificationId = 1338,
                NotifyTime = DateTime.Now.AddDays(7)
            };

            var notification3 = new NotificationRequest
            {
                BadgeNumber = 1,
                Title = "BURÇLOPEDİ",
                Description = "Bugünkü Günlük Burç Yorumunuzu Okumak İçin Tıklayınız!",
                NotificationId = 1339,
                NotifyTime = DateTime.Now.AddDays(15)
            };

            var notification4 = new NotificationRequest
            {
                BadgeNumber = 1,
                Title = "BURÇLOPEDİ",
                Description = "Bugünkü Günlük Burç Yorumunuzu Okumak İçin Tıklayınız!",
                NotificationId = 1340,
                NotifyTime = DateTime.Now.AddDays(20)
            };

            var notification5 = new NotificationRequest
            {
                BadgeNumber = 1,
                Title = "BURÇLOPEDİ",
                Description = "Bugünkü Günlük Burç Yorumunuzu Okumak İçin Tıklayınız!",
                NotificationId = 1341,
                NotifyTime = DateTime.Now.AddDays(30)
            };

            NotificationCenter.Current.Show(notification1);
            NotificationCenter.Current.Show(notification2);
            NotificationCenter.Current.Show(notification3);
            NotificationCenter.Current.Show(notification4);
            NotificationCenter.Current.Show(notification5);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            ImageButton imgbtn = (ImageButton)sender;
            int id = Convert.ToInt32(imgbtn.CommandParameter);
            await PopupNavigation.Instance.PushAsync(new BurcSecenekler(this,id));
        }

        private void Menu_Clicked(object sender, EventArgs e)
        {
            AnaSayfa.AnaEkran.IsPresented = true;
        }

        public async void BurcYorumlarGit(int id)
        {
            PopupNavigation.Instance.PopAllAsync();
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
                    await GecisReklami.ReklamDoldur();
                }
            }
            GecisReklami.KacKereTiklandi++;
            gecisReklamiTiklama.TiklanmaSayisi = GecisReklami.KacKereTiklandi;
            sQLiteManagerReklam.sqliteConnectionReklam.Update(gecisReklamiTiklama);
            Navigation.PushAsync(new BurcYorumlarıContentPage(id));
        }

        public async void MeslekGit(int id)
        {
            PopupNavigation.Instance.PopAllAsync();
            string yazi = sQLiteManagerDB.sqliteConnectionDB.Table<Burclar>().FirstOrDefault(x => x.ID == id).Meslek;
            await PopupNavigation.Instance.PushAsync(new MeslekUnluPopupPage(yazi));
        }

        public async void UnluGit(int id)
        {
            PopupNavigation.Instance.PopAllAsync();
            string yazi = sQLiteManagerDB.sqliteConnectionDB.Table<Burclar>().FirstOrDefault(x => x.ID == id).Unluler;
            await PopupNavigation.Instance.PushAsync(new MeslekUnluPopupPage(yazi));
        }

        public async void HediyeGit(int id)
        {
            PopupNavigation.Instance.PopAllAsync();
            string erkekHediye = sQLiteManagerDB.sqliteConnectionDB.Table<Burclar>().FirstOrDefault(x => x.ID == id).ErkekHediye;
            string kadinHediye = sQLiteManagerDB.sqliteConnectionDB.Table<Burclar>().FirstOrDefault(x => x.ID == id).KadinHediye;
            await PopupNavigation.Instance.PushAsync(new HediyelerPopupPage(erkekHediye,kadinHediye));
        }

        public async void OzelliklerGit(int id)
        {          
            PopupNavigation.Instance.PopAllAsync();
            if (networkAccess == NetworkAccess.Internet)
            {
                if (GecisReklami._Durum)
                {
                    await GecisReklami.ReklamDoldur();
                }
            }
            GecisReklami.KacKereTiklandi++;
            gecisReklamiTiklama.TiklanmaSayisi = GecisReklami.KacKereTiklandi;
            sQLiteManagerReklam.sqliteConnectionReklam.Update(gecisReklamiTiklama);
            Burclar burclar = sQLiteManagerDB.sqliteConnectionDB.Table<Burclar>().FirstOrDefault(x => x.ID == id);
            Navigation.PushAsync(new BurcOzelliklerContentPage(burclar));
        }

        public async void YukselenOzelliklerGit(int id)
        {         
            PopupNavigation.Instance.PopAllAsync();
            if (networkAccess == NetworkAccess.Internet)
            {
                if (GecisReklami._Durum)
                {
                    await GecisReklami.ReklamDoldur();
                }
            }
            GecisReklami.KacKereTiklandi++;
            gecisReklamiTiklama.TiklanmaSayisi = GecisReklami.KacKereTiklandi;
            sQLiteManagerReklam.sqliteConnectionReklam.Update(gecisReklamiTiklama);
            Burclar burclar = sQLiteManagerDB.sqliteConnectionDB.Table<Burclar>().FirstOrDefault(x => x.ID == id);
            Navigation.PushAsync(new YukselenOzelliklerContentPage(burclar));
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}