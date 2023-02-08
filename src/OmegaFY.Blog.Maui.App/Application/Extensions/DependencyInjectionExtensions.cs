using MediatR;
using OmegaFY.Blog.Maui.App.Application.PipelineBehaviors;

namespace OmegaFY.Blog.Maui.App.Application.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddServiceBusMediatR(this IServiceCollection services)
    {
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequiresAnyConnectionBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequiresStrongConnectionBehavior<,>));

        services.AddMediatR(typeof(DependencyInjectionExtensions).Assembly);

        return services;
    }
}