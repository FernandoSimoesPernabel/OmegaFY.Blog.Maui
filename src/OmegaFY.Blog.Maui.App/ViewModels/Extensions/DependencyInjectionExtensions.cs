using OmegaFY.Blog.Maui.App.Views;

namespace OmegaFY.Blog.Maui.App.ViewModels.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddViewsAndViewModels(this IServiceCollection services)
    {
        services.AddSingleton<LoginPage>();
        services.AddSingleton<LoginPageViewModel>();

        return services;
    }
}