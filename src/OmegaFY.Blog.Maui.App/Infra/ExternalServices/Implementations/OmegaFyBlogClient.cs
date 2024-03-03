using OmegaFY.Blog.Maui.App.Common.Models;
using OmegaFY.Blog.Maui.App.Infra.Dialogs;
using OmegaFY.Blog.Maui.App.Infra.Extensions;
using OmegaFY.Blog.Maui.App.Infra.ExternalServices.Base;
using OmegaFY.Blog.Maui.App.Infra.ExternalServices.Constants;
using OmegaFY.Blog.Maui.App.Models.APIs.Requests;
using OmegaFY.Blog.Maui.App.Models.APIs.Results;

namespace OmegaFY.Blog.Maui.App.Infra.ExternalServices.Implementations;

internal class OmegaFyBlogClient : AbstractHttpClient, IOmegaFyBlogClient
{
    //TODO PASSAR PRO BASE
    private readonly IConnectivity _connectivity;

    private readonly IDialogProvider _dialogProvider;

    protected override string HttpClientName => nameof(OmegaFyBlogClient);

    public OmegaFyBlogClient(IHttpClientFactory httpClientFactory) : base(httpClientFactory) { }

    public async Task<ApiResponse<LoginResult>> LoginAsync(LoginRequest command, CancellationToken cancellationToken)
        => await SendAsync(PostAsync<LoginRequest, ApiResponse<LoginResult>>(OmegaFyBlogRoutesConstants.LOGIN, command, cancellationToken));

    public async Task<ApiResponse<RefreshTokenResult>> RefreshTokenAsync(RefreshTokenRequest command, CancellationToken cancellationToken)
        => await SendAsync(PostAsync<RefreshTokenRequest, ApiResponse<RefreshTokenResult>>(OmegaFyBlogRoutesConstants.REFRESH_TOKEN, command, cancellationToken));

    public Task<ApiResponse<ExcludeAccountResult>> ExcludeAccountAsync(ExcludeAccountRequest excludeAccountRequest, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<LogoffResult>> LogoffAsync(LogoffRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    private async Task<ApiResponse<TResult>> SendAsync<TResult>(Task<ApiResponse<TResult>> task)
    {
        try
        {
            //TODO PASSAR PRO BASE
            bool hasStrongConnection = await _dialogProvider.DisplayAlertAsync(new("T", "M"), () => !_connectivity.HasStrongConnection());

            if (!hasStrongConnection) return default; // TODO Exception

            return await task;
        }
        catch (Exception ex)
        {
            //TODO exibir mensagem de erro?

            return new ApiResponse<TResult>()
            {
                Data = default,
                Errors = [new ValidationError(ex.Message, ex.Message)],
                Succeeded = false,
            };
        }
    }
}