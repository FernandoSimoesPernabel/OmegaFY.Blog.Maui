using OmegaFY.Blog.Maui.App.Models.Base;

namespace OmegaFY.Blog.Maui.App.Domain.Commands.RegisterNewUser;

public class RegisterNewUserCommandResult : GenericResult
{
    public Guid UserId { get; set; }

    public string Token { get; set; }

    public DateTime TokenExpirationDate { get; set; }

    public Guid RefreshToken { get; set; }

    public DateTime RefreshTokenExpirationDate { get; set; }

    public RegisterNewUserCommandResult() { }

    public RegisterNewUserCommandResult(Guid userId, string token, DateTime tokenExpirationDate, Guid refreshToken, DateTime refreshTokenExpirationDate)
    {
        UserId = userId;
        Token = token;
        TokenExpirationDate = tokenExpirationDate;
        RefreshToken = refreshToken;
        RefreshTokenExpirationDate = refreshTokenExpirationDate;
    }
}