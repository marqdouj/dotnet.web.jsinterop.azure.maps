namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.DataDrivenStyles
{
    /// <summary>
    /// Builds style expressions for coalescing property values in Azure Maps.
    /// </summary>
    public class CoalesceGetStyleBuilder
    {
        private readonly List<DDSPropertyAction> _cases;

        /// <summary>
        /// Initializes a new instance of the CoalesceGetStyleBuilder class with the specified list of cases.
        /// </summary>
        /// <param name="cases"></param>
        /// <param name="defaultValue"></param>
        public CoalesceGetStyleBuilder(List<DDSPropertyAction> cases, string defaultValue = "")
        {
            ArgumentNullException.ThrowIfNull(cases, nameof(cases));
            _cases = cases;
            DefaultValue = defaultValue;
        }

        /// <summary>
        /// Default case for the coalesce expression.
        /// </summary>
        public string DefaultValue { get; }

        /// <summary>
        /// Builds the coalesce style expression based on the defined cases.
        /// </summary>
        /// <returns></returns>
        public object Build()
        {
            var result = new List<object> {
                "coalesce",
            };

            foreach (var caseValue in _cases)
            {
                result.Add(caseValue.Build());
            }

            result.Add(DefaultValue);

            return result;
        }

        /// <summary>
        /// Returns a JSON string representation of the coalesce style expression built by this builder.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return System.Text.Json.JsonSerializer.Serialize(Build());
        }
    }
}
