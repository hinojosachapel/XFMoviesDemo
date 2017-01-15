using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.OS;
using Prism.Unity;
using Microsoft.Practices.Unity;
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
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.tabs;
            ToolbarResource = Resource.Layout.toolbar;

            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {

        }
    }
}