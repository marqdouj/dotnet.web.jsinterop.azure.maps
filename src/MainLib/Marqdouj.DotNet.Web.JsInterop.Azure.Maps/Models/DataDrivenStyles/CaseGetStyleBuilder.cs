namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.DataDrivenStyles
{
    /// <summary>
    /// A builder class for constructing case style expressions in Azure Maps.
    /// </summary>
    /// <param name="hasProperty"></param>
    /// <param name="getProperty"></param>
    /// <param name="defaultValue"></param>
    public class CaseGetStyleBuilder(string hasProperty, string getProperty, string defaultValue)
    {
        /// <summary>
        /// The property to check for existence in the map feature. 
        /// </summary>
        public string HasProperty { get; } = hasProperty;

        /// <summary>
        /// The property to retrieve the value from if the specified property exists in the map feature.
        /// </summary>
        public string GetProperty { get; } = getProperty;

        /// <summary>
        /// The default value to use in the case style expression if the specified property does not exist in the map feature.
        /// </summary>
        public string DefaultValue { get; } = defaultValue;

        /// <summary>
        /// Builds the case style expression.
        /// </summary>
        /// <returns></returns>
        public object Build()
        {
            var result = new List<object>
            {
                "case",
                new List<string> { "has", HasProperty },
                new List<string> { "get", GetProperty },
                DefaultValue
            };

            return result;
        }

        /// <summary>
        /// Returns a JSON string representation of the case style expression built by this builder.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return System.Text.Json.JsonSerializer.Serialize(Build());
        }
    }
}
