using OmegaFY.Blog.Maui.App.Infra.Navigation;
using OmegaFY.Blog.Maui.App.ViewModels.Base;

namespace OmegaFY.Blog.Maui.App.ViewModels;

public partial class MostRecentPostsViewModel : BaseViewModel
{
    public MostRecentPostsViewModel(INavigationProvider navigationProvider) : base(navigationProvider, "Most Recent Posts") { }
}