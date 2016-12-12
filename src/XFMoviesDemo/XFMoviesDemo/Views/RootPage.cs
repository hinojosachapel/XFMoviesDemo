using Xamarin.Forms;
using Prism.Events;

using XFMoviesDemo.Core.Messages;
using XFMoviesDemo.Core.Models;

namespace XFMoviesDemo.Views
{
    public partial class RootPage : MasterDetailPage
    {
        private static uint _currentMovieId;

        private readonly IEventAggregator _eventAggregator;
        private MovieDetailView _movieDetailView;

        public RootPage(IEventAggregator eventAggregator, IPlatformInfo platformInfo)
        {
            _eventAggregator = eventAggregator;

            if (platformInfo.IsUWPDesktop)
            {
                eventAggregator.GetEvent<DetailEvent>().Subscribe(OnDetailEventReceived);
            }

            MasterBehavior = MasterBehavior.Default;

            Master = new MoviesView(eventAggregator);
            _movieDetailView = new MovieDetailView();
            Detail = new MyNavigationPage(_movieDetailView);
        }

        /// <summary>
        /// Handles DetailEvent received event on UWP Desktop.
        /// </summary>
        private void OnDetailEventReceived(MovieModel selectedItem)
        {
            if (selectedItem.Id == _currentMovieId)
            {
                return;
            }

            _currentMovieId = selectedItem.Id;
           
            Detail = new MyNavigationPage(_movieDetailView);
        }
    }
}