using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sandbox.UI.Models
{
    /// <summary>
    /// 
    /// </summary>
    public static class UIExtensions
    {
        /// <summary>
        /// CSS inline style for a 1px solid light-gray border.
        /// </summary>
        /// <remarks>Prefer using CSS classes for maintainability; use this constant for inline style
        /// composition or quick prototypes.</remarks>
        public const string ThinBorderStyle = "var(--strokeWidthThin) solid var(--colorNeutralStroke1);";

        internal const string EditWidth = "150px";
        internal const string EditWidthStyle = "width:150px;";
        internal const string EditWidthShortStyle = "width:80px;";
        internal const string SelectBorderStyleReadOnly = "border-bottom: 1px solid gray;";

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

        /// <summary>
        /// Generates a random CSS ID string, prefixed with "g_" to ensure it starts with a letter (valid CSS identifier).
        /// </summary>
        /// <returns></returns>
        public static string GetRandomCssId()
        {
            return $"g_{Guid.CreateVersion7()}";
        }
    }
}
