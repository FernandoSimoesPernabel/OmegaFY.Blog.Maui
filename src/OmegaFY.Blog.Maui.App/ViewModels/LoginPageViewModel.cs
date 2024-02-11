using MediatR;
using OmegaFY.Blog.Maui.App.Application.Base;
using OmegaFY.Blog.Maui.App.Application.Commands.Login;
using OmegaFY.Blog.Maui.App.ViewModels.Base;
using OmegaFY.Blog.Maui.App.Views;

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

    public LoginPageViewModel(IMediator mediator) : base(mediator, "Login") { }

    [RelayCommand]
    public async Task LoginAsync()
    {
        GenericResult<LoginCommandResult> result = await _mediator.Send(new LoginCommand(UserEmail, Password));

        if (result.Succeeded)
        {
            await Shell.Current.GoToAsync(nameof(MyDashboardPage));
        }
    }

    [RelayCommand]
    public Task RegisterNewUserAsync()
    {
        //Trocar para view de registro.
        return Task.CompletedTask;
    }

    [RelayCommand]
    public Task ForgotPasswordAsync()
    {
        //Trocar para view de esqueci a senha.
        return Task.CompletedTask;
    }
}