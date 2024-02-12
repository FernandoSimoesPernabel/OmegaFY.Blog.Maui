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
    }
}