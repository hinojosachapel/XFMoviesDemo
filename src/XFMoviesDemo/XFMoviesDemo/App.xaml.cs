using Prism;
using Prism.Ioc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XFMoviesDemo.Constants;
using XFMoviesDemo.Core.Services;
using XFMoviesDemo.Views;

// https://developer.xamarin.com/guides/xamarin-forms/user-interface/xaml-basics/xamlc/
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XFMoviesDemo
{
    public partial class App
    {
        public static bool IsDesktopOrTablet
        {
            get { return Device.Idiom == TargetIdiom.Desktop || Device.Idiom == TargetIdiom.Tablet; }
        }

        public App(IPlatformInitializer initializer)
            : this(initializer, true)
        {

        }

        public App(IPlatformInitializer initializer, bool setFormsDependencyResolver)
            : base(initializer, setFormsDependencyResolver)
        {

        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            string name;

            if (IsDesktopOrTablet)
            {
                Resources["ListTitleFontSize"] = 20;
                Resources["ListSubtitleFontSize"] = 16;
                Resources["DetailFontSize"] = 18;

                name = $"{NavigationKeys.MyMasterDetail}/{NavigationKeys.MyNavigationPage}/{NavigationKeys.MovieDetailView}";
            }
            else
            {
                name = $"{NavigationKeys.MyNavigationPage}/{NavigationKeys.MoviesView}";
            }

            NavigationService.NavigateAsync(name);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance<IMoviesService>(new MoviesService());

            containerRegistry.RegisterForNavigation<MyNavigationPage>();
            containerRegistry.RegisterForNavigation<MyMasterDetail>();
            containerRegistry.RegisterForNavigation<MoviesView>();
            containerRegistry.RegisterForNavigation<MovieDetailView>();
            containerRegistry.RegisterForNavigation<PosterView>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Support IApplicationLifecycleAware
            base.OnSleep();

            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Support IApplicationLifecycleAware
            base.OnResume();

            // Handle when your app resumes
        }
    }
}