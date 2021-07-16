using BurcApp.Views;
using Xamarin.Forms;

namespace BurcApp
{
    public partial class App : Application
    {
        public static string DBName { get; set; } = "Burclopedi.db3";

        public App()
        {
            InitializeComponent();
            MainPage = new AnaSayfa();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
