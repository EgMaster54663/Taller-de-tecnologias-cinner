using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using FrontEnd.Model.Results;

namespace FrontEnd.Services
{
    public class Api
    {
        //ObservableCollection<ResultDiscoverMovies> ListaPelicula { get; set; } = new ObservableCollection<ResultDiscoverMovies>();
        public string ApiBuilder(string url,string filtro)
        {
            UriBuilder builder = new UriBuilder(url);
            builder.Query = "api_key=80510a5f0d6ff6294270dda32b26804d&query="+filtro;

            HttpClient client = new HttpClient();

            var result = client.GetAsync(builder.Uri).Result;
            var json = string.Empty;
            using (StreamReader sr = new StreamReader(result.Content.ReadAsStreamAsync().Result))
            {
                json = sr.ReadToEnd();
            }
            return json;

        }
    
        //Discover
        public  DiscoverMovies DiscoverMovies()
        {
            string json = ApiBuilder("https://api.themoviedb.org/3/discover/movie", "");
            DiscoverMovies Retorno = JsonConvert.DeserializeObject<DiscoverMovies>(json);
            return Retorno;
        } 

        //Misc
        public MovieCredits MovieCredits(string person_id)
        {
            string json = ApiBuilder($"https://api.themoviedb.org/3/person/{person_id}/movie_credits", "");
            MovieCredits Retorno = JsonConvert.DeserializeObject<MovieCredits>(json);
            return Retorno;
        }
        public MovieVideos MovieVideos(string movie_id)
        {
            string json = ApiBuilder($"https://api.themoviedb.org/3/movie/{movie_id}/videos", "");
            MovieVideos Retorno = JsonConvert.DeserializeObject<MovieVideos>(json);
            return Retorno;
        }
        public MovieImages MovieImages(string movie_id)
        {
            string json = ApiBuilder($"https://api.themoviedb.org/3/movie/{movie_id}/images", "");
            MovieImages Retorno = JsonConvert.DeserializeObject<MovieImages>(json);
            return Retorno;
        }
        public PeopleImages PeopleImages(string person_id)
        {
            string json = ApiBuilder($"https://api.themoviedb.org/3/person/{person_id}/images", "");
            PeopleImages Retorno = JsonConvert.DeserializeObject<PeopleImages>(json);
            return Retorno;
        }

        //Searches
        public SearchMovie SearchMovie(string query, string release)
        {
            string json = "";
            if (release != null && release != "")
            {
                json = ApiBuilder($"https://api.themoviedb.org/3/search/movie", query + "&primary_release_year=" + release);
            } else
            {
                json = ApiBuilder($"https://api.themoviedb.org/3/search/movie", query);
            }
            
            SearchMovie Retorno = JsonConvert.DeserializeObject<SearchMovie>(json);
            return Retorno;
        }
        public SearchPerson SearchPerson(string query)
        {
            string json = ApiBuilder($"https://api.themoviedb.org/3/search/person", query);
            SearchPerson Retorno = JsonConvert.DeserializeObject<SearchPerson>(json);
            return Retorno;
        }


        //Details
        public PeopleDetails PeopleDetails(string person_id)
        {
            string json = ApiBuilder($"https://api.themoviedb.org/3/person/{person_id}", "");
            PeopleDetails Retorno = JsonConvert.DeserializeObject<PeopleDetails>(json);
            return Retorno;
        }
        public MovieDetails MovieDetails(string movie_id)
        {
            string json = ApiBuilder($"https://api.themoviedb.org/3/movie/{movie_id}", "");
            MovieDetails Retorno = JsonConvert.DeserializeObject<MovieDetails>(json);
            return Retorno;
        }

    }
}
