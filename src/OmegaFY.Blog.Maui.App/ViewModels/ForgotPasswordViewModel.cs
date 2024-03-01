using OmegaFY.Blog.Maui.App.Infra.Navigation;
using OmegaFY.Blog.Maui.App.Services;
using OmegaFY.Blog.Maui.App.ViewModels.Base;

namespace OmegaFY.Blog.Maui.App.ViewModels;

public partial class ForgotPasswordViewModel : BaseViewModel, IQueryAttributable
{
    private readonly ILoggedUserService _loggedUserService;

    [ObservableProperty]
    private string userEmail;

    public ForgotPasswordViewModel(INavigationProvider navigationProvider, ILoggedUserService loggedUserService) : base(navigationProvider, "Forgot Password")
    {
        _loggedUserService = loggedUserService;
    }

    public override void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        UserEmail = (string)query["userEmail"];
    }
}