namespace OmegaFY.Blog.Maui.App.Models.APIs.Requests;

public sealed record class RefreshTokenRequest
{
    public string CurrentToken { get; }

    public Guid RefreshToken { get; }

    public RefreshTokenRequest(string currentToken, Guid refreshToken)
    {
        CurrentToken = currentToken;
        RefreshToken = refreshToken;
    }
}