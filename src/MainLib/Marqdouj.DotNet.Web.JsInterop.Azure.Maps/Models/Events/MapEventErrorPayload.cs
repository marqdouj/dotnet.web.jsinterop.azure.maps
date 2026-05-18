using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events
{
    /// <summary>
    /// Payload when the map encounters an error.
    /// </summary>
    public class MapEventErrorPayload
    {
        /// <summary>
        /// Name
        /// </summary>
        [JsonInclude] public string? Name { get; internal set; }

        /// <summary>
        /// Message
        /// </summary>
        [JsonInclude] public string? Message { get; internal set; }

        /// <summary>
        /// Cause (if known).
        /// </summary>
        [JsonInclude] public string? Cause { get; internal set; }

        /// <summary>
        /// Stack
        /// </summary>
        [JsonInclude] public string? Stack { get; internal set; }

        /// <summary>
        /// Builds a message based on the available information.
        /// Message is always included, but the name, cause, and stack trace are optional based on the parameters.
        /// </summary>
        /// <param name="includeName">Whether to include the name in the message.</param>
        /// <param name="includeCause">Whether to include the cause in the message.</param>
        /// <param name="includeStack">Whether to include the stack trace in the message.</param>
        public string BuildMessage(bool includeName = true, bool includeCause = true, bool includeStack = false)
        {
            var sb = new System.Text.StringBuilder();

            if (includeName && !string.IsNullOrWhiteSpace(Name))
            {
                sb.AppendLine($"Name: {Name}");
            }

            if (!string.IsNullOrWhiteSpace(Message))
            {
                sb.AppendLine($"Message: {Message}");
            }

            if (includeCause && !string.IsNullOrWhiteSpace(Cause))
            {
                sb.AppendLine($"Cause: {Cause}");
            }

            if (includeStack && !string.IsNullOrWhiteSpace(Stack))
            {
                sb.AppendLine($"Stack: {Stack}");
            }

            return sb.ToString();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return BuildMessage();
        }
    }
}
