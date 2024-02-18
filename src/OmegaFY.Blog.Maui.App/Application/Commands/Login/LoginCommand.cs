using MediatR;
using OmegaFY.Blog.Maui.App.Application.Base;

namespace OmegaFY.Blog.Maui.App.Application.Commands.Login;

public sealed record class LoginCommand : IRequest<GenericResult<LoginCommandResult>>, IRequiresStrongConnection, IRequiresAnyConnection
{
    public string Email { get; }

    public string Password { get; }

    public bool RememberMe { get; }

    public LoginCommand(string email, string password, bool rememberMe)
    {
        Email = email;
        Password = password;
        RememberMe = rememberMe;
    }
}