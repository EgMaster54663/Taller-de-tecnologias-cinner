using FrontEnd.Services;
using FrontEnd.ViewModel;
using FrontEnd.Views;

namespace FrontEnd;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        //sirve para determinar la pagina principal de la aplicacion pero en el video del indu no era asi
        //El problema de aca esta solucionado, shellcontent no soporta tabbedpages, la navegacion por shell no deberia tener problemas igualmente
        MainPage = new NavigationPage(new IndexPage(new IndexPageViewModel(new NavigationServices())));
        //MainPage = new NavigationPage(new AppLaunchPage());

    }
}
