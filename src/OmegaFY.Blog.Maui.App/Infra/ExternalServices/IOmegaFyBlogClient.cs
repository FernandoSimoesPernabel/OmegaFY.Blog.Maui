using OmegaFY.Blog.Maui.App.Infra.ExternalServices.Base;
using OmegaFY.Blog.Maui.App.Models.APIs.Requests;
using OmegaFY.Blog.Maui.App.Models.APIs.Results;

namespace OmegaFY.Blog.Maui.App.Infra.ExternalServices;

public interface IOmegaFyBlogClient
{
    public Task<ApiResponse<ExcludeAccountResult>> ExcludeAccountAsync(ExcludeAccountRequest excludeAccountRequest, CancellationToken cancellationToken);
    
    public Task<ApiResponse<LoginResult>> LoginAsync(LoginRequest command, CancellationToken cancellationToken);

    public Task<ApiResponse<LogoffResult>> LogoffAsync(LogoffRequest request, CancellationToken cancellationToken);
    
    public Task<ApiResponse<RefreshTokenResult>> RefreshTokenAsync(RefreshTokenRequest command, CancellationToken cancellationToken);
}