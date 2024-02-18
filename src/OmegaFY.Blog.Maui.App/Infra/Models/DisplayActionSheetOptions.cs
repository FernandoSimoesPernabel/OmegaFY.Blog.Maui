namespace OmegaFY.Blog.Maui.App.Infra.Models;

public readonly record struct DisplayActionSheetOptions
{
    public string Title { get; }

    public string Cancel { get; }

    public string Destruction { get; }

    public FlowDirection FlowDirection { get; }

    public string[] Buttons { get; }

    public DisplayActionSheetOptions()
    {

    }

    public DisplayActionSheetOptions(string title, string cancel, string destruction, FlowDirection flowDirection, string[] buttons)
    {
        Title = title;
        Cancel = cancel;
        Destruction = destruction;
        FlowDirection = flowDirection;
        Buttons = buttons;
    }
}