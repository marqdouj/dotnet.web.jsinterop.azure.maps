namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.DataDrivenStyles
{
    /// <summary>
    /// Builder class for creating a linear interpolation style expression for Azure Maps.
    /// </summary>
    public class LinearInterpolateStyleBuilder
    {
        private readonly List<(double Case, string Value)> _cases;

        /// <summary>
        /// Initializes a new instance of the LinearInterpolateStyleBuilder class with the specified input expression and an optional list of cases.
        /// </summary>
        /// <param name="inputExpression"><see cref="InputExpression"/></param>
        /// <param name="cases">cases that define the linear interpolation expression; see <see cref="AddCase(double, string)"/></param>
        public LinearInterpolateStyleBuilder(string inputExpression, List<(double Case, string Value)>? cases = null)
        {
            InputExpression = inputExpression;
            _cases = cases ?? [];
        }

        /// <summary>
        /// The input expression that will be evaluated against the defined cases. 
        /// This is typically a property of the map feature that you want to style based on its value.
        /// </summary>
        public string InputExpression { get; set { ArgumentException.ThrowIfNullOrWhiteSpace(value); field = value; } }

        /// <summary>
        /// Adds a case to the match expression with the specified case value and corresponding output style.
        /// </summary>
        /// <param name="caseValue"></param>
        /// <param name="outputValue"></param>
        public void AddCase(double caseValue, string outputValue)
        {
            _cases.Add((caseValue, outputValue));
        }

        /// <summary>
        /// Builds the linear interpolation style expression based on the defined cases.
        /// </summary>
        /// <returns></returns>
        public object Build()
        {
            var result = new List<object> {
                "interpolate",
                new List<string> { "linear" },
                new List<string> { "get", InputExpression },
            };

            foreach (var (Case, Value) in _cases)
            {
                result.Add(Case);
                result.Add(Value);
            }

            return result;
        }

        /// <summary>
        /// Returns a JSON string representation of the linear interpolation style expression built by this builder.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return System.Text.Json.JsonSerializer.Serialize(Build());
        }
    }
}
