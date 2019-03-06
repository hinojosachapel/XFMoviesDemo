using Prism.Events;
using Prism.Navigation;
using Xamarin.Forms;

using XFMoviesDemo.Constants;
using XFMoviesDemo.Core.Messages;
using XFMoviesDemo.Core.Models;

namespace XFMoviesDemo.ViewModels
{
    public class MyMasterDetailViewModel : BaseViewModel
    {
        private static uint _currentMovieId;
        private readonly IEventAggregator _eventAggregator;
        private readonly INavigationService _navigationService;

        public MyMasterDetailViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;

            if (Device.Idiom == TargetIdiom.Desktop || Device.Idiom == TargetIdiom.Tablet)
            {
                eventAggregator.GetEvent<DetailEvent>().Subscribe(OnDetailEventReceived);
            }
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
            _navigationService.NavigateAsync($"{NavigationKeys.MyNavigationPage}/{NavigationKeys.MovieDetailView}");
            _eventAggregator.GetEvent<DetailEvent>().Publish(selectedItem);
        }
    }
}