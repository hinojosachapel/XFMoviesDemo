using Prism;
using Prism.Ioc;

namespace XFMoviesDemo.UWP
{
    public sealed partial class MainPage : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        public MainPage()
        {
            InitializeComponent();
            LoadApplication(new XFMoviesDemo.App(this));
        }
    }
}