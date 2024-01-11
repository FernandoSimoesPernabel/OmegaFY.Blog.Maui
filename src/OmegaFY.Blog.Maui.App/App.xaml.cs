using OmegaFY.Blog.Maui.App.Infra.Extensions;

namespace OmegaFY.Blog.Maui.App;

public partial class App : Microsoft.Maui.Controls.Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        Window window = base.CreateWindow(activationState);

        if (DeviceInfo.Platform == DevicePlatform.WinUI)
            window.Activated += Window_Activated;

        return window;
    }

    private void Window_Activated(object sender, EventArgs e)
    {
        Window window = sender as Window;

        window.ChangeWindowSize(360, 720);

        window.CenterWindow(DeviceDisplay.Current.MainDisplayInfo);
    }
}