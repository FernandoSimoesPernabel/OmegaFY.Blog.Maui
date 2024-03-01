using OmegaFY.Blog.Maui.App.Application.Commands.User.Login;
using OmegaFY.Blog.Maui.App.Application.Commands.User.RefreshToken;
using OmegaFY.Blog.Maui.App.Infra.ExternalServices.Base;

namespace OmegaFY.Blog.Maui.App.Infra.ExternalServices;

public interface IOmegaFyBlogClient
{
    public Task<ApiResponse<LoginCommandResult>> LoginAsync(LoginCommand command, CancellationToken cancellationToken);

    public Task<ApiResponse<RefreshTokenCommandResult>> RefreshTokenAsync(RefreshTokenCommand command, CancellationToken cancellationToken);
}