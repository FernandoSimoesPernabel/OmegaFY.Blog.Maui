using OmegaFY.Blog.Maui.App.ViewModels;

namespace OmegaFY.Blog.Maui.App.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override async void OnAppearing() => await (BindingContext as LoginPageViewModel).InitializeAsync();
}