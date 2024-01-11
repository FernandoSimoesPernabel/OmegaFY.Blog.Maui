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

        window.Width = 360;
        window.Height = 720;

        DisplayInfo displayInfo = DeviceDisplay.Current.MainDisplayInfo;

        window.X = (displayInfo.Width / displayInfo.Density - window.Width) / 2;
        window.Y = (displayInfo.Height / displayInfo.Density - window.Height) / 2;
    }
}