using Windows.System.Profile;

namespace XFMoviesDemo.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            XFMoviesDemo.App.IsUWPDesktop = AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Desktop";
            XFMoviesDemo.App.IsUWPMobile = AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile";

            LoadApplication(new XFMoviesDemo.App());
        }
    }
}
