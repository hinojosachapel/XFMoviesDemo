using Prism.Events;
using XFMoviesDemo.Constants;
using XFMoviesDemo.Core.Messages;

namespace XFMoviesDemo.Views
{
    public partial class MoviesView
    {
        private readonly IEventAggregator _eventAggregator;

        public MoviesView(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            _eventAggregator = eventAggregator;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // If the root page is a MasterDetailPage (UWP Desktop scenario or tablet), and MoviesView is its Master page,
            // we can't use MoviesViewModel.OnNavigatedTo() because MoviesView is not navigated to, so we use
            // the EventAggregator as a general solution. Note that MoviesViewModel.OnNavigatedTo() would be
            // executed on a phone because in that scenario, MoviesView it is navigated to.
            _eventAggregator.GetEvent<AppearingEvent>().Publish(NavigationKeys.MoviesView);
        }
    }
}