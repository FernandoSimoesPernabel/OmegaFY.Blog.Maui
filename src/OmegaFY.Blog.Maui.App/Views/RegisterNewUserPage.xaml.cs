using OmegaFY.Blog.Maui.App.ViewModels;

namespace OmegaFY.Blog.Maui.App.Views;

public partial class RegisterNewUserPage : ContentPage
{
	public RegisterNewUserPage(RegisterNewUserViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}