
namespace OmegaFY.Blog.Maui.App.Infra.Navigation;

public interface INavigationProvider
{
    public Task GoToMyDashboardAsync(Guid userId);
}