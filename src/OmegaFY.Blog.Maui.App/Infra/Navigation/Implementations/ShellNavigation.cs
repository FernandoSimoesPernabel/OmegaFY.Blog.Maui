
using OmegaFY.Blog.Maui.App.Views;

namespace OmegaFY.Blog.Maui.App.Infra.Navigation.Implementations;

internal sealed class ShellNavigation : INavigationProvider
{
    public async Task GoToMyDashboardAsync(Guid userId) 
        => await Shell.Current.GoToAsync(nameof(MyDashboardPage), new Dictionary<string, object> { { nameof(userId), userId } });
}