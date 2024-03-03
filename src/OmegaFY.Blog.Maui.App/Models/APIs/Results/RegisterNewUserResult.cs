namespace OmegaFY.Blog.Maui.App.Models.APIs.Results;

public sealed record class RegisterNewUserResult
{
    public Guid UserId { get; set; }

    public string Token { get; set; }

    public DateTime TokenExpirationDate { get; set; }

    public Guid RefreshToken { get; set; }

    public DateTime RefreshTokenExpirationDate { get; set; }

    public RegisterNewUserResult() { }

    public RegisterNewUserResult(Guid userId, string token, DateTime tokenExpirationDate, Guid refreshToken, DateTime refreshTokenExpirationDate)
    {
        UserId = userId;
        Token = token;
        TokenExpirationDate = tokenExpirationDate;
        RefreshToken = refreshToken;
        RefreshTokenExpirationDate = refreshTokenExpirationDate;
    }
}