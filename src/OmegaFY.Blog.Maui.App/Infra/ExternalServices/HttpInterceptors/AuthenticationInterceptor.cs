using OmegaFY.Blog.Maui.App.Infra.Enums;
using OmegaFY.Blog.Maui.App.Infra.Storage.PreferencesStorage;
using OmegaFY.Blog.Maui.App.Infra.Storage.SafeStorage;
using System.Net;
using System.Net.Http.Headers;

namespace OmegaFY.Blog.Maui.App.Infra.ExternalServices.HttpInterceptors;

internal class AuthenticationInterceptor : DelegatingHandler
{
    private readonly IUserPreferencesProvider _userPreferencesProvider;

    private readonly ISafeStorageProvider _safeStorageProvider;

    public AuthenticationInterceptor(IUserPreferencesProvider userPreferencesProvider, ISafeStorageProvider safeStorageProvider)
    {
        _userPreferencesProvider = userPreferencesProvider;
        _safeStorageProvider = safeStorageProvider;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        string bearerToken = _userPreferencesProvider.GetPreference<string>(PreferencesKey.BearerToken);

        if (bearerToken is null)
            return await base.SendAsync(request, cancellationToken);

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

        HttpResponseMessage originalHttpResponse = await base.SendAsync(request, cancellationToken);

        if (originalHttpResponse.StatusCode != HttpStatusCode.Unauthorized)
            return originalHttpResponse;

        string refreshToken = await _safeStorageProvider.GetAsync(SafeStorageKey.RefreshToken);

        if (refreshToken is null)
            return originalHttpResponse;

        //RefreshToken call
        HttpResponseMessage refreshTokenResponse = null;

        if (!refreshTokenResponse.IsSuccessStatusCode)
        {
            _userPreferencesProvider.RemovePreference(PreferencesKey.BearerToken);
            _safeStorageProvider.Remove(SafeStorageKey.RefreshToken);

            return originalHttpResponse;
        }

        bearerToken = ""; //Pega bearerToken do result
        refreshToken = ""; //Pega refresh do result

        _userPreferencesProvider.SetPreference(PreferencesKey.BearerToken, bearerToken);
        await _safeStorageProvider.SetAsync(SafeStorageKey.RefreshToken, refreshToken);

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

        return await base.SendAsync(request, cancellationToken);
    }
}