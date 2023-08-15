using FrontEnd.Services;
using FrontEnd.ViewModel;

namespace FrontEnd.Views;

public partial class MovieDetailsPage : ContentPage
{
    MovieDetailsPageViewModel viewModelaux;

	public MovieDetailsPage(MovieDetailsPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}

    public MovieDetailsPage(MovieDetailsPageViewModel viewModel, string Id)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
        viewModelaux = viewModel;

        //Load Command call
        viewModelaux.LoadMovieDetails(Id);
        viewModelaux.LoadMovieTrailer(Id);
        viewModelaux.LoadMovieImages(Id);
        //Adjust Favorite Button
        //FavoritesService favoritesService = new FavoritesService();
        bool favorite = FavoritesService.MovieIds.Exists(x => x == Id);
        if (favorite)
        {
            FavoriteButton.IconImageSource = "starfilled.svg";
        }

    }

    //Add to favorites
    private void FavoriteButton_Clicked(object sender, EventArgs e)
    {
        //FavoritesService favoritesService = new FavoritesService();

        if (FavoritesService.MovieIds.Exists(x => x == viewModelaux.MovieDetails.Id.ToString()))
        {
            FavoritesService.MovieIds.Remove(viewModelaux.MovieDetails.Id.ToString());
            FavoriteButton.IconImageSource = "star.svg";
        }
        else
        {
            FavoritesService.MovieIds.Add(viewModelaux.MovieDetails.Id.ToString());
            FavoriteButton.IconImageSource = "starfilled.svg";
        }
    }

    

}