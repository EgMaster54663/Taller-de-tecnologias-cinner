using FrontEnd.Services;
using FrontEnd.ViewModel;

namespace FrontEnd.Views;

public partial class AppLaunchPage : ContentPage
{
	public AppLaunchPage(AppLaunchPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;




    }

    private void Button_Clicked(object sender, EventArgs e)
    {

		


		//Shell.Current.GoToAsync(nameof(IndexPage));
		//Navigation.PushAsync(new IndexPage());
    }
}