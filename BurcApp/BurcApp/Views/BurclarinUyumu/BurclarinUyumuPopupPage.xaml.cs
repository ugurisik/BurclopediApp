using BurcApp.Modals;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Forms.Xaml;

namespace BurcApp.Views.BurclarinUyumu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BurclarinUyumuPopupPage : PopupPage
    {

        public BurclarinUyumuPopupPage(BurcUyumu burcUyumu)
        {
            InitializeComponent();
            cevapLabel.Text = burcUyumu.Uyum;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();
        }
    }
}