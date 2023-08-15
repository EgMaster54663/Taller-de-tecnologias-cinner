using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FrontEnd.Model.Results;
using FrontEnd.Services;
using FrontEnd.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.ViewModel
{
    
    public partial class IndexPageViewModel : BaseViewModel
    {

        //poner en los view models para recuperar parametros
        IDictionary<string, object> parametersAux;
        public IndexPageViewModel(INavigationServices navigationServices) : base(navigationServices)
        {
            parametersAux = navigationServices.Get_Parameters();
        }

        //Discover Page Collections
        public ObservableCollection<ResultDiscoverMovies> discoverMovies { get; set; } = new ObservableCollection<ResultDiscoverMovies>();


        //Search Page Collections
        public ObservableCollection<ResultSearchMovies> searchmoviecol { get; set; } = new ObservableCollection<ResultSearchMovies>();
        public ObservableCollection<ResultSearchPerson> searchpersoncol { get; set; } = new ObservableCollection<ResultSearchPerson>();


        //Favorite Page Collections
        public ObservableCollection<MovieDetails> movieFavoritesCol { get; set; } = new ObservableCollection<MovieDetails>();
        


        //Navigation Id
        [ObservableProperty]
        public string navigationId2 = "";



        //page commands
        [RelayCommand]
        public void LoadDiscoverMovies()
        {
            FrontEnd.Services.Api api = new FrontEnd.Services.Api();

            discoverMovies.Clear();

            api.DiscoverMovies().Results.ForEach(x => discoverMovies.Add(x));
        }

        [RelayCommand]
        public void Search(IDictionary<string, string> parameters)
        {
            //Query
            //MovieOrActor (Movie, Actor)
            //YearOfRelease (2222)

            //Get Parameters
            string Query = parameters.First(x => x.Key == "Query").Value;
            string MovieOrActor = parameters.First(x => x.Key == "MovieOrActor").Value;
            string YearOfRelease = parameters.First(x => x.Key == "YearOfRelease").Value;

            //Instance service
            FrontEnd.Services.Api api = new FrontEnd.Services.Api();

            //Control parameters
            if (MovieOrActor == "Actor")
            {
                //actor
                //Clear the current collection
                searchpersoncol.Clear();


                api.SearchPerson(Query).Results.ForEach(x => searchpersoncol.Add(x));

            }
            else
            {
                //movie
                searchmoviecol.Clear();


                //Clear the YearOfRelease parameter
                if (YearOfRelease != "" && YearOfRelease != null)
                {
                    api.SearchMovie(Query, YearOfRelease).Results.ForEach(x => searchmoviecol.Add(x));
                }
                else
                {
                    api.SearchMovie(Query, "").Results.ForEach(x => searchmoviecol.Add(x));
                }

            }

            

        }

        [RelayCommand]
        public void LoadFavorites()
        {
            // wrote it like this because the compiler got a little confused and started showing ambiguities
            // same reason some variables have numbers
            FrontEnd.Services.Api api = new FrontEnd.Services.Api();
            movieFavoritesCol.Clear();

            foreach (string M in FavoritesService.MovieIds)
            {
                movieFavoritesCol.Add(api.MovieDetails(M));
            }
        }

        //Navigation Commands
        //NOT USED BECAUSE OF SOME EXEPTION (Object reference not set to an instance of an object) raised in NavigationServices ps: the exception is probably elsewere but maui does not want to tell me
        [RelayCommand]
        public void NavigateToMovieDetail(ResultDiscoverMovies movie)
        {
            var IdMovie = movie.Id;
            NavigationId2 = "";
            NavigationId2 = "Movie:" + IdMovie.ToString();



            //this one cant be used in a view model
            //Navigation.PushAsync(new MovieDetailsPage(new MovieDetailsPageViewModel(new NavigationServices())));
            //this method throws exeption
            //NavigationServices.NavigateToAsync(nameof(MovieDetailsPage), new Dictionary<string, object> { { "IdMovie", IdMovie } });

        }
        // poliformysms because i cant be bothered
        // nvm commands have to be unique
        [RelayCommand]
        public void NavigateToMovieDetailString(long id)
        {
            var IdMovie = id;
            NavigationId2 = "";
            NavigationId2 = "Movie:" + IdMovie.ToString();
        }

        [RelayCommand]
        public void NavigateToActorDetail(ResultSearchPerson actor)
        {
            var IdActor = actor.Id;
            NavigationId2 = "";
            NavigationId2 = "Actor:" + IdActor.ToString();



            //this one cant be used in a view model
            //Navigation.PushAsync(new ActorDetailsPage(new ActorDetailsPageViewModel(new NavigationServices())));
            //this method throws exeption
            //NavigationServices.NavigateToAsync(nameof(ActorDetailsPage), new Dictionary<string, object> { { "IdActor", IdActor } });

        }














    }
}
