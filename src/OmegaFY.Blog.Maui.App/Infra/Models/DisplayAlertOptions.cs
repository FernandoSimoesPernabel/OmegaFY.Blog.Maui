namespace OmegaFY.Blog.Maui.App.Infra.Models;

public readonly record struct DisplayAlertOptions
{
    public string Title { get; }

    public string Message { get; }

    public string Ok { get; }

    public string Cancel { get; }

    public DisplayAlertOptions(string title, string message) : this(title, message, nameof(Ok), nameof(Cancel)) { }

    public DisplayAlertOptions(string title, string message, string ok, string cancel)
    {
        Title = title;
        Message = message;
        Ok = ok;
        Cancel = cancel;
    }
}