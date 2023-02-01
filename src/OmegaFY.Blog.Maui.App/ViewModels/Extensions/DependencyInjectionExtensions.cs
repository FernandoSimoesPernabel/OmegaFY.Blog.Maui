namespace OmegaFY.Blog.Maui.App.ViewModels.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddViewsAndViewModels(this IServiceCollection services)
    {
        services.AddSingleton<MainPage>();
        services.AddSingleton<MainPageViewModel>();

        return services;
    }
}