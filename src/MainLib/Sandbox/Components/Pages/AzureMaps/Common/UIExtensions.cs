using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sandbox.Components.Pages.AzureMaps.Common
{
    internal static class UIExtensions
    {
        private static readonly JsonSerializerOptions jsonMinOptions = new()
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        extension<T>(T obj)
        {
            internal string ToJsonMin()
            {
                return JsonSerializer.Serialize(obj, jsonMinOptions);
            }
        }

        public static string GetRandomCssId()
        {
            return $"g_{Guid.NewGuid()}";
        }
    }
}
