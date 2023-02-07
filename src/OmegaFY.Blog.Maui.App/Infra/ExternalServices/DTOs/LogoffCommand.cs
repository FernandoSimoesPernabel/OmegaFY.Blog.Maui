namespace OmegaFY.Blog.Maui.App.Infra.ExternalServices.DTOs;

public class LogoffCommand
{
    public Guid RefreshToken { get; }

    public LogoffCommand(Guid refreshToken)
    {
        RefreshToken = refreshToken;
    }
}