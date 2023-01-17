using SQLiteDemo.Services;
using SQLiteDemo.ViewModels;
using SQLiteDemo.Views;

namespace SQLiteDemo;

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

        // Services
        builder.Services.AddSingleton<InterfaceBDD, ODBorgarDB>();


        //Views Registration
        builder.Services.AddSingleton<BorgarListPage>();
        builder.Services.AddTransient<AddUpdateBorgarDetail>();


        //View Modles 
        builder.Services.AddSingleton<BorgarListODModel>();
        builder.Services.AddTransient<AddUpdateBorgarODModel>();


        return builder.Build();
    }
}
