namespace OmegaFY.Blog.Maui.App.Application.Commands.User.RefreshToken;

public sealed record class RefreshTokenCommand
{
    public string CurrentToken { get; }

    public Guid RefreshToken { get; }

    public RefreshTokenCommand(string currentToken, Guid refreshToken)
    {
        CurrentToken = currentToken;
        RefreshToken = refreshToken;
    }
}