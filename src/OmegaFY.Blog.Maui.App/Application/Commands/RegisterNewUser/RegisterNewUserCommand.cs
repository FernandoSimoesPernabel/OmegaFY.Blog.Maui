using MediatR;
using OmegaFY.Blog.Maui.App.Application.Base;

namespace OmegaFY.Blog.Maui.App.Application.Commands.RegisterNewUser;

public sealed record class RegisterNewUserCommand : IRequest<GenericResult<RegisterNewUserCommandResult>>, IRequiresStrongConnection, IRequiresAnyConnection
{
    public string Email { get; }

    public string DisplayName { get; }

    public string Password { get; }

    public RegisterNewUserCommand(string email, string displayName, string password)
    {
        Email = email;
        DisplayName = displayName;
        Password = password;
    }
}