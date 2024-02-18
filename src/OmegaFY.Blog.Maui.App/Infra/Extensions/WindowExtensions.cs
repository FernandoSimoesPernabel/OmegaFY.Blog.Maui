namespace OmegaFY.Blog.Maui.App.Infra.Extensions;

public static class WindowExtensions
{
    public static void ChangeWindowSize(this Window window, double width, double height)
    {
        window.Width = width;
        window.Height = height;
    }

    public static void CenterWindow(this Window window, DisplayInfo currentDisplayInfo)
    {
        window.X = (currentDisplayInfo.Width / currentDisplayInfo.Density - window.Width) / 2;
        window.Y = (currentDisplayInfo.Height / currentDisplayInfo.Density - window.Height) / 2;
    }
}