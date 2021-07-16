using MarcTron.Plugin;
using System.Threading.Tasks;

namespace BurcApp.Tools.Reklamlar
{
    public class GecisReklami
    {
        public static bool _Durum { get; set; }

        public static int _TiklamaSayisi { get; set; }

        public static int KacKereTiklandi { get; set; }

        public static async Task ReklamDoldur()
        {
            if (!CrossMTAdmob.Current.IsInterstitialLoaded())
            {
                CrossMTAdmob.Current.UserPersonalizedAds = true;
                CrossMTAdmob.Current.LoadInterstitial("ca-app-pub-1213564589342198/5448755653");

                //test id
                //CrossMTAdmob.Current.LoadInterstitial("ca-app-pub-3940256099942544/1033173712");
                
            }
        }

        public static void ReklamGoster()
        {
            if (CrossMTAdmob.Current.IsInterstitialLoaded())
            {
                CrossMTAdmob.Current.ShowInterstitial();
            }
        }
    }
}
