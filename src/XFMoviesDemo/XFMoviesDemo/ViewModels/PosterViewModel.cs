using System;
using Prism.Navigation;

using XFMoviesDemo.Constants;

namespace XFMoviesDemo.ViewModels
{
    public class PosterViewModel : BaseViewModel
    {
        private string _poster = String.Empty;
        public string Poster
        {
            get { return _poster; }
            set { SetProperty(ref _poster, value); }
        }

        public PosterViewModel()
        {
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Title = (string)parameters[Params.Title];
            Poster = (string)parameters[Params.Poster];
        }
    }
}