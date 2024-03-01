using MediatR;
using OmegaFY.Blog.Maui.App.Application.Base;
using OmegaFY.Blog.Maui.App.Services;

namespace OmegaFY.Blog.Maui.App.Application.Commands.User.Login;

internal class LoginCommandHandler : IRequestHandler<LoginCommand, GenericResult<LoginCommandResult>>
{
    private readonly ILoggedUserService _loggedUserService;

    public LoginCommandHandler(ILoggedUserService loggedUserService)
    {
        _loggedUserService = loggedUserService;
    }

    public async Task<GenericResult<LoginCommandResult>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        return await _loggedUserService.LoginAsync(request);
    }
}