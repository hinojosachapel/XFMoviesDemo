using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms.Xaml;

using XFMoviesDemo.Core.Services;
using XFMoviesDemo.Views;

// https://developer.xamarin.com/guides/xamarin-forms/user-interface/xaml-basics/xamlc/
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XFMoviesDemo
{
    public partial class App : PrismApplication
    {
        public static bool IsUWPDesktop { get; set; }
        public static bool IsUWPMobile { get; set; }
        public static bool IsWinPhone { get; set; }
        public static bool IsWinRT { get; set; }

        protected override void OnInitialized()
        {
            InitializeComponent();

            if (IsUWPDesktop || IsWinRT)
            {
                NavigationService.Navigate(nameof(RootPage));
            }
            else
            {
                NavigationService.Navigate($"{nameof(MyNavigationPage)}/{nameof(MoviesView)}");
            }
        }

        protected override void RegisterTypes()
        {
            var platformInfo = new PlatformInfo(IsUWPDesktop, IsUWPMobile, IsWinPhone, IsWinRT);

            Container.RegisterInstance<IPlatformInfo>(platformInfo);
            Container.RegisterInstance<IMoviesService>(new MoviesService());
            
            Container.RegisterTypeForNavigation<MyNavigationPage>();
            Container.RegisterTypeForNavigation<MoviesView>();
            Container.RegisterTypeForNavigation<MovieDetailView>();
            Container.RegisterTypeForNavigation<RootPage>();
            Container.RegisterTypeForNavigation<PosterView>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}