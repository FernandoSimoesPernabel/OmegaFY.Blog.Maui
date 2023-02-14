using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using OmegaFY.Blog.Maui.App.Infra.Dialogs;
using OmegaFY.Blog.Maui.App.Infra.Dialogs.Implementations;
using OmegaFY.Blog.Maui.App.Infra.ExternalServices;
using OmegaFY.Blog.Maui.App.Infra.ExternalServices.HttpInterceptors;
using OmegaFY.Blog.Maui.App.Infra.ExternalServices.Implementations;
using OmegaFY.Blog.Maui.App.Infra.Storages.FileSystemStorage;
using OmegaFY.Blog.Maui.App.Infra.Storages.FileSystemStorage.Implementations;
using OmegaFY.Blog.Maui.App.Infra.Storages.PreferencesStorage;
using OmegaFY.Blog.Maui.App.Infra.Storages.PreferencesStorage.Implementations;
using OmegaFY.Blog.Maui.App.Infra.Storages.SafeStorage;
using OmegaFY.Blog.Maui.App.Infra.Storages.SafeStorage.Implementations;
using System.Reflection;

namespace OmegaFY.Blog.Maui.App.Infra.Extensions;

public static class DependencyInjectionExtensions
{
    public static IConfiguration AddConfiguration(this ConfigurationManager configuration)
    {
        Assembly assembly = typeof(App).GetTypeInfo().Assembly;

        IConfigurationRoot configurationRoot = new ConfigurationBuilder()
            .AddJsonFile(new EmbeddedFileProvider(assembly), "appsettings.json", optional: false, false)
            .Build();

        configuration.AddConfiguration(configurationRoot);

        return configuration;
    }

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

    public static IServiceCollection AddFileSystemStorage(this IServiceCollection services)
    {
        services.AddSingleton(FileSystem.Current);
        services.AddSingleton<IFileSystemStorageProvider, DefautlFileSystemStorage>();

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