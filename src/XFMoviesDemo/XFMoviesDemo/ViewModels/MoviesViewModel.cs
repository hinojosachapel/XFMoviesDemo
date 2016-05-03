﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Prism.Events;
using Prism.Commands;
using Prism.Navigation;

using XFMoviesDemo.Core.Messages;
using XFMoviesDemo.Core.Models;
using XFMoviesDemo.Core.Services;
using XFMoviesDemo.Views;

namespace XFMoviesDemo.ViewModels
{
    public class MoviesViewModel : BaseViewModel
    {
        private readonly IMoviesService _moviesService;
        private readonly IPlatformInfo _platformInfo;
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;
        private bool _isNarrow;

        public DelegateCommand<MovieModel> ItemTapedCommand { get; set; }
        public DelegateCommand<Image> ImageTapedCommand { get; set; }

        private ObservableCollection<MovieModel> _movies;
        public ObservableCollection<MovieModel> Movies
        {
            get { return _movies; }
            set { SetProperty(ref _movies, value); }
        }

        private static uint _currentMovieId;

        private MovieModel _selectedMovie;
        public MovieModel SelectedMovie
        {
            get { return _selectedMovie; }
            set
            {
                if (SetProperty(ref _selectedMovie, value) && _selectedMovie != null)
                    _currentMovieId = _selectedMovie.Id;
            }
        }

        private bool _connectionRequired;

        public bool ConnectionRequired
        {
            get { return _connectionRequired; }
            set { SetProperty(ref _connectionRequired, value); }
        }
        
        public MoviesViewModel(IEventAggregator eventAggregator, IMoviesService moviesService, IPlatformInfo platformInfo, INavigationService navigationService)
        {
            _eventAggregator = eventAggregator;
            _moviesService = moviesService;
            _platformInfo = platformInfo;
            _navigationService = navigationService;

            ItemTapedCommand = new DelegateCommand<MovieModel>(ItemTaped);
            ImageTapedCommand = new DelegateCommand<Image>(ImageTaped);

            Title = "Movies Demo";

            eventAggregator.GetEvent<AppearingEvent>().Subscribe(OnAppearingEventReceived);
            eventAggregator.GetEvent<NarrowEvent>().Subscribe(OnNarrowEventReceived);
        }

        private void OnAppearingEventReceived(string senderView)
        {
            if (senderView == nameof(MoviesView) && (Movies == null))
            {
                Start();
            }
        }

        private void OnNarrowEventReceived(Tuple<string, bool> sender)
        {
            if (sender.Item1 == nameof(MoviesView))
            {
                _isNarrow = sender.Item2;
            }
        }

        private async void ImageTaped(Image image)
        {
            image.Opacity = 0.0;
            await image.FadeTo(1.0, 100);
            _eventAggregator.GetEvent<PresentEvent>().Publish(false);
        }

        private async void Start()
        {
            try
            {
                IsBusy = true;
                ConnectionRequired = false;

                var movieList = await _moviesService.GetMovies();
                Movies = new ObservableCollection<MovieModel>(movieList.OrderByDescending(m => m.RelaseDate).Take(3 * 15));

                if (_platformInfo.IsUWPDesktop || _platformInfo.IsWinRT)
                {
                    SelectedMovie = (_currentMovieId != 0) ?
                        Movies.FirstOrDefault(m => m.Id == _currentMovieId) :
                        Movies.First();

                    _eventAggregator.GetEvent<DetailEvent>().Publish(SelectedMovie);
                }
            }
            catch (Exception)
            {
                ConnectionRequired = true;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void ItemTaped(MovieModel selectedItem)
        {
            if (selectedItem == null)
            {
                return;
            }

            if (!(_platformInfo.IsUWPDesktop || _platformInfo.IsWinRT))
            {
                SelectedMovie = null;
                _navigationService.Navigate(nameof(MovieDetailView));
            }

            _eventAggregator.GetEvent<DetailEvent>().Publish(selectedItem);
        }
    }
}
