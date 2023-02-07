using OmegaFY.Blog.Maui.App.Infra.ExternalServices.Base;
using OmegaFY.Blog.Maui.App.Infra.ExternalServices.DTOs;

namespace OmegaFY.Blog.Maui.App.Infra.ExternalServices;

public interface IOmegaFyBlogClient
{
    public Task<ApiResponse<LoginCommandResult>> LoginAsync(LoginCommand command, CancellationToken cancellationToken);
}