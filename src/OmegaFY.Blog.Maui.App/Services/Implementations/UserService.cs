using OmegaFY.Blog.Maui.App.Infra.ExternalServices;

namespace OmegaFY.Blog.Maui.App.Services.Implementations;

internal class UserService : IUserService
{
    private readonly IOmegaFyBlogClient _omegaFyBlogClient;

    public UserService(IOmegaFyBlogClient omegaFyBlogClient)
    {
        _omegaFyBlogClient = omegaFyBlogClient;
    }

    public Task<object> LoginAsync()
    {
        throw new NotImplementedException();
    }

    public Task<object> RegisterNewUserAsync()
    {
        throw new NotImplementedException();
    }
}