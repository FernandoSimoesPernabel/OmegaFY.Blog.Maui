using OmegaFY.Blog.Maui.App.Models.APIs.Base;
using OmegaFY.Blog.Maui.App.Models.APIs.Requests;
using OmegaFY.Blog.Maui.App.Models.APIs.Results;

namespace OmegaFY.Blog.Maui.App.Services;

public interface ILoggedUserService
{
    public Task<GenericResult<ExcludeAccountResult>> ExcludeAccountAsync(CancellationToken cancellationToken);

    public Task<GenericResult<LoginResult>> LoginAsync(LoginRequest request, CancellationToken cancellationToken);

    public Task LogoffLocallyAsync();

    public Task LogoffFromServerAsync(CancellationToken cancellationToken);

    public Task<GenericResult<RefreshTokenResult>> RefreshTokenAsync(RefreshTokenRequest request, CancellationToken cancellationToken);

    public Task<GenericResult<RegisterNewUserResult>> RegisterNewUserAsync(RegisterNewUserRequest request, CancellationToken cancellationToken);

    public string TryGetUserBearerToken();

    public string TryGetUserEmail();

    public Task<string> TryGetUserPasswordAsync();

    public Task<Guid?> TryGetUserRefreshTokenAsync();
}