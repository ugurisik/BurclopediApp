using BurcApp.Modals;
using BurcApp.Tools.Database;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Forms.Xaml;

namespace BurcApp.Views.Burçlar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BurcSecenekler : PopupPage
    {

        SQLiteManagerDB sQLiteManagerDB = new SQLiteManagerDB();
        AnaSayfaDetail anaSayfaDetail;
        int burcID;

        public BurcSecenekler(AnaSayfaDetail a, int id)
        {
            InitializeComponent();
            anaSayfaDetail = a;
            burcID = id;
            int adet = sQLiteManagerDB.sqliteConnectionDB.Table<Burclar>().Count();
            switch (burcID)
            {
                case 1 :
                    LogoImage.Source = "logo_koc_secenek.png";
                    break;
                case 2:
                    LogoImage.Source = "logo_boga_secenek.png";
                    break;
                case 3:
                    LogoImage.Source = "logo_ikizler_secenek.png";
                    break;
                case 4:
                    LogoImage.Source = "logo_yengec_secenek.png";
                    break;
                case 5:
                    LogoImage.Source = "logo_aslan_secenek.png";
                    break;
                case 6:
                    LogoImage.Source = "logo_basak_secenek.png";
                    break;
                case 7:
                    LogoImage.Source = "logo_terazi_secenek.png";
                    break;
                case 8:
                    LogoImage.Source = "logo_akrep_secenek.png";
                    break;
                case 9:
                    LogoImage.Source = "logo_yay_secenek.png";
                    break;
                case 10:
                    LogoImage.Source = "logo_oglak_secenek.png";
                    break;
                case 11:
                    LogoImage.Source = "logo_kova_secenek.png";
                    break;
                case 12:
                    LogoImage.Source = "logo_balik_secenek.png";
                    break;
            }
            //BurcAdLabel.Text = sQLiteManagerDB.sqliteConnectionDB.Table<Burclar>().FirstOrDefault(x => x.ID == id).Ad;
        }

        private void BurcYorumlarGit_Clicked(object sender, EventArgs e)
        {
            anaSayfaDetail.BurcYorumlarGit(burcID);
        }

        private void MeslekGit_Clicked(object sender, EventArgs e)
        {
            anaSayfaDetail.MeslekGit(burcID);
        }

        private void UnluGit_Clicked(object sender, EventArgs e)
        {
            anaSayfaDetail.UnluGit(burcID);
        }

        private void HediyeGit_Clicked(object sender, EventArgs e)
        {
            anaSayfaDetail.HediyeGit(burcID);
        }

        private void OzelliklerGit_Clicked(object sender, EventArgs e)
        {
            anaSayfaDetail.OzelliklerGit(burcID);
        }

        private void YukselenOzelliklerGit_Clicked(object sender, EventArgs e)
        {
            anaSayfaDetail.YukselenOzelliklerGit(burcID);
        }

    }
}