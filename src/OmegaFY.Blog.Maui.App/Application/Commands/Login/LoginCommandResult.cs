namespace OmegaFY.Blog.Maui.App.Application.Commands.Login;

public class LoginCommandResult
{
    public Guid UserId { get; set; }

    public string DisplayName { get; set; }

    public string Email { get; set; }

    public string Token { get; set; }

    public DateTime TokenExpirationDate { get; set; }

    public Guid RefreshToken { get; set; }

    public DateTime RefreshTokenExpirationDate { get; set; }
}