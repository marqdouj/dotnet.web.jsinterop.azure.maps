namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.DataDrivenStyles
{
    /// <summary>
    /// A builder class for creating data-driven style expressions for Azure Maps. 
    /// This class provides some methods to construct various types of expressions,
    /// which can be used to define how map features are styled based on their properties.
    /// </summary>
    /// <remarks><see href="https://learn.microsoft.com/en-us/azure/azure-maps/data-driven-style-expressions-web-sdk"/></remarks>
    public static class DDSBuilder
    {
        /// <summary>
        /// Creates a case expression for styling map features based on the presence of a specified property and its value.
        /// </summary>
        /// <param name="hasProperty">The property to check for existence in the map feature.</param>
        /// <param name="getProperty">The property to retrieve the value from if the specified property exists in the map feature.</param>
        /// <param name="defaultValue">The default value to use in the case style expression if the specified property does not exist in the map feature.</param>
        /// <param name="returnJson">Indicates whether to return the result as JSON.</param>
        /// <returns></returns>
        public static object CaseGet(string hasProperty, string getProperty, string defaultValue, bool returnJson = false)
        {
            var builder = new CaseGetStyleBuilder(hasProperty, getProperty, defaultValue);
            return returnJson ? builder.ToString() : builder.Build();
        }

        /// <summary>
        /// Creates a coalesce expression for styling map features based on the presence of multiple specified properties and their values.
        /// </summary>
        /// <param name="expressions">The list of property actions to evaluate.</param>
        /// <param name="defaultValue">The default value to use if none of the expressions evaluate to a truthy value.</param>
        /// <param name="returnJson">Indicates whether to return the result as JSON.</param>
        /// <returns></returns>
        public static object CoalesceGet(List<DDSPropertyAction> expressions, string defaultValue = "", bool returnJson = false)
        {
            var builder = new CoalesceGetStyleBuilder(expressions, defaultValue);
            return returnJson ? builder.ToString() : builder.Build();
        }

        /// <summary>
        /// Creates a concatenation expression for styling map features by concatenating the value of a specified property with a given string.
        /// </summary>
        /// <param name="getProperty">The property to retrieve the value from if the specified property exists in the map feature.</param>
        /// <param name="concatenateValue">The value to concatenate with the retrieved property value.</param>
        /// <param name="returnJson">Indicates whether to return the result as JSON.</param>
        /// <returns></returns>
        public static object ConcatGet(string getProperty, string concatenateValue, bool returnJson = false)
        {
            var builder = new ConcatGetStyleBuilder(getProperty, concatenateValue);
            return returnJson ? builder.ToString() : builder.Build();
        }

        /// <summary>
        /// Creates a geometry filter expression for styling map features based on their geometry type.
        /// </summary>
        /// <param name="expressions">The list of geometry filter expressions.</param>
        /// <param name="multipleExpressionOperator">The operator for handling multiple expressions, i.e. "any", "all". Defaults to "any".</param>
        /// <param name="returnJson">Indicates whether to return the result as JSON.</param>
        /// <returns></returns>
        public static object GeometryFilter(List<GeometryFilterExpression> expressions, string multipleExpressionOperator = "any", bool returnJson = false)
        {
            var builder = new GeometryFilterStyleBuilder(expressions, multipleExpressionOperator);
            return returnJson ? builder.ToString() : builder.Build();
        }

        /// <summary>
        /// Creates a linear interpolation expression for styling map features based on a specified input expression and a list of cases.
        /// </summary>
        /// <param name="inputExpression">The input expression to interpolate.</param>
        /// <param name="cases">A list of cases for the linear interpolation.</param>
        /// <param name="returnJson">Indicates whether to return the result as JSON.</param>
        /// <returns></returns>
        public static object LinearInterpolate(string inputExpression, List<(double Case, object Value)> cases, bool returnJson = false)
        {
            var builder = new LinearInterpolateStyleBuilder(inputExpression, cases);
            return returnJson ? builder.ToString() : builder.Build();
        }

        /// <summary>
        /// Creates a literal expression for retrieving the value of a specified property from a map feature.
        /// </summary>
        /// <param name="value">The property value to retrieve.</param>
        /// <param name="returnJson">Indicates whether to return the result as JSON.</param>
        /// <returns></returns>
        public static object LiteralGet(string value, bool returnJson = false)
        {
            var result = new List<string> { "get", value };
            return returnJson ? System.Text.Json.JsonSerializer.Serialize(result) : result;
        }

        /// <summary>
        /// Creates a match expression for styling map features based on a specified input expression, a list of cases, and an optional default case.
        /// </summary>
        /// <param name="inputExpression">The input expression to match against.</param>
        /// <param name="cases">A list of cases for the match expression.</param>
        /// <param name="defaultCase">The default case to use if no other cases match.</param>
        /// <param name="returnJson">Indicates whether to return the result as JSON.</param>
        /// <returns></returns>
        public static object Match(string inputExpression, List<(string Case, string Value)> cases, string? defaultCase, bool returnJson = false)
        {
            var builder = new MatchStyleBuilder(inputExpression, cases, defaultCase);
            return returnJson ? builder.ToString() : builder.Build();
        }

        /// <summary>
        /// Creates a step expression for styling map features based on a specified input expression and a list of cases.
        /// </summary>
        /// <param name="inputExpression">The input expression to step through.</param>
        /// <param name="cases">A list of cases for the step expression.</param>
        /// <param name="defaultValue">The default value to use if no other cases match.</param>
        /// <param name="returnJson">Indicates whether to return the result as JSON.</param>
        /// <returns></returns>
        public static object Step(string inputExpression, List<(double Case, object Value)> cases, object? defaultValue = null, bool returnJson = false)
        {
            var builder = new StepStyleBuilder(inputExpression, cases, defaultValue);
            return returnJson ? builder.ToString() : builder.Build();
        }
    }
}
