using Windows.System.Profile;
using Prism.Unity;
using Microsoft.Practices.Unity;

namespace XFMoviesDemo.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            XFMoviesDemo.App.IsUWPDesktop = AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Desktop";
            XFMoviesDemo.App.IsUWPMobile = AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile";

            LoadApplication(new XFMoviesDemo.App(new UwpInitializer()));
        }
    }

    public class UwpInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {

        }
    }
}