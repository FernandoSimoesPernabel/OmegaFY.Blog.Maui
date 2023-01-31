using System.Text.Json;

namespace OmegaFY.Blog.Maui.App.Common.Serializers;

public static class JsonStaticSerializer
{
    public static T Deserialize<T>(string jsonString) => JsonSerializer.Deserialize<T>(jsonString);

    public static string Serialize<T>(T value) => JsonSerializer.Serialize(value);
}