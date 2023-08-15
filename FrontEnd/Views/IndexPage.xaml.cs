using FrontEnd.Services;
using FrontEnd.ViewModel;

namespace FrontEnd.Views;

public partial class IndexPage : TabbedPage
{
    public IndexPageViewModel viewModelaux;


    public IndexPage(IndexPageViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
        viewModelaux = viewModel;



        //load the years to the year picker located in the search page
        for (int i = DateTime.Now.Year; i > 1900; i--)
        {
            FilterDatePicker.Items.Add(i.ToString());
        }

    }




    private void TabbedPage_CurrentPageChanged(object sender, EventArgs e)
    {
        switch (this.CurrentPage.Title)
        {
            case "Favorites":


                viewModelaux.LoadFavorites();

                break;
            case "Discover":
                viewModelaux.LoadDiscoverMovies();
                break;
            case "Search":



                break;
        }

        
    }

    private void Picker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (FilterCategoryPicker.SelectedIndex == 1)
        {
            SearchCollectionMovie.IsVisible = true;
            SearchCollectionPerson.IsVisible = false;

            FilterDatePicker.IsVisible = true;
        }
        else if (FilterCategoryPicker.SelectedIndex == 0)
        {
            SearchCollectionMovie.IsVisible = false;
            SearchCollectionPerson.IsVisible = true;

            FilterDatePicker.IsVisible = false;
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        //Get parameters
        string Query = SearchBar.Text;
        string MovieOrActor = "";
        string YearOfRelease = "";
        if (FilterCategoryPicker.SelectedIndex == 0)
        {
            MovieOrActor = "Actor";
        }
        if (FilterCategoryPicker.SelectedIndex == 1)
        {
            MovieOrActor = "Movie";
        }
        if (FilterDatePicker.SelectedItem != null)
        {
            YearOfRelease = FilterDatePicker.SelectedItem.ToString();
        }


        //Make Dictionary
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters.Add("Query", Query);
        parameters.Add("MovieOrActor", MovieOrActor);
        parameters.Add("YearOfRelease", YearOfRelease);

        //Call Command in viewmodel
        viewModelaux.Search(parameters);

        //Hide interface
        if (MovieOrActor == "Movie")
        {
            SearchCollectionMovie.IsVisible = true;
            SearchCollectionPerson.IsVisible = false;
        }

        if (MovieOrActor == "Actor")
        {
            SearchCollectionMovie.IsVisible = false;
            SearchCollectionPerson.IsVisible = true;
        }

        if (MovieOrActor == "")
        {
            SearchCollectionMovie.IsVisible = true;
            SearchCollectionPerson.IsVisible = false;
        }

    }


    //Event Handlers in ImageButtons used for navigation
    private void IB_Movie_Clicked(string Id)
    {
        Navigation.PushAsync(new MovieDetailsPage(new MovieDetailsPageViewModel(new NavigationServices()), Id));
    }
    private void IB_Actor_Clicked(string Id)
    {
        Navigation.PushAsync(new ActorDetailsPage(new ActorDetailsPageViewModel(new NavigationServices()), Id));
    }
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
                IB_Actor_Clicked(TypeAndId[1]);
            }
        }
        

    }
}