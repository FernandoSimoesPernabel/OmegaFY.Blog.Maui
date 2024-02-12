using MediatR;
using OmegaFY.Blog.Maui.App.Infra.Navigation;
using OmegaFY.Blog.Maui.App.ViewModels.Base;

namespace OmegaFY.Blog.Maui.App.ViewModels;

public partial class ForgotPasswordViewModel : BaseViewModel, IQueryAttributable
{
    [ObservableProperty]
    private string userEmail;

    public ForgotPasswordViewModel(IMediator mediator, INavigationProvider navigationProvider) : base(mediator, navigationProvider, "Forgot Password") { }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        UserEmail = (string)query["userEmail"];
    }
}