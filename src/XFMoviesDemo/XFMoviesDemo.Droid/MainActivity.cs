using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.OS;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

// Goodbye FormsApplicationActivity, Hello FormsAppCompatActivity
// https://blog.xamarin.com/material-design-for-your-xamarin-forms-android-apps/
// https://blog.xamarin.com/android-tips-hello-material-design-v7-appcompat/

namespace XFMoviesDemo.Droid
{
    [Activity(
        Icon = "@drawable/icon",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        WindowSoftInputMode = SoftInput.AdjustPan)]
    public class MainActivity : FormsAppCompatActivity, IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.tabs;
            ToolbarResource = Resource.Layout.toolbar;

            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            LoadApplication(new App(this));
        }
    }
}