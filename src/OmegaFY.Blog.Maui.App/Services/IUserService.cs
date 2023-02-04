namespace OmegaFY.Blog.Maui.App.Services;

public interface IUserService
{
    public Task<object> LoginAsync();

    public Task<object> RegisterNewUserAsync();
}