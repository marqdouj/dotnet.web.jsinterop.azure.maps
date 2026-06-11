namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.DataDrivenStyles
{
    /// <summary>
    /// A builder class for creating data-driven style expressions for Azure Maps. 
    /// This class provides methods to construct various types of expressions,
    /// which can be used to define how map features are styled based on their properties.
    /// </summary>
    public static class DDSBuilder
    {
        /// <summary>
        /// Creates a linear interpolation expression for styling map features based on a specified input expression and a list of cases.
        /// </summary>
        /// <param name="inputExpression"></param>
        /// <param name="cases"></param>
        /// <returns></returns>
        public static object LinearInterpolate(string inputExpression, List<(double Case, string Value)> cases)
        {
            var builder = new LinearInterpolateStyleBuilder(inputExpression, cases);
            return builder.Build();
        }

        /// <summary>
        /// Creates a match expression for styling map features based on a specified input expression, a list of cases, and an optional default case.
        /// </summary>
        /// <param name="inputExpression"></param>
        /// <param name="cases"></param>
        /// <param name="defaultCase"></param>
        /// <returns></returns>
        public static object Match(string inputExpression, List<(string Case, string Value)> cases, string? defaultCase)
        {
            var builder = new MatchStyleBuilder(inputExpression, cases, defaultCase);
            return builder.Build();
        }

        /// <summary>
        /// Creates a literal expression for retrieving the value of a specified property from a map feature.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static List<string> LiteralGet(string value)
        {
            return new List<string> { "get", value };
        }
    }
}
