using FrontEnd.Services;
using FrontEnd.ViewModel;

namespace FrontEnd.Views;

public partial class ActorDetailsPage : ContentPage
{
    ActorDetailsPageViewModel viewModelaux;
	public ActorDetailsPage(ActorDetailsPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}

    public ActorDetailsPage(ActorDetailsPageViewModel viewModel, string Id)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
        viewModelaux = viewModel;

        //load Command call
        viewModelaux.LoadActorDetails(Id);
        viewModelaux.LoadActorImages(Id);
        viewModelaux.LoadCastDetails(Id);
    }

    //For Navi
    private void NavigationLabel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        string aux = NavigationLabel.Text;

        if (aux != null && aux != "")
        {
            string[] TypeAndId = aux.Split(":");

            if (TypeAndId[0] == "Movie")
            {
                IB_Movie_Clicked(TypeAndId[1]);
            }
            else
            {
                
            }
        }
    }

    private void IB_Movie_Clicked(string Id)
    {
        Navigation.PushAsync(new MovieDetailsPage(new MovieDetailsPageViewModel(new NavigationServices()), Id));
    }
}