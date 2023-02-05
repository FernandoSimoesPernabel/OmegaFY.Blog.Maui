using OmegaFY.Blog.Maui.App.Domain.Commands.ExcludeAccount;
using OmegaFY.Blog.Maui.App.Domain.Commands.Login;
using OmegaFY.Blog.Maui.App.Domain.Commands.Logoff;
using OmegaFY.Blog.Maui.App.Domain.Commands.RefreshToken;
using OmegaFY.Blog.Maui.App.Domain.Commands.RegisterNewUser;

namespace OmegaFY.Blog.Maui.App.Services;

public interface IUserService
{
    public Task<ExcludeAccountCommandResult> ExcludeAccountAsync(ExcludeAccountCommand command);

    public Task<LoginCommandResult> LoginAsync(LoginCommand command);

    public Task<LogoffCommandResult> LogoffAsync(LogoffCommand command);

    public Task<RefreshTokenCommandResult> RefreshTokenAsync(RefreshTokenCommand command);

    public Task<RegisterNewUserCommandResult> RegisterNewUserAsync(RegisterNewUserCommand command);
}