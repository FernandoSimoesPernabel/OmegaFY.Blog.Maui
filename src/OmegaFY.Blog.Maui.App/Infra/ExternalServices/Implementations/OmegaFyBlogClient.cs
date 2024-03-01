using OmegaFY.Blog.Maui.App.Application.Commands.User.Login;
using OmegaFY.Blog.Maui.App.Application.Commands.User.RefreshToken;
using OmegaFY.Blog.Maui.App.Infra.ExternalServices.Base;
using OmegaFY.Blog.Maui.App.Infra.ExternalServices.Constants;

namespace OmegaFY.Blog.Maui.App.Infra.ExternalServices.Implementations;

internal class OmegaFyBlogClient : AbstractHttpClient, IOmegaFyBlogClient
{
    protected override string HttpClientName => nameof(OmegaFyBlogClient);

    public OmegaFyBlogClient(IHttpClientFactory httpClientFactory) : base(httpClientFactory) { }

    public async Task<ApiResponse<LoginCommandResult>> LoginAsync(LoginCommand command, CancellationToken cancellationToken)
        => await PostAsync<LoginCommand, ApiResponse<LoginCommandResult>>(OmegaFyBlogRoutesConstants.LOGIN, command, cancellationToken);

    public async Task<ApiResponse<RefreshTokenCommandResult>> RefreshTokenAsync(RefreshTokenCommand command, CancellationToken cancellationToken)
        => await PostAsync<RefreshTokenCommand, ApiResponse<RefreshTokenCommandResult>>(OmegaFyBlogRoutesConstants.REFRESH_TOKEN, command, cancellationToken);
}