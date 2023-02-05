namespace OmegaFY.Blog.Maui.App.Domain.Commands.Logoff;

public class LogoffCommand
{
    public Guid RefreshToken { get; }

    public LogoffCommand(Guid refreshToken)
    {
        RefreshToken = refreshToken;
    }
}