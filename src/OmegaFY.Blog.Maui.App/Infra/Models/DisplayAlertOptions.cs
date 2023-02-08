namespace OmegaFY.Blog.Maui.App.Infra.Models;

public readonly record struct DisplayAlertOptions
{
    public string Title { get; }

    public string Message { get; }

    public string Accept { get; }

    public string Cancel { get; }

    public DisplayAlertOptions()
    {

    }

    public DisplayAlertOptions(string title, string message, string accept, string cancel)
    {
        Title = title;
        Message = message;
        Accept = accept;
        Cancel = cancel;
    }
}