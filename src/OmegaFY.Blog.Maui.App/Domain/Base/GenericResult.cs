namespace OmegaFY.Blog.Maui.App.Models.Base;

public abstract class GenericResult
{
    public ValidationError[] Errors { get; set; } = Array.Empty<ValidationError>();

    public bool Succeeded => Errors.Length == 0;

    public bool Failed => !Succeeded;
}