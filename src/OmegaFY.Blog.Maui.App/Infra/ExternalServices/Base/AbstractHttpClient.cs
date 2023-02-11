using System.Net.Http.Json;

namespace OmegaFY.Blog.Maui.App.Infra.ExternalServices.Base;

internal abstract class AbstractHttpClient
{
    private readonly Lazy<HttpClient> _lazyHttpClient;

    protected HttpClient HttpClient => _lazyHttpClient.Value;

    protected abstract string HttpClientName { get; }

    protected AbstractHttpClient(IHttpClientFactory httpClientFactory) => _lazyHttpClient = new(() => httpClientFactory.CreateClient(HttpClientName));

    protected async Task<TResult> GetAsync<TResult>(string route, CancellationToken cancellationToken)
    {
        return await HttpClient.GetFromJsonAsync<TResult>(route, cancellationToken);
    }

    protected async Task<TResult> PostAsync<TRequest, TResult>(string route, TRequest request, CancellationToken cancellationToken)
    {
        HttpResponseMessage result = await HttpClient.PostAsJsonAsync(route, request, cancellationToken);
        return await result.Content.ReadFromJsonAsync<TResult>(cancellationToken: cancellationToken);
    }

    protected async Task<TResult> PutAsync<TRequest, TResult>(string route, TRequest request, CancellationToken cancellationToken)
    {
        HttpResponseMessage result = await HttpClient.PutAsJsonAsync(route, request, cancellationToken);
        return await result.Content.ReadFromJsonAsync<TResult>(cancellationToken: cancellationToken);
    }

    protected async Task<TResult> PatchAsync<TRequest, TResult>(string route, TRequest request, CancellationToken cancellationToken)
    {
        HttpResponseMessage result = await HttpClient.PatchAsJsonAsync(route, request, cancellationToken);
        return await result.Content.ReadFromJsonAsync<TResult>(cancellationToken: cancellationToken);
    }

    protected async Task<TResult> DeleteAsync<TResult>(string route, CancellationToken cancellationToken)
    {
        return await HttpClient.DeleteFromJsonAsync<TResult>(route, cancellationToken);
    }
}