using OmegaFY.Blog.Maui.App.Infra.Navigation;
using OmegaFY.Blog.Maui.App.ViewModels.Base;

namespace OmegaFY.Blog.Maui.App.ViewModels;

public partial class MostRecentCommentsViewModel : BaseViewModel
{
    public MostRecentCommentsViewModel(INavigationProvider navigationProvider) : base(navigationProvider, "Most Recent Comments") { }
}