using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BurcApp.Views.Elementler
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ElementlerContentPage : ContentPage
    {
        public ElementlerContentPage()
        {
            InitializeComponent();
        }

        private void AtesElementButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AtesElementContentPage());
        }

        private void TorakElementButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ToprakElementContentPage());
        }

        private void SuElementButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SuElementContentPage());
        }

        private void HavaElementButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HavaElementContentPage());
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