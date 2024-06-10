using OmegaFY.Blog.Maui.App.Infra.Navigation;
using OmegaFY.Blog.Maui.App.ViewModels.Base;

namespace OmegaFY.Blog.Maui.App.ViewModels;

public partial class MyDashboardViewModel : BaseViewModel, IQueryAttributable
{
    public Guid UserId { get; private set; }

    public MyDashboardViewModel(INavigationProvider navigationProvider) : base(navigationProvider, "My Dashboard") { }

    public override void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        UserId = (Guid)query["userId"];
    }
}