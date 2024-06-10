using OmegaFY.Blog.Maui.App.Common.Models;
using OmegaFY.Blog.Maui.App.Infra.Dialogs;
using OmegaFY.Blog.Maui.App.Infra.ExternalServices.Base;
using OmegaFY.Blog.Maui.App.Infra.ExternalServices.Constants;
using OmegaFY.Blog.Maui.App.Models.APIs.Requests;
using OmegaFY.Blog.Maui.App.Models.APIs.Results;

namespace OmegaFY.Blog.Maui.App.Infra.ExternalServices.Implementations;

internal class OmegaFyBlogClient : AbstractHttpClient, IOmegaFyBlogClient
{
    protected override string HttpClientName => nameof(OmegaFyBlogClient);

    public OmegaFyBlogClient(IHttpClientFactory httpClientFactory, IConnectivity connectivity, IDialogProvider dialogProvider)
        : base(httpClientFactory, connectivity, dialogProvider) { }

    public async Task<ApiResponse<LoginResult>> LoginAsync(LoginRequest request, CancellationToken cancellationToken)
        => await SendAsync(PostAsync<LoginRequest, ApiResponse<LoginResult>>(OmegaFyBlogRoutesConstants.LOGIN, request, cancellationToken));

    public async Task<ApiResponse<RefreshTokenResult>> RefreshTokenAsync(RefreshTokenRequest request, CancellationToken cancellationToken)
        => await SendAsync(PostAsync<RefreshTokenRequest, ApiResponse<RefreshTokenResult>>(OmegaFyBlogRoutesConstants.REFRESH_TOKEN, request, cancellationToken));

    public async Task<ApiResponse<ExcludeAccountResult>> ExcludeAccountAsync(Guid userId, CancellationToken cancellationToken)
    {
        string route = $"{OmegaFyBlogRoutesConstants.EXCLUDE_ACCOUNT}/{userId}";
        return await SendAsync(DeleteAsync<ApiResponse<ExcludeAccountResult>>(route, cancellationToken));
    }

    public async Task<ApiResponse<LogoffResult>> LogoffAsync(Guid refreshToken, CancellationToken cancellationToken)
    {
        string route = $"{OmegaFyBlogRoutesConstants.LOGOFF}/{refreshToken}";
        return await SendAsync(PostAsync<ApiResponse<LogoffResult>>(route, cancellationToken));
    }

    private async Task<ApiResponse<TResult>> SendAsync<TResult>(Task<ApiResponse<TResult>> task)
    {
        try
        {
            bool hasStrongConnection = await HasStrongConnectionAsync();

            if (!hasStrongConnection)
            {
                return new ApiResponse<TResult>()
                {
                    Data = default,
                    Errors = [new ValidationError("", "")],
                    Succeeded = false
                };
            }

            return await task;
        }
        catch (Exception ex)
        {
            return new ApiResponse<TResult>()
            {
                Data = default,
                Errors = [new ValidationError(ex.Message, ex.Message)],
                Succeeded = false
            };
        }
    }
}