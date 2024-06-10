using OmegaFY.Blog.Maui.App.Infra.Dialogs;
using OmegaFY.Blog.Maui.App.Infra.Extensions;
using System.Net.Http.Json;

namespace OmegaFY.Blog.Maui.App.Infra.ExternalServices.Base;

internal abstract class AbstractHttpClient
{
    protected readonly Lazy<HttpClient> _lazyHttpClient;

    protected readonly IConnectivity _connectivity;

    protected readonly IDialogProvider _dialogProvider;

    protected HttpClient HttpClient => _lazyHttpClient.Value;

    protected abstract string HttpClientName { get; }

    protected AbstractHttpClient(IHttpClientFactory httpClientFactory, IConnectivity connectivity, IDialogProvider dialogProvider)
    {
        _lazyHttpClient = new(() => httpClientFactory.CreateClient(HttpClientName));
        _connectivity = connectivity;
        _dialogProvider = dialogProvider;
    }

    protected async Task<TResult> GetAsync<TResult>(string route, CancellationToken cancellationToken) 
        => await HttpClient.GetFromJsonAsync<TResult>(route, cancellationToken);

    protected async Task<TResult> PostAsync<TResult>(string route, CancellationToken cancellationToken)
    {
        HttpResponseMessage result = await HttpClient.PostAsJsonAsync(route, cancellationToken);
        return await result.Content.ReadFromJsonAsync<TResult>(cancellationToken);
    }

    protected async Task<TResult> PostAsync<TRequest, TResult>(string route, TRequest request, CancellationToken cancellationToken)
    {
        HttpResponseMessage result = await HttpClient.PostAsJsonAsync(route, request, cancellationToken);
        return await result.Content.ReadFromJsonAsync<TResult>(cancellationToken);
    }

    protected async Task<TResult> PutAsync<TRequest, TResult>(string route, TRequest request, CancellationToken cancellationToken)
    {
        HttpResponseMessage result = await HttpClient.PutAsJsonAsync(route, request, cancellationToken);
        return await result.Content.ReadFromJsonAsync<TResult>(cancellationToken);
    }

    protected async Task<TResult> PatchAsync<TRequest, TResult>(string route, TRequest request, CancellationToken cancellationToken)
    {
        HttpResponseMessage result = await HttpClient.PatchAsJsonAsync(route, request, cancellationToken);
        return await result.Content.ReadFromJsonAsync<TResult>(cancellationToken);
    }

    protected async Task<TResult> DeleteAsync<TResult>(string route, CancellationToken cancellationToken)
        => await HttpClient.DeleteFromJsonAsync<TResult>(route, cancellationToken);

    protected async Task<bool> HasStrongConnectionAsync()
        => await _dialogProvider.DisplayAlertAsync(new("T", "M"), () => !_connectivity.HasStrongConnection());
}