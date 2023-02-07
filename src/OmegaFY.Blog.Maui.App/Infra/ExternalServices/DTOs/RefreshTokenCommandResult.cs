namespace OmegaFY.Blog.Maui.App.Infra.ExternalServices.DTOs;

public class RefreshTokenCommandResult
{
    public string Token { get; set; }

    public DateTime TokenExpirationDate { get; set; }

    public Guid RefreshToken { get; set; }

    public DateTime RefreshTokenExpirationDate { get; set; }
}