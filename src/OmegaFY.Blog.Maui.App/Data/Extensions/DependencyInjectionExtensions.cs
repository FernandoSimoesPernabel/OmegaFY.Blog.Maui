namespace OmegaFY.Blog.Maui.App.Data.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        //services.AddSingleton<IUserRepository, UserRepository>();

        return services;
    }
}