namespace OmegaFY.Blog.Maui.App.Models.APIs.Results;

public sealed record class RefreshTokenResult
{
    public string Token { get; set; }

    public DateTime TokenExpirationDate { get; set; }

    public Guid RefreshToken { get; set; }

    public DateTime RefreshTokenExpirationDate { get; set; }
}