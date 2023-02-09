using OmegaFY.Blog.Maui.App.Infra.Dialog;
using OmegaFY.Blog.Maui.App.Infra.Dialog.Implementations;
using OmegaFY.Blog.Maui.App.Infra.ExternalServices;
using OmegaFY.Blog.Maui.App.Infra.ExternalServices.HttpInterceptors;
using OmegaFY.Blog.Maui.App.Infra.ExternalServices.Implementations;
using OmegaFY.Blog.Maui.App.Infra.Storage.PreferencesStorage;
using OmegaFY.Blog.Maui.App.Infra.Storage.PreferencesStorage.Implementations;
using OmegaFY.Blog.Maui.App.Infra.Storage.SafeStorage;
using OmegaFY.Blog.Maui.App.Infra.Storage.SafeStorage.Implementations;

namespace OmegaFY.Blog.Maui.App.Infra.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddUserPreferencesStorage(this IServiceCollection services)
    {
        services.AddSingleton(Preferences.Default);
        services.AddSingleton<IUserPreferencesProvider, DefaultPreferenceStorage>();

        return services;
    }

    public static IServiceCollection AddSafeStorage(this IServiceCollection services)
    {
        services.AddSingleton(SecureStorage.Default);
        services.AddSingleton<ISafeStorageProvider, DefaultSecureStorage>();

        return services;
    }

    public static IServiceCollection AddExternalServices(this IServiceCollection services)
    {
        services.AddHttpClient(nameof(OmegaFyBlogClient), client =>
        {
            client.BaseAddress = new Uri("https://localhost:7141/api/");
        }).AddHttpMessageHandler<AuthenticationInterceptor>();

        services.AddTransient<AuthenticationInterceptor>();

        services.AddSingleton<IOmegaFyBlogClient, OmegaFyBlogClient>();

        return services;
    }

    public static IServiceCollection AddConnectivity(this IServiceCollection services)
    {
        services.AddSingleton(Connectivity.Current);

        return services;
    }

    public static IServiceCollection AddDialog(this IServiceCollection services)
    {
        services.AddSingleton<IDialogProvider, MainPageDialog>();

        return services;
    }
}