using OmegaFY.Blog.Maui.App.Infra.ExternalServices.DTOs;

namespace OmegaFY.Blog.Maui.App.Services;

public interface IUserService
{
    public Task<ExcludeAccountCommandResult> ExcludeAccountAsync(ExcludeAccountCommand command);

    public Task<LoginCommandResult> LoginAsync(LoginCommand command);

    public Task<LogoffCommandResult> LogoffAsync(LogoffCommand command);

    public Task<RefreshTokenCommandResult> RefreshTokenAsync(RefreshTokenCommand command);

    public Task<RegisterNewUserCommandResult> RegisterNewUserAsync(RegisterNewUserCommand command);
}