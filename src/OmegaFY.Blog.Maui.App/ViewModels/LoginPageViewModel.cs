using OmegaFY.Blog.Maui.App.ViewModels.Base;

namespace OmegaFY.Blog.Maui.App.ViewModels;

public partial class LoginPageViewModel : BaseViewModel
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(EnableLoginButton))]
    private string userEmail;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(EnableLoginButton))]
    private string password;

    public bool EnableLoginButton => !string.IsNullOrWhiteSpace(UserEmail) && !string.IsNullOrWhiteSpace(Password);

    public LoginPageViewModel()
    {
        ViewTitle = "Main Page";
    }

    [RelayCommand]
    public Task LoginAsync()
    {
        return Task.CompletedTask;
    }

    [RelayCommand]
    public Task RegisterNewUserAsync()
    {
        return Task.CompletedTask;
    }
}
