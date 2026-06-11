using Marqdouj.DotNet.Web.JsInterop.GeoJson;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.DataDrivenStyles
{
    /// <summary>
    /// A builder class for constructing geometry filter style expressions in Azure Maps.
    /// </summary>
    internal class GeometryFilterStyleBuilder
    {
        private readonly List<GeometryFilterExpression> _expressions;

        public string MultipleExpressionOperator { get; }

        /// <summary>
        /// Initializes a new instance of the GeometryFilterStyleBuilder class with the specified list of geometry filter expressions.
        /// </summary>
        /// <param name="expressions">The list of geometry filter expressions.</param>
        /// <param name="multipleExpressionOperator">The operator for handling multiple expressions, i.e. "any", "all". Defaults to "any".</param>
        public GeometryFilterStyleBuilder(List<GeometryFilterExpression> expressions, string multipleExpressionOperator = "any")
        {
            ArgumentNullException.ThrowIfNull(expressions, nameof(expressions));
            ArgumentNullException.ThrowIfNullOrWhiteSpace(multipleExpressionOperator, nameof(multipleExpressionOperator));
            _expressions = expressions;
            MultipleExpressionOperator = multipleExpressionOperator;
        }

        /// <summary>
        /// Builds the geometry filter style expression based on the defined expressions.
        /// </summary>
        /// <returns></returns>
        public object Build()
        {
            var result = new List<object>();

            if (_expressions.Count > 1)
                result.Add(MultipleExpressionOperator);

            foreach (var expression in _expressions)
                result.Add(expression);

            return result;
        }

        /// <summary>
        /// Returns a JSON string representation of the geometry filter style expression built by this builder.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return System.Text.Json.JsonSerializer.Serialize(Build());
        }
    }

    /// <summary>
    /// Represents a geometry filter expression used in Azure Maps data-driven styles.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the GeometryFilterExpression class with the specified geometry type and expression operator.
    /// </remarks>
    public class GeometryFilterExpression
    {
        /// <param name="geometryType">The type of geometry to filter.</param>
        /// <param name="expressionOperator">The operator for the expression.</param>
        public GeometryFilterExpression(string geometryType, string expressionOperator = "==")
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(geometryType, nameof(geometryType));
            ArgumentNullException.ThrowIfNullOrWhiteSpace(expressionOperator, nameof(expressionOperator));
            ExpressionOperator = expressionOperator;
            GeometryType = geometryType;
        }

        /// <summary>
        /// Initializes a new instance of the GeometryFilterExpression class with the specified geometry type and expression operator.
        /// </summary>
        /// <param name="geometryType">The type of geometry to filter.</param>
        /// <param name="expressionOperator">The operator for the expression.</param>
        public GeometryFilterExpression(GeometryType geometryType, string expressionOperator = "==") : this(geometryType.ToString(), expressionOperator)
        {
        }

        /// <summary>
        /// The operator for the expression, which is used to compare the geometry type of a map feature with the specified geometry type in the filter expression.
        /// </summary>
        public string ExpressionOperator { get; }

        /// <summary>
        /// The type of geometry to filter, which is used in the filter expression to determine whether a map feature's geometry type matches the specified geometry type.
        /// </summary>
        public string GeometryType { get; }
    }
}
