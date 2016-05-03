using Prism.Events;
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
            _eventAggregator.GetEvent<AppearingEvent>().Publish(nameof(MoviesView));
        }
    }
}
