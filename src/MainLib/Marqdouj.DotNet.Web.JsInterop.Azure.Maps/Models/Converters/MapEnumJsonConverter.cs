using System.Text.Json;
using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Converters
{
    internal class MapEnumJsonConverter<T> : JsonConverter<T> where T : struct, Enum
    {
        private enum ConvertDirection { Read, Write }

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string enumString = ToEnumString(reader.GetString(), ConvertDirection.Read);
            if (Enum.TryParse(enumString, true, out T value))
            {
                return value;
            }
            throw new JsonException($"Unable to convert \"{enumString}\" to {typeof(T)}.");
        }

        private static string ToEnumString(string? enumString, ConvertDirection direction)
        {
            if (enumString == null)
            {
                throw direction switch
                {
                    ConvertDirection.Read => new JsonException($"Unable to convert null to {typeof(T)}."),
                    ConvertDirection.Write => new JsonException($"Unable to convert {enumString} to string."),
                    _ => new JsonException("Invalid conversion direction."),
                };
            }

            enumString = direction == ConvertDirection.Read ? enumString.Replace("-", "_") : enumString.Replace("_", "-").ToLower(); ;

            return enumString;
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            string enumString = ToEnumString(value.ToString(), ConvertDirection.Write);
            writer.WriteStringValue(enumString);
        }
    }
}
