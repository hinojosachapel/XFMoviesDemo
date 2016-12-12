using Prism.Events;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

using XFMoviesDemo.Constants;
using XFMoviesDemo.Core.Messages;
using XFMoviesDemo.Core.Models;
using XFMoviesDemo.Views;

namespace XFMoviesDemo.ViewModels
{
    public class MovieDetailViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        public DelegateCommand<Image> ImageTapedCommand { get; set; }

        private MovieModel _movie;
        public MovieModel Movie
        {
            get { return _movie; }
            set { SetProperty(ref _movie, value); }
        }

        public MovieDetailViewModel(IEventAggregator eventAggregator, INavigationService navigationService)
        {
            _navigationService = navigationService;
            ImageTapedCommand = new DelegateCommand<Image>(ImageTaped);
            eventAggregator.GetEvent<DetailEvent>().Subscribe(OnDetailEventReceived);
        }

        private void OnDetailEventReceived(MovieModel selectedItem)
        {
            if (selectedItem?.Id != Movie?.Id)
            {
                Movie = selectedItem;
                Title = Movie.Title;
            }
        }

        private async void ImageTaped(Image image)
        {
            await image.FadeTo(0.4, 100);
            await System.Threading.Tasks.Task.Delay(100);
            await image.FadeTo(1.0, 50);

            NavigationParameters parameters = new NavigationParameters();
            parameters.Add(Param.Title, Title);
            parameters.Add(Param.Poster, Movie.LargePoster);
            await _navigationService.NavigateAsync(nameof(PosterView), parameters);
        }
    }
}
