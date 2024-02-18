
using OmegaFY.Blog.Maui.App.Views;

namespace OmegaFY.Blog.Maui.App.Infra.Navigation.Implementations;

internal sealed class ShellNavigation : INavigationProvider
{
    public async Task GoToForgotPasswordAsync(string userEmail) 
        => await Shell.Current.GoToAsync(nameof(ForgotPasswordPage), new Dictionary<string, object> { { nameof(userEmail), userEmail } });

    public async Task GoToMyDashboardAsync(Guid userId) 
        => await Shell.Current.GoToAsync(nameof(MyDashboardPage), new Dictionary<string, object> { { nameof(userId), userId } });

    public async Task GoToRegisterNewUserAsync(string userEmail) 
        => await Shell.Current.GoToAsync(nameof(RegisterNewUserPage), new Dictionary<string, object> { { nameof(userEmail), userEmail } });
}