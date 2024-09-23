using Microsoft.Extensions.Logging;
using PrimerEjemplo.ConexionDatos;
using PrimerEjemplo.Pages;

namespace PrimerEjemplo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            //builder.Services.AddSingleton<IRestConexionDatos, RestConexionDatos>();
            builder.Services.AddHttpClient<IRestConexionDatos, RestConexionDatos>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<GestionPlatosPage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
