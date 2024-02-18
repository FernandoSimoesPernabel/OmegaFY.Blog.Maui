using OmegaFY.Blog.Maui.App.ViewModels;

namespace OmegaFY.Blog.Maui.App.Views;

public partial class MostRecentSharesPage : ContentPage
{
	public MostRecentSharesPage(MostRecentSharesViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}