using OmegaFY.Blog.Maui.App.Application.Commands.Login;
using OmegaFY.Blog.Maui.App.Application.Commands.RegisterNewUser;
using OmegaFY.Blog.Maui.App.Services;
using OmegaFY.Blog.Maui.App.ViewModels.Base;

namespace OmegaFY.Blog.Maui.App.ViewModels;

public partial class LoginPageViewModel : BaseViewModel
{
    private readonly IUserService _userService;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(EnableLoginButton))]
    private string userEmail;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(EnableLoginButton))]
    private string password;

    public bool EnableLoginButton => !string.IsNullOrWhiteSpace(UserEmail) && !string.IsNullOrWhiteSpace(Password);

    public LoginPageViewModel(IUserService userService)
    {
        _userService = userService;

        ViewTitle = "Main Page";
    }

    [RelayCommand]
    public async Task LoginAsync()
    {
        LoginCommandResult result = await _userService.LoginAsync(new LoginCommand(UserEmail, Password));

        //if (result.Succeeded)
        //{
        //    //Proxima tela
        //}
    }

    [RelayCommand]
    public async Task RegisterNewUserAsync()
    {
        RegisterNewUserCommandResult result = await _userService.RegisterNewUserAsync(null);

        //if (result.Succeeded)
        //{
        //    //Proxima tela
        //}
    }
}