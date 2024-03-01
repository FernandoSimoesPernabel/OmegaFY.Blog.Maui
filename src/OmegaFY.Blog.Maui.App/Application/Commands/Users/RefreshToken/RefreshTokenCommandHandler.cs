using MediatR;
using OmegaFY.Blog.Maui.App.Application.Base;
using OmegaFY.Blog.Maui.App.Application.Extensions;
using OmegaFY.Blog.Maui.App.Infra.ExternalServices;
using OmegaFY.Blog.Maui.App.Infra.ExternalServices.Base;

namespace OmegaFY.Blog.Maui.App.Application.Commands.Users.RefreshToken;

internal class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, GenericResult<RefreshTokenCommandResult>>
{
    private readonly IOmegaFyBlogClient _omegaFyBlogClient;

    public RefreshTokenCommandHandler(IOmegaFyBlogClient omegaFyBlogClient) => _omegaFyBlogClient = omegaFyBlogClient;

    public async Task<GenericResult<RefreshTokenCommandResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        ApiResponse<RefreshTokenCommandResult> result = await _omegaFyBlogClient.RefreshTokenAsync(request, cancellationToken);
        return result.ToGenericResult();
    }
}