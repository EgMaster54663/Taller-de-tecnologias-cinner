using FrontEnd.Views;

namespace FrontEnd;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		//aca es donde se registran las rutas para el navigation service
		//se puede navegar sin registrar las rutas pero segun el profe no se pueden pasar parametros
		//las rutas no se registran de uno a otro sino que se registran las paginas hacia las cuales se puede ir
		Routing.RegisterRoute(nameof(IndexPage), typeof(IndexPage));
		Routing.RegisterRoute(nameof(AppLaunchPage), typeof(AppLaunchPage));
		Routing.RegisterRoute(nameof(ActorDetailsPage), typeof(ActorDetailsPage));
        Routing.RegisterRoute(nameof(MovieDetailsPage), typeof(MovieDetailsPage));
    }
}
