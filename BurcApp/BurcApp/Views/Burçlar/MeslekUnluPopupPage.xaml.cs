using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BurcApp.Views.Burçlar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeslekUnluPopupPage : PopupPage
    {
        List<string> yazilar;
        public MeslekUnluPopupPage(string yazi)
        {
            InitializeComponent();
            yazilar = yazi.Split(',').ToList();
            for (int i = 0; i < yazilar.Count; i++)
            {
                yazilar[i] = yazilar[i].Trim();
            }
            listeListView.ItemsSource = yazilar;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            ListView listView = (ListView)sender;
            listView.SelectedItem = null;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();
        }
    }
}