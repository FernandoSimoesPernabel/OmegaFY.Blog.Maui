using OmegaFY.Blog.Maui.App.Infra.Storages.PreferencesStorage;
using OmegaFY.Blog.Maui.App.Infra.Storages.SafeStorage;
using OmegaFY.Blog.Maui.App.Infra.Enums;
using OmegaFY.Blog.Maui.App.Infra.Navigation;
using OmegaFY.Blog.Maui.App.Infra.ExternalServices;
using OmegaFY.Blog.Maui.App.Infra.ExternalServices.Base;
using OmegaFY.Blog.Maui.App.Models.APIs.Base;
using OmegaFY.Blog.Maui.App.Models.APIs.Results;
using OmegaFY.Blog.Maui.App.Models.Extensions;
using OmegaFY.Blog.Maui.App.Models.APIs.Requests;

namespace OmegaFY.Blog.Maui.App.Services.Implementations;

internal class LoggedUserService : ILoggedUserService
{
    private readonly IOmegaFyBlogClient _omegaFyBlogClient;

    private readonly IUserPreferencesProvider _userPreferencesProvider;

    private readonly ISafeStorageProvider _safeStorageProvider;

    private readonly INavigationProvider _navigationProvider;

    public LoggedUserService(
        IOmegaFyBlogClient omegaFyBlogClient,
        IUserPreferencesProvider userPreferencesProvider,
        ISafeStorageProvider safeStorageProvider,
        INavigationProvider navigationProvider)
    {
        _omegaFyBlogClient = omegaFyBlogClient;
        _userPreferencesProvider = userPreferencesProvider;
        _safeStorageProvider = safeStorageProvider;
        _navigationProvider = navigationProvider;
    }

    public async Task<GenericResult<ExcludeAccountResult>> ExcludeAccountAsync(CancellationToken cancellationToken)
    {
        Guid userId = _userPreferencesProvider.Get<Guid>(PreferencesKey.UserId);

        ApiResponse<ExcludeAccountResult> result = await _omegaFyBlogClient.ExcludeAccountAsync(userId, cancellationToken);

        if (result.Succeeded)
            ClearUserTokenOnStorage();

        return result.ToGenericResult();
    }

    public async Task<GenericResult<LoginResult>> LoginAsync(LoginRequest request, bool rememberMe, CancellationToken cancellationToken)
    {
        ApiResponse<LoginResult> result = await _omegaFyBlogClient.LoginAsync(request, CancellationToken.None);

        await SaveUserTokenIfSucceededAsync(result.Succeeded, result.Data?.Token, result.Data?.RefreshToken);

        if (rememberMe)
            await SaveUserPreferencesIfSucceededAsync(result, request.Password);

        return result.ToGenericResult();
    }

    public async Task LogoffLocallyAsync()
    {
        ClearUserTokenOnStorage();
        await _navigationProvider.GoToLoginAsync();
    }

    public async Task LogoffFromServerAsync(CancellationToken cancellationToken)
    {
        Guid? refreshToken = await TryGetUserRefreshTokenAsync();

        ClearUserTokenOnStorage();

        if (refreshToken.HasValue)
            await _omegaFyBlogClient.LogoffAsync(refreshToken.Value, cancellationToken);
    }

    public async Task<GenericResult<RefreshTokenResult>> RefreshTokenAsync(RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        ApiResponse<RefreshTokenResult> result = await _omegaFyBlogClient.RefreshTokenAsync(request, cancellationToken);

        await SaveUserTokenIfSucceededAsync(result.Succeeded, result.Data?.Token, result.Data?.RefreshToken);

        return result.ToGenericResult();
    }

    public async Task<GenericResult<RegisterNewUserResult>> RegisterNewUserAsync(RegisterNewUserRequest request, CancellationToken cancellationToken)
    {
        GenericResult<RegisterNewUserResult> result = null;

        await SaveUserTokenIfSucceededAsync(result.Succeeded, result.Data?.Token, result.Data?.RefreshToken);

        return result;
    }

    public string TryGetUserBearerToken() => _userPreferencesProvider.Get<string>(PreferencesKey.BearerToken);

    public string TryGetUserEmail() => _userPreferencesProvider.Get<string>(PreferencesKey.Email);

    public Guid? TryGetUserId()
    {
        Guid userId = _userPreferencesProvider.Get<Guid>(PreferencesKey.UserId);
        return userId == Guid.Empty ? null : userId;
    }

    public async Task<string> TryGetUserPasswordAsync() => await _safeStorageProvider.GetAsync(SafeStorageKey.Password);

    public async Task<Guid?> TryGetUserRefreshTokenAsync()
    {
        string refreshToken = await _safeStorageProvider.GetAsync(SafeStorageKey.RefreshToken);
        return refreshToken is not null ? new Guid(refreshToken) : null;
    }

    private async Task SaveUserTokenIfSucceededAsync(bool succeeded, string bearerToken, Guid? refreshToken)
    {
        if (succeeded)
            await SaveUserTokenOnStorageAsync(bearerToken, refreshToken.Value);
        else
            ClearUserTokenOnStorage();
    }

    private async Task SaveUserPreferencesIfSucceededAsync(ApiResponse<LoginResult> result, string password)
    {
        if (result.Failed) return;

        _userPreferencesProvider.Set(PreferencesKey.UserId, result.Data.UserId);
        _userPreferencesProvider.Set(PreferencesKey.DisplayName, result.Data.DisplayName);
        _userPreferencesProvider.Set(PreferencesKey.Email, result.Data.Email);

        await _safeStorageProvider.SetAsync(SafeStorageKey.Password, password);
    }

    private async Task SaveUserTokenOnStorageAsync(string bearerToken, Guid refreshToken)
    {
        _userPreferencesProvider.Set(PreferencesKey.BearerToken, bearerToken);
        await _safeStorageProvider.SetAsync(SafeStorageKey.RefreshToken, refreshToken.ToString());
    }

    private void ClearUserTokenOnStorage()
    {
        _userPreferencesProvider.Remove(PreferencesKey.BearerToken);
        _safeStorageProvider.Remove(SafeStorageKey.RefreshToken);
    }
}