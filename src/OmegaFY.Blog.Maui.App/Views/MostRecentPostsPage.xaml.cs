using OmegaFY.Blog.Maui.App.ViewModels;

namespace OmegaFY.Blog.Maui.App.Views;

public partial class MostRecentPostsPage : ContentPage
{
	public MostRecentPostsPage(MostRecentPostsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}