using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using XFMoviesDemo.Core.Messages;
using XFMoviesDemo.Core.Models;
using XFMoviesDemo.Views;

namespace XFMoviesDemo.ViewModels
{
    public class MyMasterDetailViewModel : BaseViewModel
    {
        private static uint _currentMovieId;
        private readonly IEventAggregator _eventAggregator;
        private readonly INavigationService _navigationService;

        public MyMasterDetailViewModel(INavigationService navigationService, IEventAggregator eventAggregator, IPlatformInfo platformInfo)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;

            if (platformInfo.IsUWPDesktop)
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
            _navigationService.NavigateAsync($"{nameof(MyNavigationPage)}/{nameof(MovieDetailView)}");
            _eventAggregator.GetEvent<DetailEvent>().Publish(selectedItem);
        }
    }
}