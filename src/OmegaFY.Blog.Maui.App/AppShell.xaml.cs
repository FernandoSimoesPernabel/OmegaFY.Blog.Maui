using OmegaFY.Blog.Maui.App.Views;

namespace OmegaFY.Blog.Maui.App;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(MyDashboardPage), typeof(MyDashboardPage));
        Routing.RegisterRoute(nameof(RegisterNewUserPage), typeof(RegisterNewUserPage));
        Routing.RegisterRoute(nameof(ForgotPasswordPage), typeof(ForgotPasswordPage));
        Routing.RegisterRoute(nameof(MostRecentCommentsPage), typeof(MostRecentCommentsPage));
        Routing.RegisterRoute(nameof(MostRecentPostsPage), typeof(MostRecentPostsPage));
        Routing.RegisterRoute(nameof(MostRecentSharesPage), typeof(MostRecentSharesPage));
    }
}