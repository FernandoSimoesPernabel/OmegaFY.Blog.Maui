namespace OmegaFY.Blog.Maui.App.Application.Commands.RegisterNewUser;

public class RegisterNewUserCommand
{
    public string Email { get; }

    public string DisplayName { get; }

    public string Password { get; }

    public RegisterNewUserCommand(string email, string displayName, string password)
    {
        Email = email;
        DisplayName = displayName;
        Password = password;
    }
}
