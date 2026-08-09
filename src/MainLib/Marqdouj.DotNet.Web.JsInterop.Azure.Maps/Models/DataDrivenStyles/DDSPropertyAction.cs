namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.DataDrivenStyles
{
    /// <summary>
    /// Represents an action to get a property value in Azure Maps Data Driven Styles.
    /// </summary>
    public class DDSPropertyAction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DDSPropertyAction"/> class with the specified property name and action type.
        /// </summary>
        /// <param name="name">The name of the property to retrieve.</param>
        /// <param name="action">The action type. Default is "get".</param>
        public DDSPropertyAction(string name, string action = "get")
        {
            Name = name;
            Action = action;
            Validate();
        }

        /// <summary>
        /// Gets the action type. Default is "get".
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Gets the name of the property to retrieve.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Validates the property action, ensuring that the name and action are not null or whitespace. Throws an ArgumentNullException if either property is invalid.
        /// </summary>
        public void Validate()
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
            ArgumentNullException.ThrowIfNullOrWhiteSpace(Action, nameof(Action));
        }

        /// <summary>
        /// Builds a DDS representation of the property action, suitable for use in Azure Maps Data Driven Styles expressions.
        /// </summary>
        /// <returns></returns>
        public object Build() => new object[] { Action, Name };

        /// <summary>
        /// Returns a JSON string representation of the property action.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => System.Text.Json.JsonSerializer.Serialize(Build());
    }
}
