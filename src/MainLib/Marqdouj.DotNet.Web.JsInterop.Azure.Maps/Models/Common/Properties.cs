using System.Text.Json;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Common
{
    /// <summary>
    /// <![CDATA[Dictionary<string, object?>]]>
    /// </summary>
    public class Properties : Dictionary<string, object> 
    {
        /// <summary>
        /// <see cref="object.ToString()"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => this.Any() ? JsonSerializer.Serialize(this) : "";
    }
}
