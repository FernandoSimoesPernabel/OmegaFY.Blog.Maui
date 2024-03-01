using MediatR;
using OmegaFY.Blog.Maui.App.Application.Base;

namespace OmegaFY.Blog.Maui.App.Application.Commands.Users.Logoff;

public sealed record class LogoffCommand : IRequest<GenericResult<LogoffCommandResult>>, IRequiresStrongConnection, IRequiresAnyConnection
{
    public Guid RefreshToken { get; }

    public LogoffCommand(Guid refreshToken)
    {
        RefreshToken = refreshToken;
    }
}