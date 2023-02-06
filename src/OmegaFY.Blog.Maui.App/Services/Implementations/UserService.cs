using OmegaFY.Blog.Maui.App.Infra.ExternalServices;
using OmegaFY.Blog.Maui.App.Application.Commands.ExcludeAccount;
using OmegaFY.Blog.Maui.App.Application.Commands.Login;
using OmegaFY.Blog.Maui.App.Application.Commands.Logoff;
using OmegaFY.Blog.Maui.App.Application.Commands.RefreshToken;
using OmegaFY.Blog.Maui.App.Application.Commands.RegisterNewUser;
using OmegaFY.Blog.Maui.App.Application.Models;
using OmegaFY.Blog.Maui.App.Application.Repositories;
using OmegaFY.Blog.Maui.App.Application.Base;

namespace OmegaFY.Blog.Maui.App.Services.Implementations;

internal class UserService : IUserService
{
    private readonly IOmegaFyBlogClient _omegaFyBlogClient;

    //private readonly IUserRepository _repository;

    public UserService(IOmegaFyBlogClient omegaFyBlogClient/*, IUserRepository repository*/)
    {
        _omegaFyBlogClient = omegaFyBlogClient;
        //_repository = repository;
    }

    public Task<ExcludeAccountCommandResult> ExcludeAccountAsync(ExcludeAccountCommand command)
    {
        throw new NotImplementedException();
    }

    public async Task<LoginCommandResult> LoginAsync(LoginCommand command)
    {
        LoggedUserInfo loggedUser = new();

        ApiResponse<LoginCommandResult> result = await _omegaFyBlogClient.LoginAsync(command, CancellationToken.None);

        return result.Data;
    }

    public Task<LogoffCommandResult> LogoffAsync(LogoffCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<RefreshTokenCommandResult> RefreshTokenAsync(RefreshTokenCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<RegisterNewUserCommandResult> RegisterNewUserAsync(RegisterNewUserCommand command)
    {
        throw new NotImplementedException();
    }
}