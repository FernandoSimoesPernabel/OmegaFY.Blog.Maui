using OmegaFY.Blog.Maui.App.Infra.ExternalServices;
using OmegaFY.Blog.Maui.App.Domain.Commands.ExcludeAccount;
using OmegaFY.Blog.Maui.App.Domain.Commands.Login;
using OmegaFY.Blog.Maui.App.Domain.Commands.Logoff;
using OmegaFY.Blog.Maui.App.Domain.Commands.RefreshToken;
using OmegaFY.Blog.Maui.App.Domain.Commands.RegisterNewUser;

namespace OmegaFY.Blog.Maui.App.Services.Implementations;

internal class UserService : IUserService
{
    private readonly IOmegaFyBlogClient _omegaFyBlogClient;

    public UserService(IOmegaFyBlogClient omegaFyBlogClient)
    {
        _omegaFyBlogClient = omegaFyBlogClient;
    }

    public Task<ExcludeAccountCommandResult> ExcludeAccountAsync(ExcludeAccountCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<LoginCommandResult> LoginAsync(LoginCommand command)
    {
        throw new NotImplementedException();
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