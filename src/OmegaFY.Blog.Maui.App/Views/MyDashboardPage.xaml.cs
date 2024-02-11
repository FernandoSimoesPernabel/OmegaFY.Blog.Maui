using OmegaFY.Blog.Maui.App.ViewModels;

namespace OmegaFY.Blog.Maui.App.Views;

public partial class MyDashboardPage : TabbedPage
{
	public MyDashboardPage(MyDashboardViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}