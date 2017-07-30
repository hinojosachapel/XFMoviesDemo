using Windows.System.Profile;
using Prism.Unity;
using Microsoft.Practices.Unity;

namespace XFMoviesDemo.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
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