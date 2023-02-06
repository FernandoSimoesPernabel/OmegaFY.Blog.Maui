namespace OmegaFY.Blog.Maui.App.Application.Base;

public class ApiResponse<T>
{
    public bool Succeeded { get; set; }

    public bool Failed { get; set; }

    public T Data { get; set; }

    public ValidationError[] Errors { get; set; } = Array.Empty<ValidationError>();
}