using OmegaFY.Blog.Maui.App.Application.Repositories;

namespace OmegaFY.Blog.Maui.App.Application.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        //services.AddSingleton<IUserRepository, UserRepository>();

        return services;
    }
}