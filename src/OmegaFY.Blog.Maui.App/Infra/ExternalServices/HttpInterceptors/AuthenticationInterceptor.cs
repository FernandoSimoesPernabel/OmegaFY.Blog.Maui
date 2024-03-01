using OmegaFY.Blog.Maui.App.Application.Base;
using OmegaFY.Blog.Maui.App.Application.Commands.Users.RefreshToken;
using OmegaFY.Blog.Maui.App.Infra.Dialogs;
using OmegaFY.Blog.Maui.App.Infra.ExternalServices.Constants;
using OmegaFY.Blog.Maui.App.Infra.Models;
using OmegaFY.Blog.Maui.App.Services;
using System.Net;
using System.Net.Http.Headers;

namespace OmegaFY.Blog.Maui.App.Infra.ExternalServices.HttpInterceptors;

internal class AuthenticationInterceptor : DelegatingHandler
{
    private readonly ILoggedUserService _loggedUserService;

    private readonly IDialogProvider _dialogProvider;

    public AuthenticationInterceptor(ILoggedUserService loggedUserService, IDialogProvider dialogProvider)
    {
        _loggedUserService = loggedUserService;
        _dialogProvider = dialogProvider;
    }

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
        {
            await _loggedUserService.LogoffLocallyAsync();

            await _dialogProvider.DisplayAlertAsync(new DisplayAlertOptions("Unauthorized Access", "Unable to authenticate your session!"));
            
            return originalHttpResponse;
        }

        request.Headers.Authorization = new AuthenticationHeaderValue(HttpHeaderContants.BEARER_AUTHENTICATION, refreshTokenResult.Data.Token);

        return await base.SendAsync(request, cancellationToken);
    }
}