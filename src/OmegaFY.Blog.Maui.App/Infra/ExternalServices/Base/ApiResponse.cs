using OmegaFY.Blog.Maui.App.Common.Models;

namespace OmegaFY.Blog.Maui.App.Infra.ExternalServices.Base;

public class ApiResponse<T>
{
    public bool Succeeded { get; set; }

    public bool Failed => !Succeeded;

    public T Data { get; set; }

    public ValidationError[] Errors { get; set; } = Array.Empty<ValidationError>();
}