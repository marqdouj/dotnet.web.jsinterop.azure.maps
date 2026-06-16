namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.DataDrivenStyles
{
    /// <summary>
    /// A builder class for creating data-driven style expressions for Azure Maps. 
    /// This class provides some methods to construct various types of expressions,
    /// which can be used to define how map features are styled based on their properties.
    /// </summary>
    public static class DDSBuilder
    {
        /// <summary>
        /// Creates a case expression for styling map features based on the presence of a specified property and its value.
        /// </summary>
        /// <param name="hasProperty">The property to check for existence in the map feature.</param>
        /// <param name="getProperty">The property to retrieve the value from if the specified property exists in the map feature.</param>
        /// <param name="defaultValue">The default value to use in the case style expression if the specified property does not exist in the map feature.</param>
        /// <returns></returns>
        public static object CaseGet(string hasProperty, string getProperty, string defaultValue)
        {
            var builder = new CaseGetStyleBuilder(hasProperty, getProperty, defaultValue);
            return builder.Build();
        }

        /// <summary>
        /// Creates a coalesce expression for styling map features based on a list of expressions and an optional default case.
        /// </summary>
        /// <param name="expressions">The list of expressions to evaluate. Normally, these are property names.</param>
        /// <param name="defaultCase">The default case to use if none of the expressions evaluate to a truthy value.</param>
        /// <returns></returns>
        public static object CoalesceGet(List<string> expressions, string defaultCase = "")
        {
            var builder = new CoalesceGetStyleBuilder(expressions, defaultCase);
            return builder.Build();
        }

        /// <summary>
        /// Creates a concatenation expression for styling map features by concatenating the value of a specified property with a given string.
        /// </summary>
        /// <param name="getProperty">The property to retrieve the value from if the specified property exists in the map feature.</param>
        /// <param name="concatenateValue">The value to concatenate with the retrieved property value.</param>
        /// <returns></returns>
        public static object ConcatGet(string getProperty, string concatenateValue)
        {
            var builder = new ConcatGetStyleBuilder(getProperty, concatenateValue);
            return builder.Build();
        }

        /// <summary>
        /// Creates a geometry filter expression for styling map features based on their geometry type.
        /// </summary>
        /// <param name="expressions">The list of geometry filter expressions.</param>
        /// <param name="multipleExpressionOperator">The operator for handling multiple expressions, i.e. "any", "all". Defaults to "any".</param>
        /// <returns></returns>
        public static object GeometryFilter(List<GeometryFilterExpression> expressions, string multipleExpressionOperator = "any")
        {
            var builder = new GeometryFilterStyleBuilder(expressions, multipleExpressionOperator);
            return builder.Build();
        }

        /// <summary>
        /// Creates a linear interpolation expression for styling map features based on a specified input expression and a list of cases.
        /// </summary>
        /// <param name="inputExpression">The input expression to interpolate.</param>
        /// <param name="cases">A list of cases for the linear interpolation.</param>
        /// <returns></returns>
        public static object LinearInterpolate(string inputExpression, List<(double Case, string Value)> cases)
        {
            var builder = new LinearInterpolateStyleBuilder(inputExpression, cases);
            return builder.Build();
        }

        /// <summary>
        /// Creates a literal expression for retrieving the value of a specified property from a map feature.
        /// </summary>
        /// <param name="value">The property value to retrieve.</param>
        /// <returns></returns>
        public static List<string> LiteralGet(string value)
        {
            return ["get", value];
        }

        /// <summary>
        /// Creates a match expression for styling map features based on a specified input expression, a list of cases, and an optional default case.
        /// </summary>
        /// <param name="inputExpression">The input expression to match against.</param>
        /// <param name="cases">A list of cases for the match expression.</param>
        /// <param name="defaultCase">The default case to use if no other cases match.</param>
        /// <returns></returns>
        public static object Match(string inputExpression, List<(string Case, string Value)> cases, string? defaultCase)
        {
            var builder = new MatchStyleBuilder(inputExpression, cases, defaultCase);
            return builder.Build();
        }
    }
}
