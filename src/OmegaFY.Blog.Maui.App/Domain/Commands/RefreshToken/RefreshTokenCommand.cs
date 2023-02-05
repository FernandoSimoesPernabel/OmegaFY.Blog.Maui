namespace OmegaFY.Blog.Maui.App.Domain.Commands.RefreshToken;

public class RefreshTokenCommand
{
    public string CurrentToken { get; }

    public Guid RefreshToken { get; }

    public RefreshTokenCommand(string currentToken, Guid refreshToken)
    {
        CurrentToken = currentToken;
        RefreshToken = refreshToken;
    }
}