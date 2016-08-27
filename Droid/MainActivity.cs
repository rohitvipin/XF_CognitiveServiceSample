
using Android.App;
using Android.Content.PM;
using Android.OS;
using Acr.UserDialogs;
using Xamarin.Forms.Platform.Android;
using Android.Views;
using Android.Graphics;

namespace XF_CognitiveServiceSample.Droid
{
    [Activity(Label = "XF_CognitiveServiceSample.Droid", Icon = "@drawable/icon", Theme = "@style/MyCustomTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Forms.Forms.Init(this, savedInstanceState);

            ActionBar.SetIcon(Color.Transparent);
            Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);


            UserDialogs.Init(this);

            LoadApplication(new App());
        }
    }
}

