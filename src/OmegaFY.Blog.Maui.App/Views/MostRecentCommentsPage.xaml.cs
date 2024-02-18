using OmegaFY.Blog.Maui.App.ViewModels;

namespace OmegaFY.Blog.Maui.App.Views;

public partial class MostRecentCommentsPage : ContentPage
{
	public MostRecentCommentsPage(MostRecentCommentsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}