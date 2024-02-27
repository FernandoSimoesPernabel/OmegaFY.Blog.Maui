
namespace OmegaFY.Blog.Maui.App.Infra.Navigation;

public interface INavigationProvider
{
    public Task GoToForgotPasswordAsync(string userEmail);

    public Task GoToLoginAsync();

    public Task GoToMyDashboardAsync(Guid userId);

    public Task GoToRegisterNewUserAsync(string userEmail);
}