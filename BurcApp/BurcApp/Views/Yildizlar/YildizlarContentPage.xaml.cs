using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BurcApp.Views.Yildizlar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class YildizlarContentPage : ContentPage
    {
        public YildizlarContentPage()
        {
            InitializeComponent();
        }

        private void GunesButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GunesYildizContentPage());
        }

        private void MerkurButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MerkurYildizContentPage());
        }

        private void MarsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MarsYildizContentPage());
        }

        private void SaturnButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SaturnYildizContentPage());
        }

        private void NeptunButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NeptunYildizContentPage());
        }

        private void AyButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AyYildizContentPage());
        }

        private void VenusButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VenusYildizContentPage());
        }

        private void JupiterButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new JupiterYildizContentPage());
        }

        private void UranusButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UranusYildizContentPage());
        }

        private void PlutonButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PlutonYildizContentPage());
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
    }
}