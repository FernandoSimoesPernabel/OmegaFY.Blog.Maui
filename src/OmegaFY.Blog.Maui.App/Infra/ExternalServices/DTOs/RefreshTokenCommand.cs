namespace OmegaFY.Blog.Maui.App.Infra.ExternalServices.DTOs;

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