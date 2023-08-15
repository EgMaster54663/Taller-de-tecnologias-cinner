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
    public partial class ActorDetailsPageViewModel : BaseViewModel
    {
        public ActorDetailsPageViewModel(INavigationServices navigationServices) : base(navigationServices)
        {

        }


        [ObservableProperty]
        public PeopleDetails actorDetails1;
        [ObservableProperty]
        public ObservableCollection<Profile> actorImages = new ObservableCollection<Profile>();
        [ObservableProperty]
        public ObservableCollection<Cast> castedInCollection = new ObservableCollection<Cast>();

        

        [RelayCommand]
        public void LoadActorDetails(string Id)
        {
            Api api = new Api();
            ActorDetails1 = api.PeopleDetails(Id);

        }
        [RelayCommand]
        public void LoadActorImages(string Id)
        {
            Api api = new Api();
            api.PeopleImages(Id).profiles.ForEach(x => ActorImages.Add(x));
        }
        [RelayCommand]
        public void LoadCastDetails(string Id)
        {
            Api api = new Api();
            List<Cast> castaux = api.MovieCredits(Id).cast;
            for (int i = 0; i < castaux.Count; i++)
            {
                CastedInCollection.Add(castaux[i]);
                if (i > 4)
                {
                    break;
                }
            }
        }


        //For Navigation
        [RelayCommand]
        public void NavigateToMovieDetailString(long id)
        {
            var IdMovie = id;
            NavigationId2 = "";
            NavigationId2 = "Movie:" + IdMovie.ToString();
        }

        //Navigation Id
        [ObservableProperty]
        public string navigationId2 = "";
    }
}
