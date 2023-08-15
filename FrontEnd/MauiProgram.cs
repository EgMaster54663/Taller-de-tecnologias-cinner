using CommunityToolkit.Maui;
using FrontEnd.Services;
using FrontEnd.ViewModel;
using FrontEnd.Views;
using Microsoft.Extensions.Logging;

namespace FrontEnd;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiCommunityToolkitMediaElement()
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<INavigationServices, NavigationServices>();
		builder.Services.AddSingleton<Api>();
		builder.Services.AddSingleton<FavoritesService>();

		//UI Registration
		//Aca se registran las UI
		builder.Services.AddSingleton<AppLaunchPage>();
        builder.Services.AddTransient<IndexPage>();
		builder.Services.AddTransient<ActorDetailsPage>();
		builder.Services.AddTransient<MovieDetailsPage>();

        

        //Viewmodel registration
		//Aca se registran los viewmodels de las UI pero no hace el binding
		//Eso se hace en la pagina misma
        builder.Services.AddSingleton<AppLaunchPageViewModel>();
        builder.Services.AddTransient<IndexPageViewModel>();
		builder.Services.AddTransient<ActorDetailsPageViewModel>();
        builder.Services.AddTransient<MovieDetailsPageViewModel>();



        return builder.Build();
	}
}
