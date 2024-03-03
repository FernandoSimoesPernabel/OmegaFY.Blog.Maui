namespace OmegaFY.Blog.Maui.App.Models.APIs.Requests;

public sealed record class LogoffRequest
{
    public Guid RefreshToken { get; }

    public LogoffRequest(Guid refreshToken)
    {
        RefreshToken = refreshToken;
    }
}