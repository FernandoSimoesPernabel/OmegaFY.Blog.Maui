using MediatR;
using OmegaFY.Blog.Maui.App.Infra.Navigation;
using OmegaFY.Blog.Maui.App.ViewModels.Base;

namespace OmegaFY.Blog.Maui.App.ViewModels;

public sealed class MyDashboardViewModel : BaseViewModel, IQueryAttributable
{
    public Guid UserId { get; private set; }

    public MyDashboardViewModel(IMediator mediator, INavigationProvider navigationProvider) : base(mediator, navigationProvider, "My Dashboard") { }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        UserId = (Guid)query["userId"];
    }
}