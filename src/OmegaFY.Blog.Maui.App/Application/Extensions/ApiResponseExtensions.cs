using OmegaFY.Blog.Maui.App.Application.Base;
using OmegaFY.Blog.Maui.App.Infra.ExternalServices.Base;

namespace OmegaFY.Blog.Maui.App.Application.Extensions;

public static class ApiResponseExtensions
{
    public static GenericResult<T> ToGenericResult<T>(this ApiResponse<T> apiResponse) => new GenericResult<T>(apiResponse.Data, apiResponse.Errors);
}