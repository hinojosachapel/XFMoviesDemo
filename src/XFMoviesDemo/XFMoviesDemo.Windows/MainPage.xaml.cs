namespace XFMoviesDemo.Windows
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            XFMoviesDemo.App.IsWinRT = true;

            LoadApplication(new XFMoviesDemo.App());
        }
    }
}