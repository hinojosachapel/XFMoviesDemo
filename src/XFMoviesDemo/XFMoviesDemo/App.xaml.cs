using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XFMoviesDemo.Core.Services;
using XFMoviesDemo.Views;

// https://developer.xamarin.com/guides/xamarin-forms/user-interface/xaml-basics/xamlc/
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XFMoviesDemo
{
    public partial class App : PrismApplication
    {
        public static bool IsUWPDesktop
        {
            get { return Device.Idiom == TargetIdiom.Desktop; }
        }

        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            string name;

            if (IsUWPDesktop)
            {
                Resources["ListTitleFontSize"] = 20;
                Resources["ListSubtitleFontSize"] = 16;
                Resources["DetailFontSize"] = 18;

                name = $"{nameof(MyMasterDetail)}/{nameof(MyNavigationPage)}/{nameof(MovieDetailView)}";
            }
            else
            {
                name = $"{nameof(MyNavigationPage)}/{nameof(MoviesView)}";
            }

            NavigationService.NavigateAsync(name, animated: false);
        }

        protected override void RegisterTypes()
        {
            Container.RegisterInstance<IMoviesService>(new MoviesService());
            
            Container.RegisterTypeForNavigation<MyNavigationPage>();
            Container.RegisterTypeForNavigation<MyMasterDetail>();
            Container.RegisterTypeForNavigation<MoviesView>();
            Container.RegisterTypeForNavigation<MovieDetailView>();
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