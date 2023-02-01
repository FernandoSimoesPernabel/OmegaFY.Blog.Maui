namespace OmegaFY.Blog.Maui.App.Infra.ExternalServices.Base;

internal abstract class AbstractHttpClient
{
    protected readonly HttpClient _httpClient;

    protected AbstractHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}