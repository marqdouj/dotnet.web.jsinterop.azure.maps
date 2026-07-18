using Marqdouj.DotNet.Web.JsInterop.GeoJson;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.DataDrivenStyles
{
    /// <summary>
    /// A builder class for constructing geometry filter style expressions in Azure Maps.
    /// </summary>
    public class GeometryFilterStyleBuilder
    {
        private readonly List<GeometryFilterExpression> _expressions;

        /// <summary>
        /// Gets the operator for handling multiple expressions, which can be "any" or "all". This operator determines how the geometry filter evaluates multiple expressions.
        /// </summary>
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
            if (_expressions.Count > 1)
            {
                var result = new List<object>
                {
                    MultipleExpressionOperator
                };

                foreach (var expression in _expressions)
                    result.Add(expression.Build());

                return result;
            }

            if (_expressions.Count == 1)
            {
                return _expressions[0].Build();
            }
            else
            {
                throw new InvalidOperationException("No expressions defined for the geometry filter style.");
            }
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
        /// <param name="expressionOperator">The operator for the expression. Defaults to "==".</param>
        public GeometryFilterExpression(string geometryType, string expressionOperator = "==")
        {
            ExpressionOperator = expressionOperator;
            GeometryType = geometryType;
            Validate();
        }

        /// <summary>
        /// Initializes a new instance of the GeometryFilterExpression class with the specified geometry type and expression operator.
        /// </summary>
        /// <param name="geometryType">The type of geometry to filter.</param>
        /// <param name="expressionOperator">The operator for the expression. Defaults to "==".</param>
        public GeometryFilterExpression(GeometryType geometryType, string expressionOperator = "==") : this(geometryType.ToString(), expressionOperator)
        {
        }

        /// <summary>
        /// The operator for the expression, which is used to compare the geometry type of a map feature with the specified geometry type in the filter expression.
        /// </summary>
        public string ExpressionOperator { get; set; }

        /// <summary>
        /// The type of geometry to filter, which is used in the filter expression to determine whether a map feature's geometry type matches the specified geometry type.
        /// </summary>
        public string GeometryType { get; set; }

        /// <summary>
        /// Validates the geometry filter expression by checking that the GeometryType and ExpressionOperator properties are not null or whitespace. Throws an ArgumentNullException if either property is invalid.
        /// </summary>
        public void Validate()
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(GeometryType, nameof(GeometryType));
            ArgumentNullException.ThrowIfNullOrWhiteSpace(ExpressionOperator, nameof(ExpressionOperator));
        }

        /// <summary>
        /// Builds the geometry filter expression as an object array containing the expression operator and geometry type. This method is used to construct the final representation of the geometry filter expression for use in Azure Maps data-driven styles.
        /// </summary>
        /// <returns></returns>
        public object Build()
        {
            return new object[] { ExpressionOperator, new object[] { "geometry-type" }, GeometryType };
        }

        /// <summary>
        /// Returns a JSON string representation of the geometry filter expression built by this instance.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => System.Text.Json.JsonSerializer.Serialize(Build());
    }
}
