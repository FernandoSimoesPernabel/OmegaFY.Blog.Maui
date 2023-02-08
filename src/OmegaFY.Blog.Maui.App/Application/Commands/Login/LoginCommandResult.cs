namespace OmegaFY.Blog.Maui.App.Application.Commands.Login;

public class LoginCommandResult
{
    public string Token { get; set; }

    public DateTime TokenExpirationDate { get; set; }

    public Guid RefreshToken { get; set; }

    public DateTime RefreshTokenExpirationDate { get; set; }
}