using BurcApp.Helper;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Net.Mail;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BurcApp.Views.Burçlar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class YorumYazContentPage : ContentPage
    {
        NetworkAccess networkAccess;
        int burcID;

        public YorumYazContentPage(int id)
        {
            InitializeComponent();
            networkAccess = Connectivity.NetworkAccess;
            burcID = id;
        }

        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (networkAccess == NetworkAccess.Internet)
                {
                    if (!string.IsNullOrEmpty(mailEntry.Text) && !string.IsNullOrEmpty(KadiEntry.Text) && !string.IsNullOrEmpty(YorumEditor.Text))
                    {
                        bool b = IsValid(mailEntry.Text.Trim());
                        if (b)
                        {
                            string URL = "http://yazilimdelisi.com/api/burclopedi/burclopedi_api/index.php";
                            WebClient webClient = new WebClient();
                            NameValueCollection veri = new NameValueCollection();
                            veri["BurcID"] = burcID.ToString();
                            veri["KullaniciAd"] = KadiEntry.Text;
                            veri["Mail"] = mailEntry.Text;
                            veri["Yorum"] = YorumEditor.Text;
                            byte[] gonder = webClient.UploadValues(URL, "POST", veri);
                            string islem = Encoding.UTF8.GetString(gonder);
                            //PostKullaniciYorum postKullaniciYorum = JsonConvert.DeserializeObject<PostKullaniciYorum>(islem);
                            webClient.Dispose();

                            if (Device.RuntimePlatform == Device.Android)
                            {
                                DependencyService.Get<IToastMessage>().MesajGoster("Yorumunuz Gönderildi.");
                            }
                            if (Device.RuntimePlatform == Device.iOS)
                            {
                                DisplayAlert("MESAJ", "Yorumunuz Gönderildi", "TAMAM");
                            }

                            //if (!postKullaniciYorum.Hata)
                            //{
                            //    if (Device.RuntimePlatform == Device.Android)
                            //    {
                            //        DependencyService.Get<IToastMessage>().MesajGoster(postKullaniciYorum.Bilgi);
                            //    }
                            //    if (Device.RuntimePlatform == Device.iOS)
                            //    {
                            //        DisplayAlert("MESAJ", postKullaniciYorum.Bilgi, "TAMAM");
                            //    }
                            //}
                            //else
                            //{
                            //    DisplayAlert("UYARI", "Beklenmedik Bir Hata Oluştu! \nLüfen Daha Sonra Tekrar Deneyiniz.", "TAMAM");
                            //}
                            Navigation.PopModalAsync();
                        }
                        else
                        {
                            DisplayAlert("UYARI", "Lütfen Geçerli Mail Adresi Yazınız!", "TAMAM");
                        }
                    }
                    else
                    {
                        DisplayAlert("UYARI", "Lütfen Tüm Alanları Doldurunuz!", "TAMAM");
                    }
                }
                else
                {
                    DisplayAlert("UYARI", "Lütfen İnternet Ayarlarınızı Kontrol Ediniz!", "TAMAM");
                    Navigation.PopModalAsync();
                }
            }
            catch
            {
                DisplayAlert("UYARI", "Beklenmedik Bir Hata Oluştu! \nLüfen Tekrar Deneyiniz.", "TAMAM");
            }
            
        }
    }
}