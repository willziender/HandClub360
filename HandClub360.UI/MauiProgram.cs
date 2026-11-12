using Microsoft.Extensions.Logging;
using HandClub360.data.Context;
using Microsoft.EntityFrameworkCore;

namespace HandClub360.UI
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

            var app = builder.Build();

            using var db = ClubDbContextFactory.Create();

            db.Database.EnsureCreated();

            return app;
        }
    }
}
