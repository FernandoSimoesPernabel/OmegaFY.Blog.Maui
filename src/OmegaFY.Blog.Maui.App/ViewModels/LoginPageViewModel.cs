using MediatR;
using OmegaFY.Blog.Maui.App.Application.Base;
using OmegaFY.Blog.Maui.App.Application.Commands.Login;
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

    public LoginPageViewModel(IMediator mediator) : base(mediator)
    {
        ViewTitle = "Main Page";
    }

    [RelayCommand]
    public async Task LoginAsync()
    {
        LoginCommand command = new LoginCommand(UserEmail, Password);

        GenericResult<LoginCommandResult> result = await _mediator.Send(command);

        //if (result.Succeeded)
        //{
        //    //Proxima tela
        //}
    }

    [RelayCommand]
    public async Task RegisterNewUserAsync()
    {
        //RegisterNewUserCommand command = null;

        //GenericResult<RegisterNewUserCommandResult> result = await _mediator.Send(command);

        //if (result.Succeeded)
        //{
        //    //Proxima tela
        //}
    }
}