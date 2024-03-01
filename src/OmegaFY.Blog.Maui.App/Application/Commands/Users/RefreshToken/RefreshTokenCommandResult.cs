namespace OmegaFY.Blog.Maui.App.Application.Commands.Users.RefreshToken;

public sealed record class RefreshTokenCommandResult
{
    public string Token { get; set; }

    public DateTime TokenExpirationDate { get; set; }

    public Guid RefreshToken { get; set; }

    public DateTime RefreshTokenExpirationDate { get; set; }
}