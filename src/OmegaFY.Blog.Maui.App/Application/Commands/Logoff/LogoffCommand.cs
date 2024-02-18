namespace OmegaFY.Blog.Maui.App.Application.Commands.Logoff;

public sealed record class LogoffCommand
{
    public Guid RefreshToken { get; }

    public LogoffCommand(Guid refreshToken)
    {
        RefreshToken = refreshToken;
    }
}