
using Android.App;
using Android.OS;
using System.Threading;

namespace LocalDataBaseDemo.Droid
{
    [Activity(Label = "SplashScreenActivity", Theme = "@style/splashTheme", MainLauncher = true, NoHistory = true)]
    public class SplashScreenActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Thread.Sleep(2000);
            // Create your application here
            StartActivity(typeof(MainActivity));
        }
    }
}