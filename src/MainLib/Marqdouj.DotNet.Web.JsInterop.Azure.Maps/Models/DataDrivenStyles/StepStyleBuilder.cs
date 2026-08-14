namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.DataDrivenStyles
{
    /// <summary>
    /// Builder class for creating a linear step style expression for Azure Maps.
    /// </summary>
    public class StepStyleBuilder
    {
        private readonly List<(double Case, object Value)> _cases;

        /// <summary>
        /// Initializes a new instance of the LinearInterpolateStyleBuilder class with the specified input expression and an optional list of cases.
        /// </summary>
        /// <param name="inputExpression"><see cref="InputExpression"/></param>
        /// <param name="cases">cases that define the linear step expression; see <see cref="AddCase(double, object)"/></param>
        /// <param name="defaultValue">The default value to be used when none of the defined cases match the input expression.</param>
        public StepStyleBuilder(string inputExpression, List<(double Case, object Value)>? cases = null, object? defaultValue = null)
        {
            InputExpression = inputExpression;
            _cases = cases ?? [];
            DefaultValue = defaultValue;
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
        public void AddCase(double caseValue, object outputValue)
        {
            _cases.Add((caseValue, outputValue));
        }

        /// <summary>
        /// Gets or sets the default value to be used when none of the defined cases match the input expression.
        /// </summary>
        public object? DefaultValue { get; set; }

        /// <summary>
        /// Builds the linear step style expression based on the defined cases.
        /// </summary>
        /// <returns></returns>
        public object Build()
        {
            var result = new List<object> {
                "step",
                new List<string> { "get", InputExpression },
            };

            if (DefaultValue != null)
            {
                result.Add(DefaultValue);
            }

            foreach (var (Case, Value) in _cases)
            {
                result.Add(Case);
                result.Add(Value);
            }

            return result;
        }

        /// <summary>
        /// Returns a JSON string representation of the linear step style expression built by this builder.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return System.Text.Json.JsonSerializer.Serialize(Build());
        }
    }
}
