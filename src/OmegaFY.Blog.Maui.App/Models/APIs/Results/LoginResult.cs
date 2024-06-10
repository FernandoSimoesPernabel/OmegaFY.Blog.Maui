namespace OmegaFY.Blog.Maui.App.Models.APIs.Results;

public sealed record class LoginResult
{
    public Guid UserId { get; set; }

    public string DisplayName { get; set; }

    public string Email { get; set; }

    public string Token { get; set; }

    public DateTime TokenExpirationDate { get; set; }

    public Guid RefreshToken { get; set; }

    public DateTime RefreshTokenExpirationDate { get; set; }
}