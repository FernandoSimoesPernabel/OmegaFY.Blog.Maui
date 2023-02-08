using OmegaFY.Blog.Maui.App.Application.Commands.Login;
using OmegaFY.Blog.Maui.App.Infra.ExternalServices.Base;
using OmegaFY.Blog.Maui.App.Infra.ExternalServices.Constants;

namespace OmegaFY.Blog.Maui.App.Infra.ExternalServices.Implementations;

internal class OmegaFyBlogClient : AbstractHttpClient, IOmegaFyBlogClient
{
    public OmegaFyBlogClient() : base()
    {
    }

    public async Task<ApiResponse<LoginCommandResult>> LoginAsync(LoginCommand command, CancellationToken cancellationToken)
    {
        return await PostAsync<LoginCommand, ApiResponse<LoginCommandResult>>(OmegaFyBlogRoutesConstants.LOGIN, command, cancellationToken);
    }
}