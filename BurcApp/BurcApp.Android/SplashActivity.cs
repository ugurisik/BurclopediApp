
using Android.App;
using Android.Media;
using Android.Widget;
using AndroidX.AppCompat.App;
using System.Threading.Tasks;
using static Android.Media.MediaPlayer;

namespace BurcApp.Droid
{
    [Activity(Label = "Burçlopedi", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity, IOnCompletionListener
    {
        VideoView videoView;
        protected override void OnResume()
        {
            base.OnResume();

            SetContentView(Resource.Layout.layout1);

            var videoPath = $"android.resource://{PackageName}/{Resource.Raw.Logo}";
            videoView = FindViewById<VideoView>(Resource.Id.videoView);
            videoView.SetMediaController(null);
            videoView.SetOnCompletionListener(this);
            videoView.SetVideoPath(videoPath);
            videoView.RequestFocus();
            videoView.Start();         
        }

        public void OnCompletion(MediaPlayer mp)
        {
            Task.Delay(1).ContinueWith(t =>
            {
                StartActivity(typeof(MainActivity));
                Finish();
            });
        }
    }
}