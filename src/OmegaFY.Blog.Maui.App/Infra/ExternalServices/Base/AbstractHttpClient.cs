using System.Net.Http.Json;

namespace OmegaFY.Blog.Maui.App.Infra.ExternalServices.Base;

internal abstract class AbstractHttpClient
{
    protected readonly HttpClient _httpClient;

    protected abstract string HttpClientName { get; }

    protected AbstractHttpClient(IHttpClientFactory httpClientFactory) => _httpClient = httpClientFactory.CreateClient(HttpClientName);

    protected async Task<TResult> GetAsync<TResult>(string route, CancellationToken cancellationToken)
    {
        return await _httpClient.GetFromJsonAsync<TResult>(route, cancellationToken);
    }

    protected async Task<TResult> PostAsync<TRequest, TResult>(string route, TRequest request, CancellationToken cancellationToken)
    {
        HttpResponseMessage result = await _httpClient.PostAsJsonAsync(route, request, cancellationToken);
        return await result.Content.ReadFromJsonAsync<TResult>(cancellationToken: cancellationToken);
    }

    protected async Task<TResult> PutAsync<TRequest, TResult>(string route, TRequest request, CancellationToken cancellationToken)
    {
        HttpResponseMessage result = await _httpClient.PutAsJsonAsync(route, request, cancellationToken);
        return await result.Content.ReadFromJsonAsync<TResult>(cancellationToken: cancellationToken);
    }

    protected async Task<TResult> PatchAsync<TRequest, TResult>(string route, TRequest request, CancellationToken cancellationToken)
    {
        HttpResponseMessage result = await _httpClient.PatchAsJsonAsync(route, request, cancellationToken);
        return await result.Content.ReadFromJsonAsync<TResult>(cancellationToken: cancellationToken);
    }

    protected async Task<TResult> DeleteAsync<TResult>(string route, CancellationToken cancellationToken)
    {
        return await _httpClient.DeleteFromJsonAsync<TResult>(route, cancellationToken);
    }
}