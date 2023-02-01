using OmegaFY.Blog.Maui.App.Infra.ExternalServices.Base;

namespace OmegaFY.Blog.Maui.App.Infra.ExternalServices.Implementations;

internal class OmegaFyBlogClient : AbstractHttpClient, IOmegaFyBlogClient
{
    public OmegaFyBlogClient(HttpClient httpClient) : base(httpClient)
    {
    }
}