using OmegaFY.Blog.Maui.App.Services.Implementations;

namespace OmegaFY.Blog.Maui.App.Services.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IUserService, UserService>();

        return services;
    }
}