using System.Text.Json;

namespace Cobra.Common
{
    public static class JsonExtension
    {
        public static string ToJson(this object value)
        {
            return value == null ? null : JsonSerializer.Serialize(value, new JsonSerializerOptions { IgnoreNullValues = true });
        }

        public static TType JsonToObject<TType>(this string value) where TType : class
        {
            return value == null ? null : JsonSerializer.Deserialize<TType>(value);
        }
    }
}