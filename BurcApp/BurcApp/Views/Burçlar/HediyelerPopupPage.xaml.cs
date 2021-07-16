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
    public partial class HediyelerPopupPage : PopupPage
    {
        List<string> erkekHediyeler;
        List<string> kadinHediyeler;

        public HediyelerPopupPage(string erkek, string kadin)
        {
            InitializeComponent();

            erkekHediyeler = erkek.Split(',').ToList();
            for (int i = 0; i < erkekHediyeler.Count; i++)
            {
                erkekHediyeler[i] = erkekHediyeler[i].Trim();
            }

            kadinHediyeler = kadin.Split(',').ToList();
            for (int i = 0; i < kadinHediyeler.Count; i++)
            {
                kadinHediyeler[i] = kadinHediyeler[i].Trim();
            }

            listeListView1.ItemsSource = erkekHediyeler;
            listeListView2.ItemsSource = kadinHediyeler;
        }

        private void ListView1_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            ListView listView = (ListView)sender;
            listView.SelectedItem = null;
        }

        private void ListView2_ItemSelected(object sender, SelectedItemChangedEventArgs e)
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