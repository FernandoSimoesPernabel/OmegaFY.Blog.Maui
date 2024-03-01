using MediatR;
using OmegaFY.Blog.Maui.App.Application.Base;

namespace OmegaFY.Blog.Maui.App.Application.Commands.Users.RefreshToken;

public sealed record class RefreshTokenCommand : IRequest<GenericResult<RefreshTokenCommandResult>>, IRequiresStrongConnection, IRequiresAnyConnection
{
    public string CurrentToken { get; }

    public Guid RefreshToken { get; }

    public RefreshTokenCommand(string currentToken, Guid refreshToken)
    {
        CurrentToken = currentToken;
        RefreshToken = refreshToken;
    }
}