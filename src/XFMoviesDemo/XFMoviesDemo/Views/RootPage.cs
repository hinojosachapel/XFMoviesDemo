using System;
using Xamarin.Forms;
using Prism.Events;

using XFMoviesDemo.Core.Messages;
using XFMoviesDemo.Core.Models;

namespace XFMoviesDemo.Views
{
    public partial class RootPage : MasterDetailPage
    {
        private const int THRESHOLD = 720;
        private bool _isNarrow = false;

        private static uint _currentMovieId;
        private readonly IPlatformInfo _platformInfo;

        private readonly IEventAggregator _eventAggregator;
        private MovieDetailView _movieDetailView;

        public RootPage(IEventAggregator eventAggregator, IPlatformInfo platformInfo)
        {
            _eventAggregator = eventAggregator;
            _platformInfo = platformInfo;
            eventAggregator.GetEvent<PresentEvent>().Subscribe(OnPresentEventReceived);

            if (platformInfo.IsUWPDesktop)
            {
                eventAggregator.GetEvent<DetailEvent>().Subscribe(OnDetailEventReceived);
            }

            MasterBehavior = MasterBehavior.Default;

            Master = new MoviesView(eventAggregator);
            _movieDetailView = new MovieDetailView();
            Detail = new MyNavigationPage(_movieDetailView);
        }

        private void OnPresentEventReceived(bool isPresented)
        {
            IsPresented = isPresented;
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

            if (_isNarrow)
            {
                IsPresented = false;
            }
           
            Detail = new MyNavigationPage(_movieDetailView);
        }

        /// <summary>
        /// Handles app size changes on UWP Desktop.
        /// </summary>
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (!_platformInfo.IsUWPDesktop || width <= 0)
            {
                return;
            }

            if ((width < THRESHOLD) && (MasterBehavior == MasterBehavior.Default))
            {
                MasterBehavior = MasterBehavior.Popover;
                IsPresented = false;
                _isNarrow = true;
                _eventAggregator.GetEvent<NarrowEvent>().Publish(new Tuple<string, bool>(nameof(MoviesView), _isNarrow));
                return;
            }

            if ((width >= THRESHOLD) && (MasterBehavior == MasterBehavior.Popover))
            {
                this.MasterBehavior = MasterBehavior.Default;
                _isNarrow = false;
                _eventAggregator.GetEvent<NarrowEvent>().Publish(new Tuple<string, bool>(nameof(MoviesView), _isNarrow));
            }
        }
    }
}