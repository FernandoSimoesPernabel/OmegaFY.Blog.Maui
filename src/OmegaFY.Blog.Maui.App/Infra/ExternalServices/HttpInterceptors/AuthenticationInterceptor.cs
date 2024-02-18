using OmegaFY.Blog.Maui.App.Application.Base;
using OmegaFY.Blog.Maui.App.Application.Commands.RefreshToken;
using OmegaFY.Blog.Maui.App.Infra.ExternalServices.Constants;
using OmegaFY.Blog.Maui.App.Services;
using System.Net;
using System.Net.Http.Headers;

namespace OmegaFY.Blog.Maui.App.Infra.ExternalServices.HttpInterceptors;

internal class AuthenticationInterceptor : DelegatingHandler
{
    private readonly ILoggedUserService _loggedUserService;

    public AuthenticationInterceptor(ILoggedUserService loggedUserService) => _loggedUserService = loggedUserService;

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        string bearerToken = _loggedUserService.TryGetUserBearerToken();

        if (bearerToken is null)
            return await base.SendAsync(request, cancellationToken);

        request.Headers.Authorization = new AuthenticationHeaderValue(HttpHeaderContants.BEARER_AUTHENTICATION, bearerToken);

        HttpResponseMessage originalHttpResponse = await base.SendAsync(request, cancellationToken);

        if (originalHttpResponse.StatusCode != HttpStatusCode.Unauthorized)
            return originalHttpResponse;

        Guid? refreshToken = await _loggedUserService.TryGetUserRefreshTokenAsync();

        if (!refreshToken.HasValue)
            return originalHttpResponse;

        GenericResult<RefreshTokenCommandResult> refreshTokenResult =
            await _loggedUserService.RefreshTokenAsync(new RefreshTokenCommand(bearerToken, refreshToken.Value));

        if (!refreshTokenResult.Succeeded)
            return originalHttpResponse;

        request.Headers.Authorization = new AuthenticationHeaderValue(HttpHeaderContants.BEARER_AUTHENTICATION, refreshTokenResult.Data.Token);

        return await base.SendAsync(request, cancellationToken);
    }
}