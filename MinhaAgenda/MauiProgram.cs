using CasosDeUso.PluginsInterfaces;
using Microsoft.Extensions.Logging;
using MinhaAgenda.Plugins.SqlLite;

namespace MinhaAgenda
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            #region injeção de dependências
            builder.Services.AddSingleton<IRepositorioDeContatos, RepositorioContatosSqlLite>();
            //builder.Services.AddSingleton<IRepositorioDeContatos, Dados>();
            #endregion

            return builder.Build();
        }
    }
}
