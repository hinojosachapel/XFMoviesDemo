using Prism.Navigation;
using Xamarin.Forms;

namespace XFMoviesDemo.Views
{
    public partial class MyNavigationPage : NavigationPage, INavigationPageOptions
    {
        public MyNavigationPage()
        {
            InitializeComponent();
        }

        public bool ClearNavigationStackOnNavigation
        {
            get { return true; }
        }
    }
}