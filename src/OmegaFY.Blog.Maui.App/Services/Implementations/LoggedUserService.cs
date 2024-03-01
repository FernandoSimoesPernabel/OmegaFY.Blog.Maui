using OmegaFY.Blog.Maui.App.Application.Base;
using OmegaFY.Blog.Maui.App.Infra.Storages.PreferencesStorage;
using OmegaFY.Blog.Maui.App.Infra.Storages.SafeStorage;
using OmegaFY.Blog.Maui.App.Infra.Enums;
using OmegaFY.Blog.Maui.App.Infra.Navigation;
using OmegaFY.Blog.Maui.App.Application.Commands.Users.ExcludeAccount;
using OmegaFY.Blog.Maui.App.Application.Commands.Users.Login;
using OmegaFY.Blog.Maui.App.Application.Commands.Users.Logoff;
using OmegaFY.Blog.Maui.App.Application.Commands.Users.RefreshToken;
using OmegaFY.Blog.Maui.App.Application.Commands.Users.RegisterNewUser;
using MediatR;

namespace OmegaFY.Blog.Maui.App.Services.Implementations;

internal class LoggedUserService : ILoggedUserService
{
    private readonly IMediator _mediator;

    private readonly IUserPreferencesProvider _userPreferencesProvider;

    private readonly ISafeStorageProvider _safeStorageProvider;

    private readonly INavigationProvider _navigationProvider;

    public LoggedUserService(
        IMediator mediator, 
        IUserPreferencesProvider userPreferencesProvider, 
        ISafeStorageProvider safeStorageProvider, 
        INavigationProvider navigationProvider)
    {
        _mediator = mediator;
        _userPreferencesProvider = userPreferencesProvider;
        _safeStorageProvider = safeStorageProvider;
        _navigationProvider = navigationProvider;
    }

    public async Task<GenericResult<ExcludeAccountCommandResult>> ExcludeAccountAsync(ExcludeAccountCommand command)
    {
        GenericResult<ExcludeAccountCommandResult> result = await _mediator.Send(command);

        if (result.Succeeded)
            ClearUserTokenOnStorage();

        return result;
    }

    public async Task<GenericResult<LoginCommandResult>> LoginAsync(LoginCommand command)
    {
        GenericResult<LoginCommandResult> result = await _mediator.Send(command);

        await SaveUserTokenIfSucceededAsync(result.Succeeded, result.Data?.Token, result.Data?.RefreshToken);

        if (command.RememberMe)
            await SaveUserPreferencesIfSucceededAsync(result, command.Password);

        return result;
    }

    public async Task LogoffLocallyAsync()
    {
        ClearUserTokenOnStorage();
        await _navigationProvider.GoToLoginAsync();
    }

    public async Task<GenericResult<LogoffCommandResult>> LogoffFromServerAsync(LogoffCommand command)
    {
        ClearUserTokenOnStorage();
        return await _mediator.Send(command);
    }

    public async Task<GenericResult<RefreshTokenCommandResult>> RefreshTokenAsync(RefreshTokenCommand command)
    {
        GenericResult<RefreshTokenCommandResult> result = await _mediator.Send(command);

        await SaveUserTokenIfSucceededAsync(result.Succeeded, result.Data?.Token, result.Data?.RefreshToken);

        return result;
    }

    public async Task<GenericResult<RegisterNewUserCommandResult>> RegisterNewUserAsync(RegisterNewUserCommand command)
    {
        GenericResult<RegisterNewUserCommandResult> result = await _mediator.Send(command);

        await SaveUserTokenIfSucceededAsync(result.Succeeded, result.Data?.Token, result.Data?.RefreshToken);

        return result;
    }

    public string TryGetUserBearerToken() => _userPreferencesProvider.Get<string>(PreferencesKey.BearerToken);

    public string TryGetUserEmail() => _userPreferencesProvider.Get<string>(PreferencesKey.Email);

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

    private async Task SaveUserPreferencesIfSucceededAsync(GenericResult<LoginCommandResult> result, string password)
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