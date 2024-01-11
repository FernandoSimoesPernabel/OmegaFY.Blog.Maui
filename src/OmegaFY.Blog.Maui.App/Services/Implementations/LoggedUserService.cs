using OmegaFY.Blog.Maui.App.Infra.ExternalServices;
using OmegaFY.Blog.Maui.App.Infra.ExternalServices.Base;
using OmegaFY.Blog.Maui.App.Application.Commands.ExcludeAccount;
using OmegaFY.Blog.Maui.App.Application.Commands.Login;
using OmegaFY.Blog.Maui.App.Application.Commands.RefreshToken;
using OmegaFY.Blog.Maui.App.Application.Commands.Logoff;
using OmegaFY.Blog.Maui.App.Application.Commands.RegisterNewUser;
using OmegaFY.Blog.Maui.App.Application.Base;
using OmegaFY.Blog.Maui.App.Application.Extensions;
using OmegaFY.Blog.Maui.App.Infra.Storages.PreferencesStorage;
using OmegaFY.Blog.Maui.App.Infra.Storages.SafeStorage;
using OmegaFY.Blog.Maui.App.Infra.Enums;
using OmegaFY.Blog.Maui.App.Common.Serializers;

namespace OmegaFY.Blog.Maui.App.Services.Implementations;

internal class LoggedUserService : ILoggedUserService
{
    private readonly IOmegaFyBlogClient _omegaFyBlogClient;

    private readonly IUserPreferencesProvider _userPreferencesProvider;

    private readonly ISafeStorageProvider _safeStorageProvider;

    public LoggedUserService(IOmegaFyBlogClient omegaFyBlogClient, IUserPreferencesProvider userPreferencesProvider, ISafeStorageProvider safeStorageProvider)
    {
        _omegaFyBlogClient = omegaFyBlogClient;
        _userPreferencesProvider = userPreferencesProvider;
        _safeStorageProvider = safeStorageProvider;
    }

    public Task<GenericResult<ExcludeAccountCommandResult>> ExcludeAccountAsync(ExcludeAccountCommand command)
    {
        throw new NotImplementedException();
    }

    public async Task<GenericResult<LoginCommandResult>> LoginAsync(LoginCommand command)
    {
        ApiResponse<LoginCommandResult> result = await _omegaFyBlogClient.LoginAsync(command, CancellationToken.None);

        SaveUserPreferencesIfSucceededAsync(result);

        await SaveUserTokenIfSucceededAsync(result.Succeeded, result.Data.Token, result.Data.RefreshToken);

        return result.ToGenericResult();
    }

    public Task<GenericResult<LogoffCommandResult>> LogoffAsync(LogoffCommand command)
    {
        ClearUserTokenOnStorage();
        throw new NotImplementedException();
    }

    public async Task<GenericResult<RefreshTokenCommandResult>> RefreshTokenAsync(RefreshTokenCommand command)
    {
        ApiResponse<RefreshTokenCommandResult> result = await _omegaFyBlogClient.RefreshTokenAsync(command, CancellationToken.None);

        await SaveUserTokenIfSucceededAsync(result.Succeeded, result.Data.Token, result.Data.RefreshToken);

        return result.ToGenericResult();
    }

    public Task<GenericResult<RegisterNewUserCommandResult>> RegisterNewUserAsync(RegisterNewUserCommand command)
    {
        throw new NotImplementedException();
    }

    public async Task<string> TryGetUserBearerTokenAsync() => await _safeStorageProvider.GetAsync<string>(SafeStorageKey.BearerToken);

    public async Task<Guid?> TryGetUserRefreshTokenAsync()
    {
        string refreshToken = await _safeStorageProvider.GetAsync(SafeStorageKey.RefreshToken);
        return refreshToken is not null ? JsonStaticSerializer.Deserialize<Guid>(refreshToken) : null;
    }

    private async Task SaveUserTokenIfSucceededAsync(bool succeeded, string bearerToken, Guid refreshToken)
    {
        if (succeeded)
            await SaveUserTokenOnStorageAsync(bearerToken, refreshToken);
        else
            ClearUserTokenOnStorage();
    }

    private void SaveUserPreferencesIfSucceededAsync(ApiResponse<LoginCommandResult> result)
    {
        if (result.Failed) return;

        _userPreferencesProvider.Set(PreferencesKey.UserId, result.Data.UserId);
        _userPreferencesProvider.Set(PreferencesKey.DisplayName, result.Data.DisplayName);
        _userPreferencesProvider.Set(PreferencesKey.Email, result.Data.Email);
    }

    private async Task SaveUserTokenOnStorageAsync(string bearerToken, Guid refreshToken)
    {
        await _safeStorageProvider.SetAsync(SafeStorageKey.BearerToken, bearerToken);
        await _safeStorageProvider.SetAsync(SafeStorageKey.RefreshToken, refreshToken);
    }

    private void ClearUserTokenOnStorage()
    {
        _safeStorageProvider.Remove(SafeStorageKey.BearerToken);
        _safeStorageProvider.Remove(SafeStorageKey.RefreshToken);
    }
}