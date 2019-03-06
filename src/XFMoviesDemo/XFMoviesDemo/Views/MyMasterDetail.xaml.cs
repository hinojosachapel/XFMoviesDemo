using Prism.Navigation;
using Xamarin.Forms;

namespace XFMoviesDemo.Views
{
    public partial class MyMasterDetail : MasterDetailPage, IMasterDetailPageOptions
    {
        // Allows to load movies content on iPad
        private bool _navigated = false;

        public MyMasterDetail(MoviesView masterView)
        {
            InitializeComponent();
            Master = masterView;
        }

        public bool IsPresentedAfterNavigation
        {
            get
            {
                bool result = !_navigated;

                if (!_navigated)
                {
                    _navigated = true;
                }

                return result;
            }
        }
    }
}