using OmegaFY.Blog.Maui.App.Common.Extensions;
using OmegaFY.Blog.Maui.App.Common.Models;

namespace OmegaFY.Blog.Maui.App.Application.Base;

public sealed record class GenericResult<T>
{
    public bool Succeeded { get; }

    public bool Failed { get; }

    public T Data { get; }

    public ValidationError[] Errors { get; }

    public GenericResult(T data, ValidationError[] errors)
    {
        Errors = errors ?? Array.Empty<ValidationError>();
        Succeeded = Errors.IsEmpty();
        Failed = !Succeeded;
        Data = data;
    }
}