using OmegaFY.Blog.Maui.App.Infra.Navigation;
using OmegaFY.Blog.Maui.App.ViewModels.Base;

namespace OmegaFY.Blog.Maui.App.ViewModels;

public partial class RegisterNewUserViewModel : BaseViewModel, IQueryAttributable
{
    [ObservableProperty]
    private string userEmail;

    public RegisterNewUserViewModel(INavigationProvider navigationProvider) : base(navigationProvider, "Register New User") { }

    public override void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        UserEmail = (string)query["userEmail"];
    }
}