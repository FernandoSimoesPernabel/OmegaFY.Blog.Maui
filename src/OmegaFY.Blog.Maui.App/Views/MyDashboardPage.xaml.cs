using OmegaFY.Blog.Maui.App.ViewModels;

namespace OmegaFY.Blog.Maui.App.Views;

public partial class MyDashboardPage : ContentPage
{
	public MyDashboardPage(MyDashboardViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}