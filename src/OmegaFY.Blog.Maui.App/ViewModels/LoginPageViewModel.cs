using OmegaFY.Blog.Maui.App.Infra.Navigation;
using OmegaFY.Blog.Maui.App.Models.APIs.Base;
using OmegaFY.Blog.Maui.App.Models.APIs.Requests;
using OmegaFY.Blog.Maui.App.Models.APIs.Results;
using OmegaFY.Blog.Maui.App.Services;
using OmegaFY.Blog.Maui.App.ViewModels.Base;

namespace OmegaFY.Blog.Maui.App.ViewModels;

public partial class LoginPageViewModel : BaseViewModel
{
    private readonly ILoggedUserService _loggedUserService;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(EnableLoginButton))]
    private string userEmail;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(EnableLoginButton))]
    private string password;

    [ObservableProperty]
    private bool rememberMe;

    public bool EnableLoginButton => !string.IsNullOrWhiteSpace(UserEmail) && !string.IsNullOrWhiteSpace(Password);

    public LoginPageViewModel(INavigationProvider navigationProvider, ILoggedUserService loggedUserService) : base(navigationProvider, "Login")
    {
        _loggedUserService = loggedUserService;
    }

    [RelayCommand]
    public async Task LoginAsync()
    {
        GenericResult<LoginResult> result = await _loggedUserService.LoginAsync(new LoginRequest(UserEmail, Password, RememberMe), _cancellationToken);

        if (result.Succeeded)
        {
            await _navigationProvider.GoToMyDashboardAsync(result.Data.UserId);
            return;
        }

        //Exibir modal de erro
    }

    [RelayCommand]
    public async Task RegisterNewUserAsync() => await _navigationProvider.GoToRegisterNewUserAsync(UserEmail);

    [RelayCommand]
    public async Task ForgotPasswordAsync() => await _navigationProvider.GoToForgotPasswordAsync(UserEmail);

    protected override async Task InternalInitializeAsync()
    {
        string bearerToken = _loggedUserService.TryGetUserBearerToken();

        if (!string.IsNullOrWhiteSpace(bearerToken))
        {
            await _navigationProvider.GoToMyDashboardAsync(Guid.Empty);
            return;
        };

        UserEmail = _loggedUserService.TryGetUserEmail();
        Password = await _loggedUserService.TryGetUserPasswordAsync();
    }
}