
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BurcApp.Views.Burçlar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BurcYorumlarıTabbedPage : TabbedPage
    {
        public BurcYorumlarıTabbedPage(int id)
        {
            InitializeComponent();

            GunlukBurcYorumlariContentPage gunlukBurcYorumlariContentPage = new GunlukBurcYorumlariContentPage(id);
            HaftalikBurcYorumlariContentPage haftalikBurcYorumlariContentPage = new HaftalikBurcYorumlariContentPage(id);

            this.Children.Add(gunlukBurcYorumlariContentPage);
            this.Children.Add(haftalikBurcYorumlariContentPage);
        }
    }
}