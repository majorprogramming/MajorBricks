using MajorBricks.Data;
using MajorBricks.Services;
using MajorBricks.UI.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MajorBricks.UI;

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

        // 1) DbContext mit SQLite-Datei registrieren
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "majorbricks.db");
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite($"Filename={dbPath}"));

        // 2) Repository und ViewModel registrieren
        builder.Services.AddScoped<ISetRepository, SqliteSetRepository>();
        builder.Services.AddSingleton<MainPageViewModel>();

        // 3) Die MainPage selbst über DI auflösen lassen
        builder.Services.AddSingleton<MainPage>();

        var app = builder.Build();

        // EF Datenbank migration:
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            // wendet alle Migrationen an und legt die Tabellen an
            db.Database.Migrate();
        }

        return app;
    }
}
