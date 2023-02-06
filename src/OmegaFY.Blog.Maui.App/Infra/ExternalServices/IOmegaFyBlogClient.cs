using OmegaFY.Blog.Maui.App.Application.Base;
using OmegaFY.Blog.Maui.App.Application.Commands.Login;

namespace OmegaFY.Blog.Maui.App.Infra.ExternalServices;

public interface IOmegaFyBlogClient
{
    public Task<ApiResponse<LoginCommandResult>> LoginAsync(LoginCommand command, CancellationToken cancellationToken);
}