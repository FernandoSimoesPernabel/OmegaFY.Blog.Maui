﻿using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Maui.App.Data.Extensions;
using OmegaFY.Blog.Maui.App.Infra.Extensions;
using OmegaFY.Blog.Maui.App.Services.Extensions;
using OmegaFY.Blog.Maui.App.ViewModels.Extensions;

namespace OmegaFY.Blog.Maui.App;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        MauiAppBuilder builder = MauiApp.CreateBuilder();

        builder.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Configuration.AddConfiguration();

        builder.Services.AddUserPreferencesStorage();

        builder.Services.AddSafeStorage();

        builder.Services.AddFileSystemStorage();

        builder.Services.AddExternalServices();

        builder.Services.AddViewsAndViewModels();

        builder.Services.AddRepositories();

        builder.Services.AddConnectivity();

        builder.Services.AddDialog();

        builder.Services.AddNavigation();

        builder.Services.AddServices();

        return builder.Build();
    }
}