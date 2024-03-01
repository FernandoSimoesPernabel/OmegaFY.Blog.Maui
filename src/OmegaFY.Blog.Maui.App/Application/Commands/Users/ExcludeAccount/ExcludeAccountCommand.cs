using MediatR;
using OmegaFY.Blog.Maui.App.Application.Base;

namespace OmegaFY.Blog.Maui.App.Application.Commands.Users.ExcludeAccount;

public sealed record class ExcludeAccountCommand : IRequest<GenericResult<ExcludeAccountCommandResult>>, IRequiresStrongConnection, IRequiresAnyConnection
{
}