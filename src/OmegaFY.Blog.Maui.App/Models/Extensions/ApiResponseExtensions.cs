using OmegaFY.Blog.Maui.App.Infra.ExternalServices.Base;
using OmegaFY.Blog.Maui.App.Models.APIs.Base;

namespace OmegaFY.Blog.Maui.App.Models.Extensions;

public static class ApiResponseExtensions
{
    public static GenericResult<T> ToGenericResult<T>(this ApiResponse<T> apiResponse) => new GenericResult<T>(apiResponse.Data, apiResponse.Errors);
}