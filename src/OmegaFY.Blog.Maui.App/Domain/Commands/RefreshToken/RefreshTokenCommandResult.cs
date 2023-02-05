using OmegaFY.Blog.Maui.App.Models.Base;

namespace OmegaFY.Blog.Maui.App.Domain.Commands.RefreshToken;

public class RefreshTokenCommandResult : GenericResult
{
    public string Token { get; set; }

    public DateTime TokenExpirationDate { get; set; }

    public Guid RefreshToken { get; set; }

    public DateTime RefreshTokenExpirationDate { get; set; }
}