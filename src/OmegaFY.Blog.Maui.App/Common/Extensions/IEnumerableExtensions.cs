namespace OmegaFY.Blog.Maui.App.Common.Extensions;

public static class IEnumerableExtensions
{
    public static bool IsEmpty<T>(this IEnumerable<T> values) => !values.Any();
}