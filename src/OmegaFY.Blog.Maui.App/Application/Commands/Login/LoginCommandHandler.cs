using MediatR;
using OmegaFY.Blog.Maui.App.Application.Base;
using OmegaFY.Blog.Maui.App.Application.Extensions;
using OmegaFY.Blog.Maui.App.Application.Models;
using OmegaFY.Blog.Maui.App.Infra.ExternalServices;
using OmegaFY.Blog.Maui.App.Infra.ExternalServices.Base;

namespace OmegaFY.Blog.Maui.App.Application.Commands.Login;

internal class LoginCommandHandler : IRequestHandler<LoginCommand, GenericResult<LoginCommandResult>>
{
    private readonly IOmegaFyBlogClient _omegaFyBlogClient;

    public LoginCommandHandler(IOmegaFyBlogClient omegaFyBlogClient)
    {
        _omegaFyBlogClient = omegaFyBlogClient;
    }

    public async Task<GenericResult<LoginCommandResult>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        LoggedUserInfo loggedUser = new();

        ApiResponse<LoginCommandResult> result = await _omegaFyBlogClient.LoginAsync(request, CancellationToken.None);

        return result.ToGenericResult();
    }
}