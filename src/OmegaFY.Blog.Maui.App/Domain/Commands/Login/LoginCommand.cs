namespace OmegaFY.Blog.Maui.App.Domain.Commands.Login;

public class LoginCommand
{
    public string Email { get; }

    public string Password { get; }

    public LoginCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }
}