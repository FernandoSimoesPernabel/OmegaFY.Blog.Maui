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
}