using MediatR;
using OmegaFY.Blog.Maui.App.Application.PipelineBehaviors;

namespace OmegaFY.Blog.Maui.App.Application.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddServiceBusMediatR(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssembly(typeof(DependencyInjectionExtensions).Assembly);

            options.AddBehavior(typeof(IPipelineBehavior<,>), typeof(RequiresAnyConnectionBehavior<,>));
            options.AddBehavior(typeof(IPipelineBehavior<,>), typeof(RequiresStrongConnectionBehavior<,>));
        });

        return services;
    }
}