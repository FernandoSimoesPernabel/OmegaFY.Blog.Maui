using MediatR;
using OmegaFY.Blog.Maui.App.Infra.Navigation;
using OmegaFY.Blog.Maui.App.ViewModels.Base;

namespace OmegaFY.Blog.Maui.App.ViewModels;

public partial class MostRecentSharesViewModel : BaseViewModel
{
    public MostRecentSharesViewModel(IMediator mediator, INavigationProvider navigationProvider) : base(mediator, navigationProvider, "Most Recent Shares") { }
}