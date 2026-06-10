namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.DataDrivenStyles
{
    /// <summary>
    /// A builder class for constructing match style expressions in Azure Maps. 
    /// This class provides a fluent interface for defining complex match expressions that can be used to style map features based on their properties.
    /// It allows you to specify the input expression, define multiple cases with corresponding output styles, and set a default style for unmatched cases. 
    /// </summary>
    public class MatchStyleBuilder
    {
        private readonly List<(string Case, string Value)> _cases;

        /// <summary>
        /// Initializes a new instance of the MatchStyleBuilder class with the specified input expression and an optional list of cases.
        /// </summary>
        /// <param name="inputExpression"><see cref="InputExpression"/></param>
        /// <param name="cases">cases that define the match expression; see <see cref="AddCase(string, string)"/></param>
        /// <param name="defaultCase"><see cref="DefaultCase"/></param>
        public MatchStyleBuilder(string inputExpression, List<(string Case, string Value)>? cases = null, string? defaultCase = null)
        {
            InputExpression = inputExpression;
            _cases = cases ?? [];
            DefaultCase = defaultCase;
        }

        /// <summary>
        /// The input expression that will be evaluated against the defined cases. 
        /// This is typically a property of the map feature that you want to style based on its value.
        /// </summary>
        public string InputExpression { get; set { ArgumentException.ThrowIfNullOrWhiteSpace(value); field = value; } }

        /// <summary>
        /// Adds a default case to the match expression.
        /// </summary>
        public string? DefaultCase { get; set; }

        /// <summary>
        /// Adds a case to the match expression with the specified case value and corresponding output style.
        /// </summary>
        /// <param name="caseValue"></param>
        /// <param name="outputValue"></param>
        public void AddCase(string caseValue, string outputValue)
        {
            _cases.Add((caseValue, outputValue));
        }

        /// <summary>
        /// Builds the match style expression based on the defined cases and default style.
        /// </summary>
        /// <returns></returns>
        public object Build()
        {
            var result = new List<object> {
                "match",
                new List<string> { "get", InputExpression },
            };

            foreach (var (Case, Value) in _cases)
            {
                result.Add(Case);
                result.Add(Value);
            }

            if (!string.IsNullOrWhiteSpace(DefaultCase))
                result.Add(DefaultCase);

            return result;
        }

        /// <summary>
        /// Returns a JSON string representation of the match style expression built by this builder.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return System.Text.Json.JsonSerializer.Serialize(Build());
        }
    }
}
