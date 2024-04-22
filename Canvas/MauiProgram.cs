using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using CanvasRemake.Services;
using CommunityToolkit.Maui;

namespace CanvasRemake;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		// Register ApiService with HttpClient configured for the API base address
		builder.Services.AddHttpClient<ApiService>(client =>
		{
			client.BaseAddress = new Uri("https://localhost:7060/"); // Update to actual API URL
		});

		builder.Services.AddTransient<INavigationService, NavigationService>();

#if DEBUG
		builder.Logging.AddDebug();
#endif
		return builder.Build();
	}
}