namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Common
{
    /// <summary>
    /// Base class for objects used in js interop.
    /// </summary>
    public abstract class JsInteropBase
    {
        /// <summary>
        /// Indentifier.
        /// </summary>
        public string Id { get => string.IsNullOrWhiteSpace(field) ? InteropId : field; set { if (string.IsNullOrWhiteSpace(value)) return; field = value?.Trim(); } }

        /// <summary>
        /// Id assigned internally for use with js interop when the Id is missing.
        /// </summary>
        internal string InteropId { get; set; } = $"g_{Guid.CreateVersion7()}";
    }
}
