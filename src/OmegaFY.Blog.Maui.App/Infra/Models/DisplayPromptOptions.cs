namespace OmegaFY.Blog.Maui.App.Infra.Models;

public readonly record struct DisplayPromptOptions
{
    public string Title { get; }

    public string Message { get; }

    public string Accept { get; }

    public string Cancel { get; }

    public string Placeholder { get; }

    public int MaxLenght { get; }

    public Keyboard Keyboard { get; }

    public string InitialValue { get; }

    public DisplayPromptOptions()
    {

    }

    public DisplayPromptOptions(
        string title,
        string message,
        string accept,
        string cancel,
        string placeholder,
        int maxLenght,
        Keyboard keyboard,
        string initialValue)
    {
        Title = title;
        Message = message;
        Accept = accept;
        Cancel = cancel;
        Placeholder = placeholder;
        MaxLenght = maxLenght;
        Keyboard = keyboard;
        InitialValue = initialValue;
    }
}