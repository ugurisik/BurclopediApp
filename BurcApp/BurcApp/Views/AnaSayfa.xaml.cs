using BurcApp.Modals;
using BurcApp.Tools.API;
using BurcApp.Tools.Database;
using BurcApp.Tools.Reklamlar;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BurcApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnaSayfa : MasterDetailPage
    {
        public static AnaSayfa AnaEkran;
        public static AnaSayfaDetail anasayfaDetail;
        APIVeriCekme aPIVeriCekme = new APIVeriCekme();
        SQLiteManagerReklam sQLiteManagerReklam;

        public AnaSayfa()
        {
            InitializeComponent();
            AnaEkran = this;
            anasayfaDetail = new AnaSayfaDetail();
            this.Master = new AnaSayfaMaster();
            this.Detail = new NavigationPage(anasayfaDetail)
            {
                BarBackgroundColor = Color.WhiteSmoke,
                BarTextColor = Color.Black
            };
            FormLoad();
            //DependencyService.Get<IStatusBar>().HideStatusBar();
        }

        private async void FormLoad()
        {
            sQLiteManagerReklam = new SQLiteManagerReklam();

            NetworkAccess networkAccess = Connectivity.NetworkAccess;

            if (networkAccess == NetworkAccess.Internet)
            {
                string parametre = "reklam.php?ReklamAyari";
                string deneme = await aPIVeriCekme.ReklamAyarlari(parametre);
                string[] asd = deneme.Split('-');
                GecisReklami._Durum = Convert.ToBoolean(asd[0]);
                GecisReklami._TiklamaSayisi = Convert.ToInt32(asd[1]);
                GecisReklami.KacKereTiklandi = sQLiteManagerReklam.sqliteConnectionReklam.Table<GecisReklamiTiklama>().FirstOrDefault().TiklanmaSayisi;
                GecisReklami.ReklamDoldur();
            }
            else
            {
                GecisReklami._Durum = false;
                GecisReklami._TiklamaSayisi = 0;
            }

            
        }

    }
}