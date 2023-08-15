using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FrontEnd.Model.Results;
using FrontEnd.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.ViewModel
{
    
    public partial class MovieDetailsPageViewModel : BaseViewModel
    {
        public MovieDetailsPageViewModel(INavigationServices navigationServices) : base(navigationServices)
        {

        }

        [ObservableProperty]
        public MovieDetails movieDetails;
        [ObservableProperty]
        public string movieTrailer;
        [ObservableProperty]
        public ObservableCollection<Backdrop> movieImages = new ObservableCollection<Backdrop>();


        [RelayCommand]
        public void LoadMovieDetails(string Id)
        {
            Api api = new Api();
            MovieDetails = api.MovieDetails(Id);
        }

        [RelayCommand]
        public void LoadMovieTrailer(string Id)
        {
            Api api = new Api();
            MovieTrailer = "https://www.youtube.com/embed/" + api.MovieVideos(Id).Results.FirstOrDefault(x => x.Type == "Trailer").Key;
        }

        [RelayCommand]
        public void LoadMovieImages(string Id)
        {
            Api api = new Api();
            List<Backdrop> resultaux = new List<Backdrop>();
            resultaux = api.MovieImages(Id).backdrops;
            for (int i = 0; i < resultaux.Count - 1; i++)
            {
                MovieImages.Add(resultaux[i]);
                if (i > 5)
                {
                    break;
                }
            }
            
        }



    }
}
