using BurcApp.CustomRenderer;
using BurcApp.Tools.API;
using BurcApp.ViewModals;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BurcApp.Views.Burçlar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KullaniciYorumlariContentPage : ContentPage
    {
        NetworkAccess networkAccess;
        APIVeriCekme aPIVeriCekme = new APIVeriCekme();
        KullaniciYorumlariViewModal kullaniciYorumlariViewModal = new KullaniciYorumlariViewModal();
        int burcID;

        public KullaniciYorumlariContentPage(int id)
        {
            InitializeComponent();
            burcID = id;
            networkAccess = Connectivity.NetworkAccess;

            if (networkAccess == NetworkAccess.Internet)
            {
                FormLoad();
            }
            else
            {
                DisplayAlert("UYARI", "Lütfen İnternet Ayarlarınızı Kontrol Ediniz!", "TAMAM");
                Navigation.PopAsync();
            }
        }

        private async void FormLoad()
        {
            string parametre = "?KullaniciYorumBurcID=" + burcID.ToString();
            kullaniciYorumlariViewModal = await aPIVeriCekme.GetKullaniciYorumlari(parametre);
            if (!kullaniciYorumlariViewModal.Hata)
            {
                YorumlarListView.ItemsSource = kullaniciYorumlariViewModal.kullaniciBurcYorumu;
                YorumlarListView.IsVisible = true;
            }
            else
            {
                DisplayAlert("MESAJ", "Henüz Yorum Bulunmamaktadır. \nİlk Yorumu Siz Yazın", "TAMAM");
            }
            yuklemeIndicator.IsRunning = false;
            yuklemeIndicator.IsVisible = false;
            YorumYazAbsoluteLayout.IsVisible = true;
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            ViewCell viewCell = (ViewCell)sender;
            CustomLabelJustify customLabelJustify = (CustomLabelJustify)viewCell.View.FindByName("YorumLabel");
            Label devamlabel = (Label)viewCell.View.FindByName("DevamiLabel");

            if (customLabelJustify.MaxLines == 3)
            {
                customLabelJustify.MaxLines = 1000;
                customLabelJustify.LineBreakMode = LineBreakMode.WordWrap;
                devamlabel.Text = "";
            }
        }

        private void ViewCell_Appearing(object sender, EventArgs e)
        {
            ViewCell viewCell = (ViewCell)sender;
            CustomLabelJustify customLabelJustify = (CustomLabelJustify)viewCell.View.FindByName("YorumLabel");
            Label devamlabel = (Label)viewCell.View.FindByName("DevamiLabel");

            if(customLabelJustify.Text.Length > 140)
            {
                devamlabel.Text = "  Devamını Oku";
            }
            else
            {
                devamlabel.Text = "";
            }
        }

        private void YorumlarListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            ListView listView = (ListView)sender;
            listView.SelectedItem = null;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new YorumYazContentPage(burcID));
        }
    }
}