using Prism.Events;
using Prism.Navigation;
using Microsoft.Practices.Unity;
using Xamarin.Forms;

namespace XFMoviesDemo.Views
{
    public partial class MyMasterDetail : MasterDetailPage, IMasterDetailPageOptions
    {
        public MyMasterDetail(IUnityContainer container)
        {
            InitializeComponent();
            Master = container.Resolve<MoviesView>();
        }

        public bool IsPresentedAfterNavigation
        {
            get { return Device.Idiom != TargetIdiom.Phone; }
        }
    }
}