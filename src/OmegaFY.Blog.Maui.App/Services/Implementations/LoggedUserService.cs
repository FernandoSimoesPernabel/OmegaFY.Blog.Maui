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
using Microsoft.Maui.Controls;

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

        await SaveUserTokenIfSucceededAsync(result.Succeeded, result.Data?.Token, result.Data?.RefreshToken);

        if (command.RememberMe)
            await SaveUserPreferencesIfSucceededAsync(result, command.Password);

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

        await SaveUserTokenIfSucceededAsync(result.Succeeded, result.Data?.Token, result.Data?.RefreshToken);

        return result.ToGenericResult();
    }

    public Task<GenericResult<RegisterNewUserCommandResult>> RegisterNewUserAsync(RegisterNewUserCommand command)
    {
        throw new NotImplementedException();
    }

    public string TryGetUserBearerToken() => _userPreferencesProvider.Get<string>(PreferencesKey.BearerToken);

    public string TryGetUserEmail() => _userPreferencesProvider.Get<string>(PreferencesKey.Email);

    public async Task<string> TryGetUserPasswordAsync() => await _safeStorageProvider.GetAsync(SafeStorageKey.Password);

    public async Task<Guid?> TryGetUserRefreshTokenAsync()
    {
        string refreshToken = await _safeStorageProvider.GetAsync(SafeStorageKey.RefreshToken);
        return refreshToken is not null ? JsonStaticSerializer.Deserialize<Guid>(refreshToken) : null;
    }

    private async Task SaveUserTokenIfSucceededAsync(bool succeeded, string bearerToken, Guid? refreshToken)
    {
        if (succeeded)
            await SaveUserTokenOnStorageAsync(bearerToken, refreshToken.Value);
        else
            ClearUserTokenOnStorage();
    }

    private async Task SaveUserPreferencesIfSucceededAsync(ApiResponse<LoginCommandResult> result, string password)
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
        await _safeStorageProvider.SetAsync(SafeStorageKey.RefreshToken, refreshToken);
    }

    private void ClearUserTokenOnStorage()
    {
        _userPreferencesProvider.Remove(PreferencesKey.BearerToken);
        _safeStorageProvider.Remove(SafeStorageKey.RefreshToken);
    }
}