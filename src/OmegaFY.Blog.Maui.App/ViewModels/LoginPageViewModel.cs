using MediatR;
using OmegaFY.Blog.Maui.App.Application.Base;
using OmegaFY.Blog.Maui.App.Application.Commands.Login;
using OmegaFY.Blog.Maui.App.Infra.Navigation;
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

    public bool EnableLoginButton => !string.IsNullOrWhiteSpace(UserEmail) && !string.IsNullOrWhiteSpace(Password);

    public LoginPageViewModel(IMediator mediator, INavigationProvider navigationProvider, ILoggedUserService loggedUserService)
        : base(mediator, navigationProvider, "Login")
    {
        _loggedUserService = loggedUserService;
    }

    [RelayCommand]
    public async Task LoginAsync()
    {
        GenericResult<LoginCommandResult> result = await _mediator.Send(new LoginCommand(UserEmail, Password, true));

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

        //TODO Validar conteudo do token

        if (!string.IsNullOrWhiteSpace(bearerToken))
        {
            await _navigationProvider.GoToMyDashboardAsync(Guid.Empty);
            return;
        };

        UserEmail = _loggedUserService.TryGetUserEmail();
        Password = await _loggedUserService.TryGetUserPasswordAsync();
    }
}