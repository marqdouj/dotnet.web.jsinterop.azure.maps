namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.DataDrivenStyles
{
    /// <summary>
    /// A builder class for creating a concat style expression that retrieves the value of a specified property from a map feature
    /// and concatenates it with a specified value if the property exists.
    /// </summary>
    /// <param name="getProperty"></param>
    /// <param name="concatenateValue"></param>
    internal class ConcatGetStyleBuilder(string getProperty, string concatenateValue)
    {
        /// <summary>
        /// The property to retrieve the value from if the specified property exists in the map feature.
        /// </summary>
        public string GetProperty { get; } = getProperty;
        public string ConcatenateValue { get; } = concatenateValue;

        /// <summary>
        /// Builds the concat style expression.
        /// </summary>
        /// <returns></returns>
        public object Build()
        {
            var result = new List<object>
            {
                "concat",
                new List<object> { "to-string", new List<string> { "get", GetProperty } },
                ConcatenateValue
            };

            return result;
        }

        /// <summary>
        /// Returns a JSON string representation of the concat style expression built by this builder.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return System.Text.Json.JsonSerializer.Serialize(Build());
        }
    }
}
