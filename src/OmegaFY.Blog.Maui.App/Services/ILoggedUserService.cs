﻿using OmegaFY.Blog.Maui.App.Application.Commands.ExcludeAccount;
using OmegaFY.Blog.Maui.App.Application.Commands.Login;
using OmegaFY.Blog.Maui.App.Application.Commands.RefreshToken;
using OmegaFY.Blog.Maui.App.Application.Commands.Logoff;
using OmegaFY.Blog.Maui.App.Application.Commands.RegisterNewUser;
using OmegaFY.Blog.Maui.App.Application.Base;

namespace OmegaFY.Blog.Maui.App.Services;

public interface ILoggedUserService
{
    public Task<GenericResult<ExcludeAccountCommandResult>> ExcludeAccountAsync(ExcludeAccountCommand command);

    public Task<GenericResult<LoginCommandResult>> LoginAsync(LoginCommand command);

    public Task<GenericResult<LogoffCommandResult>> LogoffAsync(LogoffCommand command);

    public Task<GenericResult<RefreshTokenCommandResult>> RefreshTokenAsync(RefreshTokenCommand command);

    public Task<GenericResult<RegisterNewUserCommandResult>> RegisterNewUserAsync(RegisterNewUserCommand command);

    public Task<string> TryGetUserBearerTokenAsync();

    public Task<Guid?> TryGetUserRefreshTokenAsync();
}