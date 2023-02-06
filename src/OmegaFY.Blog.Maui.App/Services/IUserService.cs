using OmegaFY.Blog.Maui.App.Application.Commands.ExcludeAccount;
using OmegaFY.Blog.Maui.App.Application.Commands.Login;
using OmegaFY.Blog.Maui.App.Application.Commands.Logoff;
using OmegaFY.Blog.Maui.App.Application.Commands.RefreshToken;
using OmegaFY.Blog.Maui.App.Application.Commands.RegisterNewUser;

namespace OmegaFY.Blog.Maui.App.Services;

public interface IUserService
{
    public Task<ExcludeAccountCommandResult> ExcludeAccountAsync(ExcludeAccountCommand command);

    public Task<LoginCommandResult> LoginAsync(LoginCommand command);

    public Task<LogoffCommandResult> LogoffAsync(LogoffCommand command);

    public Task<RefreshTokenCommandResult> RefreshTokenAsync(RefreshTokenCommand command);

    public Task<RegisterNewUserCommandResult> RegisterNewUserAsync(RegisterNewUserCommand command);
}